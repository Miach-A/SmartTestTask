namespace SmartTestTaskModel
{
    public class TypeOfEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Area { get; set; }
        public ICollection<EquipmentPlacementContract> Contracts { get; set; } = new List<EquipmentPlacementContract>();
    }
}
