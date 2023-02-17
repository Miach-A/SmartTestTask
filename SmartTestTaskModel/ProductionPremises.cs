namespace SmartTestTaskModel
{
    public class ProductionPremises
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double SpaceForEquipment { get; set; }
        public IEnumerable<EquipmentPlacementContract> Contracts { get; set; } = Enumerable.Empty<EquipmentPlacementContract>();
    }
}