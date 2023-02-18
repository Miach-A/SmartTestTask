namespace SmartTestTask.CQRS.EquipmentPlacementContracts.Queries.GetEquipmentPlacementContract
{
    public class EquipmentPlacementContractDto
    {
        public string ProductionPremises { get; set; } = string.Empty;
        public string TypeOfEquipment { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
