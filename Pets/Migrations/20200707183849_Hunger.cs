using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets.Migrations
{
    public partial class Hunger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentHunger",
                table: "Pets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAte",
                table: "Pets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaxHunger",
                table: "Pets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHunger",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "LastAte",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "MaxHunger",
                table: "Pets");
        }
    }
}
