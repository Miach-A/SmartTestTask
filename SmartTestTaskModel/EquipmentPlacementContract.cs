namespace SmartTestTaskModel
{
    public class EquipmentPlacementContract
    {
        public int Id { get; set; }
        public ProductionPremises ProductionPremises { get; set; } = null!;
        public TypeOfEquipment TypeOfEquipment { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
