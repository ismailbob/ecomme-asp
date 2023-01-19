using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetE_comm.Migrations
{
    public partial class data1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Panier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreArticle = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PanierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commande_Panier_PanierId",
                        column: x => x.PanierId,
                        principalTable: "Panier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lignepanier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantite = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lignepanier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lignepanier_Commande_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commande",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lignepanier_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commande_PanierId",
                table: "Commande",
                column: "PanierId");

            migrationBuilder.CreateIndex(
                name: "IX_Lignepanier_CommandeId",
                table: "Lignepanier",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lignepanier_ProductId",
                table: "Lignepanier",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lignepanier");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Panier");
        }
    }
}
