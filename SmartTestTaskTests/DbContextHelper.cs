using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SmartTestTaskData;
using SmartTestTaskModel;

namespace SmartTestTaskTests
{
    public static class DbContextHelper
    {
        static DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("UNIT_TESTING")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;
            Context = new AppDbContext(options);
            Seed();
        }

        static void Seed()
        {
            var typeOfEquipment = new TypeOfEquipment[6]
            {
                new () {Id = 1, Name = "Equipment #1", Area = 1},
                new () {Id = 2, Name = "Equipment #2", Area = 2},
                new () {Id = 3, Name = "Equipment #3", Area = 4},
                new () {Id = 4, Name = "Equipment #4", Area = 8},
                new () {Id = 5, Name = "Equipment #5", Area = 16},
                new () {Id = 6, Name = "Equipment #6", Area = 32}
            };

            var productionPremises = new ProductionPremises[6]
            {
                new () {Id = 1, Name = "Kyiv #1", SpaceForEquipment = 100d},
                new () {Id = 2, Name = "Kyiv #2", SpaceForEquipment = 200d},
                new () {Id = 3, Name = "Kyiv #3", SpaceForEquipment = 400d},
                new () {Id = 4, Name = "Lviv #1", SpaceForEquipment = 800d},
                new () {Id = 5, Name = "Lviv #2", SpaceForEquipment = 1600d},
                new () {Id = 6, Name = "Lviv #3", SpaceForEquipment = 3200d}
            };

            var equipmentPlacementContracts = new EquipmentPlacementContract[6]
            {
                new() { Id = 1, ProductionPremisesId = 1, TypeOfEquipmentId = 1, Quantity = 1 },
                new() { Id = 2, ProductionPremisesId = 1, TypeOfEquipmentId = 2, Quantity = 1 },
                new() { Id = 3, ProductionPremisesId = 1, TypeOfEquipmentId = 3, Quantity = 1 },
                new() { Id = 4, ProductionPremisesId = 2, TypeOfEquipmentId = 4, Quantity = 1 },
                new() { Id = 5, ProductionPremisesId = 2, TypeOfEquipmentId = 5, Quantity = 1 },
                new() { Id = 6, ProductionPremisesId = 2, TypeOfEquipmentId = 6, Quantity = 1 }
            };

            Context.TypeOfEquipment.AddRange(typeOfEquipment);
            Context.ProductionPremises.AddRange(productionPremises);
            Context.EquipmentPlacementContract.AddRange(equipmentPlacementContracts);
            Context.SaveChanges();
        }

        public static AppDbContext Context { get; set; }
    }

}
