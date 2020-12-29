using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordTest.Migrations
{
    public partial class wordTestModel10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_apppage",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_name = table.Column<string>(maxLength: 20, nullable: true),
                    w_type = table.Column<string>(maxLength: 20, nullable: true),
                    w_path = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_apppage", x => x.w_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_englishbook",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_englishbook", x => x.w_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.w_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_englishbookunit",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_name = table.Column<string>(maxLength: 20, nullable: true),
                    w_book = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_englishbookunit", x => x.w_id);
                    table.ForeignKey(
                        name: "FK_tb_englishbookunit_tb_englishbook_w_book",
                        column: x => x.w_book,
                        principalTable: "tb_englishbook",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_rolepage",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_role = table.Column<string>(maxLength: 64, nullable: true),
                    w_apppage = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rolepage", x => x.w_id);
                    table.ForeignKey(
                        name: "FK_tb_rolepage_tb_apppage_w_apppage",
                        column: x => x.w_apppage,
                        principalTable: "tb_apppage",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_rolepage_tb_role_w_role",
                        column: x => x.w_role,
                        principalTable: "tb_role",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_name = table.Column<string>(maxLength: 20, nullable: true),
                    w_gender = table.Column<string>(nullable: false),
                    w_age = table.Column<int>(nullable: false),
                    w_acc = table.Column<string>(nullable: true),
                    w_pwd = table.Column<string>(nullable: true),
                    w_userrole = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.w_id);
                    table.ForeignKey(
                        name: "FK_tb_user_tb_role_w_userrole",
                        column: x => x.w_userrole,
                        principalTable: "tb_role",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_unitword",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_unit = table.Column<string>(maxLength: 64, nullable: true),
                    w_name = table.Column<string>(maxLength: 20, nullable: true),
                    w_Soundname = table.Column<string>(maxLength: 20, nullable: true),
                    w_soundpath = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_unitword", x => x.w_id);
                    table.ForeignKey(
                        name: "FK_tb_unitword_tb_englishbookunit_w_unit",
                        column: x => x.w_unit,
                        principalTable: "tb_englishbookunit",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_task",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_name = table.Column<string>(maxLength: 20, nullable: true),
                    w_taskcreator = table.Column<string>(maxLength: 64, nullable: true),
                    w_aswer = table.Column<string>(maxLength: 64, nullable: true),
                    w_grade = table.Column<int>(nullable: false),
                    w_status = table.Column<string>(maxLength: 10, nullable: false),
                    w_rightcount = table.Column<int>(nullable: false),
                    w_errorcount = table.Column<int>(nullable: false),
                    w_rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_task", x => x.w_id);
                    table.ForeignKey(
                        name: "FK_tb_task_tb_user_w_aswer",
                        column: x => x.w_aswer,
                        principalTable: "tb_user",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_task_tb_user_w_taskcreator",
                        column: x => x.w_taskcreator,
                        principalTable: "tb_user",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_taskword",
                columns: table => new
                {
                    w_id = table.Column<string>(maxLength: 64, nullable: false),
                    w_inserttime = table.Column<DateTime>(nullable: false),
                    w_updatetime = table.Column<DateTime>(nullable: false),
                    w_creator = table.Column<string>(maxLength: 32, nullable: true),
                    w_operator = table.Column<string>(maxLength: 32, nullable: true),
                    w_word = table.Column<string>(maxLength: 64, nullable: true),
                    w_task = table.Column<string>(maxLength: 64, nullable: true),
                    w_status = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_taskword", x => x.w_id);
                    table.ForeignKey(
                        name: "FK_tb_taskword_tb_task_w_task",
                        column: x => x.w_task,
                        principalTable: "tb_task",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_taskword_tb_unitword_w_word",
                        column: x => x.w_word,
                        principalTable: "tb_unitword",
                        principalColumn: "w_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_englishbookunit_w_book",
                table: "tb_englishbookunit",
                column: "w_book");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rolepage_w_apppage",
                table: "tb_rolepage",
                column: "w_apppage");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rolepage_w_role",
                table: "tb_rolepage",
                column: "w_role");

            migrationBuilder.CreateIndex(
                name: "IX_tb_task_w_aswer",
                table: "tb_task",
                column: "w_aswer");

            migrationBuilder.CreateIndex(
                name: "IX_tb_task_w_taskcreator",
                table: "tb_task",
                column: "w_taskcreator");

            migrationBuilder.CreateIndex(
                name: "IX_tb_taskword_w_task",
                table: "tb_taskword",
                column: "w_task");

            migrationBuilder.CreateIndex(
                name: "IX_tb_taskword_w_word",
                table: "tb_taskword",
                column: "w_word");

            migrationBuilder.CreateIndex(
                name: "IX_tb_unitword_w_unit",
                table: "tb_unitword",
                column: "w_unit");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_w_userrole",
                table: "tb_user",
                column: "w_userrole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_rolepage");

            migrationBuilder.DropTable(
                name: "tb_taskword");

            migrationBuilder.DropTable(
                name: "tb_apppage");

            migrationBuilder.DropTable(
                name: "tb_task");

            migrationBuilder.DropTable(
                name: "tb_unitword");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_englishbookunit");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tb_englishbook");
        }
    }
}
