using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartTestTaskData;

namespace SmartTestTask.CQRS.EquipmentPlacementContracts.Queries.GetEquipmentPlacementContract
{
    public class GetEquipmentPlacementContractQuery : IRequest<IEnumerable<EquipmentPlacementContractDto>>
    {
    }

    public class GetEquipmentPlacementContractQueryHandler : IRequestHandler<GetEquipmentPlacementContractQuery, IEnumerable<EquipmentPlacementContractDto>>
    {
        private readonly AppDbContext _context;

        public GetEquipmentPlacementContractQueryHandler(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EquipmentPlacementContractDto>> Handle(GetEquipmentPlacementContractQuery request, CancellationToken cancellationToken)
        {
            return await _context.EquipmentPlacementContract.AsNoTracking()
                .Include(x => x.ProductionPremises)
                .Include(x => x.TypeOfEquipment)
                .Select(x => new EquipmentPlacementContractDto()
                {
                    ProductionPremises = x.ProductionPremises.Name,
                    TypeOfEquipment = x.TypeOfEquipment.Name,
                    Quantity = x.Quantity
                })
                .ToListAsync(cancellationToken);
        }
    }
}
