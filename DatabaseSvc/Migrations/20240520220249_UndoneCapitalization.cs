using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSvc.Migrations
{
    /// <inheritdoc />
    public partial class UndoneCapitalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Geos_Addresses_AddressUserId",
                table: "Geos");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Users",
                newName: "website");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "Geos",
                newName: "lng");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "Geos",
                newName: "lat");

            migrationBuilder.RenameColumn(
                name: "AddressUserId",
                table: "Geos",
                newName: "AddressUserid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CatchPhrase",
                table: "Companies",
                newName: "catchPhrase");

            migrationBuilder.RenameColumn(
                name: "Bs",
                table: "Companies",
                newName: "bs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Companies",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Addresses",
                newName: "zipcode");

            migrationBuilder.RenameColumn(
                name: "Suite",
                table: "Addresses",
                newName: "suite");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Addresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Addresses",
                newName: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_Userid",
                table: "Addresses",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_Userid",
                table: "Companies",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Geos_Addresses_AddressUserid",
                table: "Geos",
                column: "AddressUserid",
                principalTable: "Addresses",
                principalColumn: "Userid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_Userid",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_Userid",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Geos_Addresses_AddressUserid",
                table: "Geos");

            migrationBuilder.RenameColumn(
                name: "website",
                table: "Users",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "lng",
                table: "Geos",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "lat",
                table: "Geos",
                newName: "Lat");

            migrationBuilder.RenameColumn(
                name: "AddressUserid",
                table: "Geos",
                newName: "AddressUserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Companies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "catchPhrase",
                table: "Companies",
                newName: "CatchPhrase");

            migrationBuilder.RenameColumn(
                name: "bs",
                table: "Companies",
                newName: "Bs");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Companies",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "zipcode",
                table: "Addresses",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "suite",
                table: "Addresses",
                newName: "Suite");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Addresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Addresses",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Geos_Addresses_AddressUserId",
                table: "Geos",
                column: "AddressUserId",
                principalTable: "Addresses",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
