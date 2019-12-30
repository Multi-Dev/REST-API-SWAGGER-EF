using Microsoft.EntityFrameworkCore.Migrations;

namespace REST_WebService.Migrations
{
    public partial class addingSeed01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drawers_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LinkToSite = table.Column<string>(nullable: true),
                    UnitCost = table.Column<decimal>(nullable: false),
                    DrawerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Drawers_DrawerId",
                        column: x => x.DrawerId,
                        principalTable: "Drawers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Drawers",
                columns: new[] { "Id", "Height", "Length", "StorageId", "Width" },
                values: new object[,]
                {
                    { 1, 10, 15, null, 30 },
                    { 2, 10, 15, null, 30 },
                    { 3, 10, 15, null, 30 },
                    { 4, 15, 15, null, 15 },
                    { 5, 40, 15, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "DrawerId", "Height", "Length", "LinkToSite", "Name", "UnitCost", "Weight", "Width" },
                values: new object[] { 1, " an open-source microcontroller board based on the Microchip ATmega328P microcontroller and developed by Arduino.cc.", null, 5.2999999999999998, 1.2, "https://www.arduino.cc/", "Arduino UNO", 16.00m, 0.025000000000000001, 6.9000000000000004 });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "Height", "Length", "Name", "Width" },
                values: new object[,]
                {
                    { 1, 15, 15, "Storage in Livingroom", 60 },
                    { 2, 60, 35, "hidden storage", 35 },
                    { 3, 120, 50, "Weapon storage", 220 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ItemId", "Value" },
                values: new object[,]
                {
                    { 1, null, "Arduino" },
                    { 2, null, "Board" },
                    { 3, null, "5V" },
                    { 4, null, "3.3V" },
                    { 5, null, "Beginners" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_StorageId",
                table: "Drawers",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_DrawerId",
                table: "Items",
                column: "DrawerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemId",
                table: "Tags",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
