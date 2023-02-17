using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContract_TypeOfEquipment_TypeOfEquipmentId",
                        column: x => x.TypeOfEquipmentId,
                        principalTable: "TypeOfEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
