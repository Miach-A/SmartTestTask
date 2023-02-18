using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartTestTask.Common.Models;
using SmartTestTaskData;

namespace SmartTestTask.CQRS.EquipmentPlacementContract.Commands.Create
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
        private readonly ILogger<CreateEquipmentPlacementContractCommand> _loger;

        public CreateEquipmentPlacementContractCommandHandler(
            AppDbContext context,
            ILogger<CreateEquipmentPlacementContractCommand> loger)
        {
            _context = context;
            _loger = loger;
        }

        public async Task<AppActionResult> Handle(CreateEquipmentPlacementContractCommand request, CancellationToken cancellationToken)
        {
            using var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);

            var needArea = _context.TypeOfEquipment.AsNoTracking().Where(x => x.Id == request.TypeOfEquipmentId).Select(x => x.Area * request.Quantity);
            var productionPremises = await _context.ProductionPremises
                .Where(x => x.Id == request.ProductionPremisesId)
                .Include(x => x.Contracts).ThenInclude(x => x.TypeOfEquipment)
                //.AsQueryable()
                .Select(x => new
                {
                    Available = x.SpaceForEquipment,
                    Use = x.Contracts.Sum(y => y.Quantity * y.TypeOfEquipment.Area),
                    NeedArea = needArea.Sum()
                }).FirstOrDefaultAsync(cancellationToken);
            //.FirstOrDefaultAsync(x => x.Id == request.ProductionPremisesId);
            if (productionPremises == null) return new AppActionResult() { Success = false, Errors = new List<string>() { "Production premises not found" } };



            return new AppActionResult() { Success = true, Id = 44 };
        }
    }
}

