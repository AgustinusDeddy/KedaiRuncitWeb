using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddSellItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellItems_Sells_SellId",
                table: "SellItems");

            migrationBuilder.DropIndex(
                name: "IX_SellItems_SellId",
                table: "SellItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SellItems");

            migrationBuilder.DropColumn(
                name: "SellId",
                table: "SellItems");

            migrationBuilder.CreateTable(
                name: "SoldItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SellId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldItem_Sells_SellId",
                        column: x => x.SellId,
                        principalTable: "Sells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoldItem_ItemId",
                table: "SoldItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldItem_SellId",
                table: "SoldItem",
                column: "SellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoldItem");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SellItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellId",
                table: "SellItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellItems_SellId",
                table: "SellItems",
                column: "SellId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellItems_Sells_SellId",
                table: "SellItems",
                column: "SellId",
                principalTable: "Sells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
