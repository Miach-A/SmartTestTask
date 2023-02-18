using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartTestTaskData.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionPremises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SpaceForEquipment = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPremises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPlacementContract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionPremisesId = table.Column<int>(type: "int", nullable: false),
                    TypeOfEquipmentId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPlacementContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContract_ProductionPremises_ProductionPremisesId",
                        column: x => x.ProductionPremisesId,
                        principalTable: "ProductionPremises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContract_TypeOfEquipment_TypeOfEquipmentId",
                        column: x => x.TypeOfEquipmentId,
                        principalTable: "TypeOfEquipment",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ProductionPremises",
                columns: new[] { "Id", "Name", "SpaceForEquipment" },
                values: new object[,]
                {
                    { 1, "Kyiv #1", 100.0 },
                    { 2, "Kyiv #2", 200.0 },
                    { 3, "Kyiv #3", 400.0 },
                    { 4, "Lviv #1", 800.0 },
                    { 5, "Lviv #2", 1600.0 },
                    { 6, "Lviv #3", 3200.0 }
                });

            migrationBuilder.InsertData(
                table: "TypeOfEquipment",
                columns: new[] { "Id", "Area", "Name" },
                values: new object[,]
                {
                    { 1, 1.0, "Equipment #1" },
                    { 2, 2.0, "Equipment #2" },
                    { 3, 4.0, "Equipment #3" },
                    { 4, 8.0, "Equipment #4" },
                    { 5, 16.0, "Equipment #5" },
                    { 6, 32.0, "Equipment #6" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentPlacementContract",
                columns: new[] { "Id", "ProductionPremisesId", "Quantity", "TypeOfEquipmentId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 1, 1, 3 },
                    { 4, 2, 1, 4 },
                    { 5, 2, 1, 5 },
                    { 6, 2, 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContract_ProductionPremisesId",
                table: "EquipmentPlacementContract",
                column: "ProductionPremisesId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContract_TypeOfEquipmentId",
                table: "EquipmentPlacementContract",
                column: "TypeOfEquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentPlacementContract");

            migrationBuilder.DropTable(
                name: "ProductionPremises");

            migrationBuilder.DropTable(
                name: "TypeOfEquipment");
        }
    }
}
