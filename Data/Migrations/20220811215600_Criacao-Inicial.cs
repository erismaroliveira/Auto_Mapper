﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTarefa",
                columns: table => new
                {
                    IdTarefa = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTarefa_Tarefa_IdTarefa",
                        column: x => x.IdTarefa,
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTarefa_IdTarefa",
                table: "ItemTarefa",
                column: "IdTarefa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTarefa");

            migrationBuilder.DropTable(
                name: "Tarefa");
        }
    }
}
