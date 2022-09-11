using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class First_Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLinks_AppUser_AppUserId",
                table: "ProfileLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_ProgramingLanguages_ProgramingLanguageId",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramingLanguages",
                table: "ProgramingLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileLinks",
                table: "ProfileLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "ProfileType",
                table: "ProfileLinks");

            migrationBuilder.RenameTable(
                name: "UserOperationClaims",
                newName: "UserOperationClaim");

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "Technology");

            migrationBuilder.RenameTable(
                name: "ProgramingLanguages",
                newName: "Programing_Language");

            migrationBuilder.RenameTable(
                name: "ProfileLinks",
                newName: "ProfileLink");

            migrationBuilder.RenameTable(
                name: "OperationClaims",
                newName: "OperationClaim");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "User",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "User",
                newName: "Create_Date");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "UserOperationClaim",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "UserOperationClaim",
                newName: "Create_Date");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaim",
                newName: "IX_UserOperationClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaim",
                newName: "IX_UserOperationClaim_OperationClaimId");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Technology",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "ProgramingLanguageId",
                table: "Technology",
                newName: "Programing_LanguageId");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Technology",
                newName: "Create_Date");

            migrationBuilder.RenameIndex(
                name: "IX_Technologies_ProgramingLanguageId",
                table: "Technology",
                newName: "IX_Technology_Programing_LanguageId");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Programing_Language",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Programing_Language",
                newName: "Create_Date");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ProfileLink",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ProfileLink",
                newName: "Create_Date");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ProfileLink",
                newName: "DeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileLinks_AppUserId",
                table: "ProfileLink",
                newName: "IX_ProfileLink_DeveloperId");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "OperationClaim",
                newName: "Update_Date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OperationClaim",
                newName: "ClaimName");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "OperationClaim",
                newName: "Create_Date");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsMailConfirmed",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileTypeId",
                table: "ProfileLink",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaim",
                table: "UserOperationClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technology",
                table: "Technology",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programing_Language",
                table: "Programing_Language",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileLink",
                table: "ProfileLink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaim",
                table: "OperationClaim",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProfileType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLink_ProfileTypeId",
                table: "ProfileLink",
                column: "ProfileTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLink_ProfileType_ProfileTypeId",
                table: "ProfileLink",
                column: "ProfileTypeId",
                principalTable: "ProfileType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLink_User_DeveloperId",
                table: "ProfileLink",
                column: "DeveloperId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Technology_Programing_Language_Programing_LanguageId",
                table: "Technology",
                column: "Programing_LanguageId",
                principalTable: "Programing_Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_OperationClaim_OperationClaimId",
                table: "UserOperationClaim",
                column: "OperationClaimId",
                principalTable: "OperationClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_User_UserId",
                table: "UserOperationClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLink_ProfileType_ProfileTypeId",
                table: "ProfileLink");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLink_User_DeveloperId",
                table: "ProfileLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Technology_Programing_Language_Programing_LanguageId",
                table: "Technology");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_OperationClaim_OperationClaimId",
                table: "UserOperationClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_User_UserId",
                table: "UserOperationClaim");

            migrationBuilder.DropTable(
                name: "ProfileType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaim",
                table: "UserOperationClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technology",
                table: "Technology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programing_Language",
                table: "Programing_Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileLink",
                table: "ProfileLink");

            migrationBuilder.DropIndex(
                name: "IX_ProfileLink_ProfileTypeId",
                table: "ProfileLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaim",
                table: "OperationClaim");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsMailConfirmed",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfileTypeId",
                table: "ProfileLink");

            migrationBuilder.RenameTable(
                name: "UserOperationClaim",
                newName: "UserOperationClaims");

            migrationBuilder.RenameTable(
                name: "Technology",
                newName: "Technologies");

            migrationBuilder.RenameTable(
                name: "Programing_Language",
                newName: "ProgramingLanguages");

            migrationBuilder.RenameTable(
                name: "ProfileLink",
                newName: "ProfileLinks");

            migrationBuilder.RenameTable(
                name: "OperationClaim",
                newName: "OperationClaims");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "User",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "User",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "UserOperationClaims",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "UserOperationClaims",
                newName: "CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaim_UserId",
                table: "UserOperationClaims",
                newName: "IX_UserOperationClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaim_OperationClaimId",
                table: "UserOperationClaims",
                newName: "IX_UserOperationClaims_OperationClaimId");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "Technologies",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Programing_LanguageId",
                table: "Technologies",
                newName: "ProgramingLanguageId");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "Technologies",
                newName: "CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_Technology_Programing_LanguageId",
                table: "Technologies",
                newName: "IX_Technologies_ProgramingLanguageId");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "ProgramingLanguages",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "ProgramingLanguages",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "ProfileLinks",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "ProfileLinks",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "ProfileLinks",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileLink_DeveloperId",
                table: "ProfileLinks",
                newName: "IX_ProfileLinks_AppUserId");

            migrationBuilder.RenameColumn(
                name: "Update_Date",
                table: "OperationClaims",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Create_Date",
                table: "OperationClaims",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ClaimName",
                table: "OperationClaims",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ProfileType",
                table: "ProfileLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramingLanguages",
                table: "ProgramingLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileLinks",
                table: "ProfileLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLinks_AppUser_AppUserId",
                table: "ProfileLinks",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_ProgramingLanguages_ProgramingLanguageId",
                table: "Technologies",
                column: "ProgramingLanguageId",
                principalTable: "ProgramingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
