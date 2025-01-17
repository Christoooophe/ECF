using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvenementParticipant_Evenement_EvenementsId",
                table: "EvenementParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_EvenementParticipant_Participant_ParticipantsId",
                table: "EvenementParticipant");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "EvenementParticipant",
                newName: "EvenementId");

            migrationBuilder.RenameColumn(
                name: "EvenementsId",
                table: "EvenementParticipant",
                newName: "ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_EvenementParticipant_ParticipantsId",
                table: "EvenementParticipant",
                newName: "IX_EvenementParticipant_EvenementId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvenementParticipant_Evenement_EvenementId",
                table: "EvenementParticipant",
                column: "EvenementId",
                principalTable: "Evenement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvenementParticipant_Participant_ParticipantId",
                table: "EvenementParticipant",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvenementParticipant_Evenement_EvenementId",
                table: "EvenementParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_EvenementParticipant_Participant_ParticipantId",
                table: "EvenementParticipant");

            migrationBuilder.RenameColumn(
                name: "EvenementId",
                table: "EvenementParticipant",
                newName: "ParticipantsId");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "EvenementParticipant",
                newName: "EvenementsId");

            migrationBuilder.RenameIndex(
                name: "IX_EvenementParticipant_EvenementId",
                table: "EvenementParticipant",
                newName: "IX_EvenementParticipant_ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvenementParticipant_Evenement_EvenementsId",
                table: "EvenementParticipant",
                column: "EvenementsId",
                principalTable: "Evenement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvenementParticipant_Participant_ParticipantsId",
                table: "EvenementParticipant",
                column: "ParticipantsId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
