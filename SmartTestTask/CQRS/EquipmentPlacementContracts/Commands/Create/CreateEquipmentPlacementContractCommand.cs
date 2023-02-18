using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartTestTask.Common.Models;
using SmartTestTaskData;
using SmartTestTaskModel;

namespace SmartTestTask.CQRS.EquipmentPlacementContracts.Commands.Create
{
    public class CreateEquipmentPlacementContractCommand : IRequest<AppActionResult>
    {
        public int ProductionPremisesId { get; set; }
        public int TypeOfEquipmentId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateEquipmentPlacementContractCommandHandler : IRequestHandler<CreateEquipmentPlacementContractCommand, AppActionResult>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateEquipmentPlacementContractCommandHandler(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AppActionResult> Handle(CreateEquipmentPlacementContractCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable))
            {
                var requestedEquipment = _context.TypeOfEquipment.AsNoTracking().Where(x => x.Id == request.TypeOfEquipmentId);
                var balanceAfterReserve = await _context.ProductionPremises.AsNoTracking()
                    .Where(x => x.Id == request.ProductionPremisesId)
                    .Include(x => x.Contracts).ThenInclude(x => x.TypeOfEquipment)
                        .Join(requestedEquipment,
                        premises => true,
                        needArea => true,
                        (premises, requestedEquipment) => new
                        {
                            SpaceForEquipment = premises.SpaceForEquipment,
                            Uses = premises.Contracts.Sum(x => x.Quantity * x.TypeOfEquipment.Area),
                            Request = requestedEquipment.Area * request.Quantity
                        })
                .FirstOrDefaultAsync(cancellationToken);

                if (balanceAfterReserve == null) return new AppActionResult(false) { Errors = new List<string>() { "Wrong Id" } };

                if (balanceAfterReserve.SpaceForEquipment - balanceAfterReserve.Uses - balanceAfterReserve.Request < 0)
                {
                    return new AppActionResult(false) { Errors = new List<string>() { "Not enough area" } };
                }

                var newContract = _mapper.Map<EquipmentPlacementContract>(request);
                await _context.EquipmentPlacementContract.AddAsync(newContract, cancellationToken);

                if (await _context.SaveChangesAsync() == 0)
                {
                    return new AppActionResult(false) { AutoRepeatPossible = true, Errors = new List<string>() { "Save error. Try later." } };
                }

                transaction.Commit();
                return new AppActionCreateResult(true, newContract.Id);
            };

        }
    }
}

