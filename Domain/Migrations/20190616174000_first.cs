using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentType = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Seria = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameRegion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Teacher = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalCity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalCity_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Fathername = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    MainDocumentId = table.Column<int>(nullable: true),
                    SNILS = table.Column<string>(nullable: true),
                    MedPolis = table.Column<string>(nullable: true),
                    LocalCityId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<long>(nullable: false),
                    Parent1 = table.Column<string>(nullable: true),
                    Parent1Phone = table.Column<string>(nullable: true),
                    Parent2 = table.Column<string>(nullable: true),
                    Parent2Phone = table.Column<string>(nullable: true),
                    Group1Id = table.Column<int>(nullable: true),
                    Group2Id = table.Column<int>(nullable: true),
                    Group3Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Group_Group1Id",
                        column: x => x.Group1Id,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Group_Group2Id",
                        column: x => x.Group2Id,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Group_Group3Id",
                        column: x => x.Group3Id,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_LocalCity_LocalCityId",
                        column: x => x.LocalCityId,
                        principalTable: "LocalCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Document_MainDocumentId",
                        column: x => x.MainDocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_DepartmentId",
                table: "Group",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalCity_RegionId",
                table: "LocalCity",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Group1Id",
                table: "Students",
                column: "Group1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Group2Id",
                table: "Students",
                column: "Group2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Group3Id",
                table: "Students",
                column: "Group3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LocalCityId",
                table: "Students",
                column: "LocalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MainDocumentId",
                table: "Students",
                column: "MainDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "LocalCity");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
