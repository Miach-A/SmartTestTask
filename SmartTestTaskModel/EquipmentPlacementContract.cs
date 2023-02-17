namespace SmartTestTaskModel
{
    public class EquipmentPlacementContract
    {
        public int Id { get; set; }
        public ProductionPremises ProductionPremises { get; set; } = null!;
        public int ProductionPremisesId { get; set; }
        public TypeOfEquipment TypeOfEquipment { get; set; } = null!;
        public int TypeOfEquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}
