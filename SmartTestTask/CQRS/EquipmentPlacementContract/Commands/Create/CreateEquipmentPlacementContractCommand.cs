using MediatR;
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
            // _context.ProductionPremises.Where(x => x.Id == request.ProductionPremisesId)
            await Task.CompletedTask;
            return new AppActionResult() { Success = true, Id = 44 };
        }
    }
}

