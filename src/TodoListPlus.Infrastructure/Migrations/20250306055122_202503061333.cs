using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListPlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _202503061333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "todolisttask");

            migrationBuilder.CreateSequence(
                name: "taskseq",
                schema: "todolisttask",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "tasktagseq",
                schema: "todolisttask",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "tags",
                schema: "todolisttask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TagColor_Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "todotasks",
                schema: "todolisttask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TaskContent = table.Column<string>(type: "text", nullable: true),
                    SubTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Priority = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IdentityId = table.Column<string>(type: "text", nullable: false),
                    TodoTaskStatus = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todotasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tasktags",
                schema: "todolisttask",
                columns: table => new
                {
                    TodoTaskId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    TodoTaskId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasktags", x => new { x.TodoTaskId, x.TagId });
                    table.ForeignKey(
                        name: "FK_tasktags_tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "todolisttask",
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tasktags_todotasks_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalSchema: "todolisttask",
                        principalTable: "todotasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tasktags_todotasks_TodoTaskId1",
                        column: x => x.TodoTaskId1,
                        principalSchema: "todolisttask",
                        principalTable: "todotasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasktags_TagId",
                schema: "todolisttask",
                table: "tasktags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_tasktags_TodoTaskId1",
                schema: "todolisttask",
                table: "tasktags",
                column: "TodoTaskId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasktags",
                schema: "todolisttask");

            migrationBuilder.DropTable(
                name: "tags",
                schema: "todolisttask");

            migrationBuilder.DropTable(
                name: "todotasks",
                schema: "todolisttask");

            migrationBuilder.DropSequence(
                name: "taskseq",
                schema: "todolisttask");

            migrationBuilder.DropSequence(
                name: "tasktagseq",
                schema: "todolisttask");
        }
    }
}
