using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TSC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SYS3");

            migrationBuilder.EnsureSchema(
                name: "BSE");

            migrationBuilder.CreateTable(
                name: "Lookup",
                schema: "SYS3",
                columns: table => new
                {
                    LookupID = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    DisplayOrderDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExtraText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclineAccess = table.Column<bool>(type: "bit", nullable: true),
                    PermitNeed = table.Column<bool>(type: "bit", nullable: true),
                    FaildProcessing = table.Column<bool>(type: "bit", nullable: true),
                    CompleteProcessing = table.Column<bool>(type: "bit", nullable: true),
                    OnProcessing = table.Column<bool>(type: "bit", nullable: true),
                    CanEdit = table.Column<bool>(type: "bit", nullable: true),
                    CanDelete = table.Column<bool>(type: "bit", nullable: true),
                    Disable = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.LookupID);
                });

            migrationBuilder.CreateTable(
                name: "Party",
                schema: "BSE",
                columns: table => new
                {
                    PartyID = table.Column<long>(type: "bigint", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(101)", maxLength: 101, nullable: true, computedColumnSql: "(case [Type] when (0) then ([FirstName]+N' ')+[LastName] else [CompanyName] end)", stored: false),
                    Tel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    EducationDegree = table.Column<int>(type: "int", nullable: true),
                    MarriageDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthPlaceRef = table.Column<long>(type: "bigint", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IssuanceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IssuancePlaceRef = table.Column<long>(type: "bigint", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Abbreviation = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    EconomicCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CompanyType = table.Column<int>(type: "int", nullable: true),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    FirstName_EN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName_EN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullName_EN = table.Column<string>(type: "nvarchar(101)", maxLength: 101, nullable: true, computedColumnSql: "(case [Type] when (0) then ([FirstName_EN]+N' ')+[LastName_EN] else [CompanyName_EN] end)", stored: false),
                    CompanyName_EN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Creator = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifier = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BSE_Party", x => x.PartyID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "BSE",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PartyRef = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BrowserData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CookieData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password_History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordIsChanged = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    AppLogin = table.Column<bool>(type: "bit", nullable: true),
                    AppLogin_DateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AppLogin_Update_DateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AppBearerToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppMacLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPValid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Modify_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remove = table.Column<bool>(type: "bit", nullable: true),
                    Remove_DateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Co_Users", x => x.UserID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lookup",
                schema: "SYS3");

            migrationBuilder.DropTable(
                name: "Party",
                schema: "BSE");

            migrationBuilder.DropTable(
                name: "User",
                schema: "BSE");
        }
    }
}
