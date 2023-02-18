
using SmartTestTask.CQRS.EquipmentPlacementContracts.Commands.Create;
using SmartTestTask.CQRS.EquipmentPlacementContracts.Queries.GetEquipmentPlacementContract;

namespace SmartTestTaskTests
{
    public class EquipmentPlacementContractTest
    {
        [Fact]
        public async Task Post()
        {
            var context = DbContextHelper.Context;

            var handlerPost = new CreateEquipmentPlacementContractCommandHandler(DbContextHelper.Context, AutoMaperHelper.Mapper);
            var handlerGet = new GetEquipmentPlacementContractQueryHandler(DbContextHelper.Context);
            CancellationTokenSource source = new CancellationTokenSource();

            var resGetBeforeInsert = await handlerGet.Handle(new GetEquipmentPlacementContractQuery(), source.Token);
            var resSuccess = await handlerPost.Handle(new CreateEquipmentPlacementContractCommand() { ProductionPremisesId = 1, TypeOfEquipmentId = 1, Quantity = 1 }, source.Token);
            var resGetAfterInsert = await handlerGet.Handle(new GetEquipmentPlacementContractQuery(), source.Token);

            var resRejectNotEnoughArea = await handlerPost.Handle(new CreateEquipmentPlacementContractCommand() { ProductionPremisesId = 1, TypeOfEquipmentId = 6, Quantity = 100 }, source.Token);
            var resRejectWrongId1 = await handlerPost.Handle(new CreateEquipmentPlacementContractCommand() { ProductionPremisesId = 1, TypeOfEquipmentId = 77, Quantity = 1 }, source.Token);
            var resRejectWrongId2 = await handlerPost.Handle(new CreateEquipmentPlacementContractCommand() { ProductionPremisesId = 77, TypeOfEquipmentId = 1, Quantity = 1 }, source.Token);

            Assert.NotEqual(resGetBeforeInsert.Count(), resGetAfterInsert.Count());
            Assert.True(resSuccess.Success, "Dont creare instance");
            Assert.False(resRejectNotEnoughArea.Success, "Create contract when note enought area");
            Assert.False(resRejectWrongId1.Success, "Dont reject with wrong PremisesId");
            Assert.False(resRejectWrongId2.Success, "Dont reject with wrong TypeOfEquipmentId");
        }
    }
}