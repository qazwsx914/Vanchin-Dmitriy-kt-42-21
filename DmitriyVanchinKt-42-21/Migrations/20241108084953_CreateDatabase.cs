using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DmitriyVanchinKt_42_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_cathedra",
                columns: table => new
                {
                    cathedra_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_cathedra_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    head_lecturer_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор заведующего кафедрой")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_cathedra_cathedra_id", x => x.cathedra_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_lecturer",
                columns: table => new
                {
                    lecturer_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи предподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_lecturer_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя предподавателя"),
                    c_lecturer_lactname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия предподавателя"),
                    c_lecturer_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество предподавателя"),
                    CathedraId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_lecturer_lecturer_id", x => x.lecturer_id);
                    table.ForeignKey(
                        name: "fk_f_cathedra_id",
                        column: x => x.CathedraId,
                        principalTable: "cd_cathedra",
                        principalColumn: "cathedra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loads",
                columns: table => new
                {
                    LoadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LecturerId = table.Column<int>(type: "integer", nullable: false),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false),
                    OpeningHours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loads", x => x.LoadId);
                    table.ForeignKey(
                        name: "FK_Loads_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loads_cd_lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "cd_lecturer",
                        principalColumn: "lecturer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_cathedra_head_lecturer_id",
                table: "cd_cathedra",
                column: "head_lecturer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_lecturer_fk_f_cathedra_id",
                table: "cd_lecturer",
                column: "CathedraId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_DisciplineId",
                table: "Loads",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_LecturerId",
                table: "Loads",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "fk_cathedra_head_lecturer_id",
                table: "cd_cathedra",
                column: "head_lecturer_id",
                principalTable: "cd_lecturer",
                principalColumn: "lecturer_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cathedra_head_lecturer_id",
                table: "cd_cathedra");

            migrationBuilder.DropTable(
                name: "Loads");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "cd_lecturer");

            migrationBuilder.DropTable(
                name: "cd_cathedra");
        }
    }
}
