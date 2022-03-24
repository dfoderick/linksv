﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace provider.Migrations
{
    public partial class LinkOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkOwner",
                columns: table => new
                {
                    OwnerAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkOwner", x => x.OwnerAddress);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Origin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Origin);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Nonce = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location);
                    table.ForeignKey(
                        name: "FK_Locations_Origins_Origin",
                        column: x => x.Origin,
                        principalTable: "Origins",
                        principalColumn: "Origin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkLocationLinkOwner",
                columns: table => new
                {
                    OwnedLinksLocation = table.Column<string>(type: "TEXT", nullable: false),
                    OwnersOwnerAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkLocationLinkOwner", x => new { x.OwnedLinksLocation, x.OwnersOwnerAddress });
                    table.ForeignKey(
                        name: "FK_LinkLocationLinkOwner_LinkOwner_OwnersOwnerAddress",
                        column: x => x.OwnersOwnerAddress,
                        principalTable: "LinkOwner",
                        principalColumn: "OwnerAddress",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkLocationLinkOwner_Locations_OwnedLinksLocation",
                        column: x => x.OwnedLinksLocation,
                        principalTable: "Locations",
                        principalColumn: "Location",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkLocationLinkOwner_OwnersOwnerAddress",
                table: "LinkLocationLinkOwner",
                column: "OwnersOwnerAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Nonce",
                table: "Locations",
                column: "Nonce");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Origin",
                table: "Locations",
                column: "Origin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkLocationLinkOwner");

            migrationBuilder.DropTable(
                name: "LinkOwner");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Origins");
        }
    }
}
