using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_Group1Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cities_LocalCityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Documents_MainDocumentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Schools_CityId",
                table: "Schools");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Parent1Phone",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Parent1",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainDocumentId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalCityId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Group1Id",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentNumber",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_Group1Id",
                table: "Students",
                column: "Group1Id",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cities_LocalCityId",
                table: "Students",
                column: "LocalCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Documents_MainDocumentId",
                table: "Students",
                column: "MainDocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_Group1Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cities_LocalCityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Documents_MainDocumentId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Parent1Phone",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Parent1",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "MainDocumentId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LocalCityId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Group1Id",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentNumber",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Schools",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CityId",
                table: "Schools",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_Group1Id",
                table: "Students",
                column: "Group1Id",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cities_LocalCityId",
                table: "Students",
                column: "LocalCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Documents_MainDocumentId",
                table: "Students",
                column: "MainDocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
