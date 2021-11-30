using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class editModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceCompanies_Companies_CompanieIdId",
                table: "InvoiceCompanies");

            migrationBuilder.RenameColumn(
                name: "CompanieIdId",
                table: "InvoiceCompanies",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceCompanies_CompanieIdId",
                table: "InvoiceCompanies",
                newName: "IX_InvoiceCompanies_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceCompanies_Companies_CompanyId",
                table: "InvoiceCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceCompanies_Companies_CompanyId",
                table: "InvoiceCompanies");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "InvoiceCompanies",
                newName: "CompanieIdId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceCompanies_CompanyId",
                table: "InvoiceCompanies",
                newName: "IX_InvoiceCompanies_CompanieIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceCompanies_Companies_CompanieIdId",
                table: "InvoiceCompanies",
                column: "CompanieIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
