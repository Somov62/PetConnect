using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVolunteer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_photo_pets_pet_id",
                table: "photo");

            migrationBuilder.DropForeignKey(
                name: "fk_vaccination_pets_pet_id",
                table: "vaccination");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vaccination",
                table: "vaccination");

            migrationBuilder.DropPrimaryKey(
                name: "pk_photo",
                table: "photo");

            migrationBuilder.RenameTable(
                name: "vaccination",
                newName: "vaccinations");

            migrationBuilder.RenameTable(
                name: "photo",
                newName: "photos");

            migrationBuilder.RenameIndex(
                name: "ix_vaccination_pet_id",
                table: "vaccinations",
                newName: "ix_vaccinations_pet_id");

            migrationBuilder.RenameIndex(
                name: "ix_photo_pet_id",
                table: "photos",
                newName: "ix_photos_pet_id");

            migrationBuilder.AddColumn<Guid>(
                name: "volunteer_id",
                table: "pets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "volunteer_id",
                table: "photos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_vaccinations",
                table: "vaccinations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_photos",
                table: "photos",
                column: "id");

            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    donation_info = table.Column<string>(type: "text", nullable: false),
                    years_experience = table.Column<int>(type: "integer", nullable: false),
                    success_found_home_for_pet_count = table.Column<int>(type: "integer", nullable: false),
                    from_shelter = table.Column<bool>(type: "boolean", nullable: false),
                    social_medias = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_id",
                table: "pets",
                column: "volunteer_id");

            migrationBuilder.CreateIndex(
                name: "ix_photos_volunteer_id",
                table: "photos",
                column: "volunteer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_pets_volunteers_volunteer_id",
                table: "pets",
                column: "volunteer_id",
                principalTable: "volunteers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_photos_pets_pet_id",
                table: "photos",
                column: "pet_id",
                principalTable: "pets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_photos_volunteers_volunteer_id",
                table: "photos",
                column: "volunteer_id",
                principalTable: "volunteers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vaccinations_pets_pet_id",
                table: "vaccinations",
                column: "pet_id",
                principalTable: "pets",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pets_volunteers_volunteer_id",
                table: "pets");

            migrationBuilder.DropForeignKey(
                name: "fk_photos_pets_pet_id",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "fk_photos_volunteers_volunteer_id",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "fk_vaccinations_pets_pet_id",
                table: "vaccinations");

            migrationBuilder.DropTable(
                name: "volunteers");

            migrationBuilder.DropIndex(
                name: "ix_pets_volunteer_id",
                table: "pets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vaccinations",
                table: "vaccinations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_photos",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "ix_photos_volunteer_id",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "volunteer_id",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "volunteer_id",
                table: "photos");

            migrationBuilder.RenameTable(
                name: "vaccinations",
                newName: "vaccination");

            migrationBuilder.RenameTable(
                name: "photos",
                newName: "photo");

            migrationBuilder.RenameIndex(
                name: "ix_vaccinations_pet_id",
                table: "vaccination",
                newName: "ix_vaccination_pet_id");

            migrationBuilder.RenameIndex(
                name: "ix_photos_pet_id",
                table: "photo",
                newName: "ix_photo_pet_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vaccination",
                table: "vaccination",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_photo",
                table: "photo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_photo_pets_pet_id",
                table: "photo",
                column: "pet_id",
                principalTable: "pets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vaccination_pets_pet_id",
                table: "vaccination",
                column: "pet_id",
                principalTable: "pets",
                principalColumn: "id");
        }
    }
}
