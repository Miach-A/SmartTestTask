namespace SmartTestTaskModel
{
    public class TypeOfEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Area { get; set; }
        public IEnumerable<EquipmentPlacementContract> Contracts { get; set; } = Enumerable.Empty<EquipmentPlacementContract>();
    }
}
