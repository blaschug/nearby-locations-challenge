using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationSearces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationSearchRequest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Coordinates_Latitude = table.Column<double>(type: "float", nullable: false),
                    Coordinates_Longitude = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSearchRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationSearchResponse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryFilteredBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSearchResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates_Latitude = table.Column<double>(type: "float", nullable: false),
                    Coordinates_Longitude = table.Column<double>(type: "float", nullable: false),
                    LocationSearchResponseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationInfo_LocationSearchResponse_LocationSearchResponseId",
                        column: x => x.LocationSearchResponseId,
                        principalTable: "LocationSearchResponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LocationSearches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ResponseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationSearches_LocationSearchRequest_RequestId",
                        column: x => x.RequestId,
                        principalTable: "LocationSearchRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocationSearches_LocationSearchResponse_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "LocationSearchResponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationInfo_LocationSearchResponseId",
                table: "LocationInfo",
                column: "LocationSearchResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSearches_RequestId",
                table: "LocationSearches",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSearches_ResponseId",
                table: "LocationSearches",
                column: "ResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationInfo");

            migrationBuilder.DropTable(
                name: "LocationSearches");

            migrationBuilder.DropTable(
                name: "LocationSearchRequest");

            migrationBuilder.DropTable(
                name: "LocationSearchResponse");
        }
    }
}
