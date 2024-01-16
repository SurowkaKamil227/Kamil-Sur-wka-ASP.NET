using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    LibraryAdress_City = table.Column<string>(type: "TEXT", nullable: true),
                    LibraryAdress_Street = table.Column<string>(type: "TEXT", nullable: true),
                    LibraryAdress_PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: true),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Adress_PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Page_No = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    publication_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PublishingHouse = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    LibraryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BorrowDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    LibraryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrows_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a7e5705-0a0f-4e38-b169-f7c4d32a8cb4", "33af9030-02b1-406c-ae3e-7958d95ccfc0", "user", "USER" },
                    { "c860a04c-159b-440f-9096-c3e15377d9bb", "c860a04c-159b-440f-9096-c3e15377d9bb", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2b9da503-60ce-4adc-98df-2eac570a99af", 0, "c2c366af-b80f-4228-9d01-d0a8040e8322", "anna@przyklad.pl", true, false, null, "ANNA@PRZYKLAD.PL", "ANNA@PRZYKLAD.PL", "AQAAAAEAACcQAAAAEEK+CB6OX31wpFZDFI2Wg92cUyV9hDGSbJRObueC10ih9YOe3+siBYITJ1P48dCYSw==", null, false, "4e9dcf0c-a050-4a97-9264-f9fb002bc6e0", false, "anna@przyklad.pl" },
                    { "37a02f36-d78d-42d4-8871-2ff93b99295f", 0, "159b1db8-8909-4dbc-b097-60ec7f2e6213", "adminek@wp.pl", true, false, null, null, null, "AQAAAAEAACcQAAAAEDHnadnmu1Wk2jjH1Ihh22QiHH5KfczOtUKEbrnJm7Pk1ejyjXIAKRGKrTcEJ3eXmw==", null, false, "0538abd0-8dd3-4133-a8a3-370e87ce78af", false, "adminek@wp.pl" },
                    { "638eccae-d4c4-4190-9135-a2008e5ac012", 0, "55e7e9c4-c80a-4ea6-8836-e8f3ea7135ae", "jan@przyklad.pl", true, false, null, "JAN@PRZYKLAD.PL", "JAN@PRZYKLAD.PL", "AQAAAAEAACcQAAAAEKrg5U/g6gFBegAY43SpR4b6wtIMIv0vUiZaPXLm8nqmlfUWAU4Mw3rUqg/Jf5j+mQ==", null, false, "652de4b8-d973-4b22-8dc5-4ce41b900441", false, "jan@przyklad.pl" },
                    { "9b40da3d-39aa-453f-b41e-e497cced4a01", 0, "38db338c-2c81-48cc-b9a5-146f841648d1", "test@test.pl", true, false, null, "TEST@TEST.PL", "TEST@TEST.PL", "AQAAAAEAACcQAAAAELJOUBFjb/4KcG/EGuSMZan/tPs5TpHhTujZt/1iPjh2EzW3iLe821bHWUof7SrIWQ==", null, false, "d674a31d-4026-42e2-b668-6be4316d5e37", false, "test@test.pl" },
                    { "e32d1328-313d-43d0-b1af-42eb24deee58", 0, "fe5bffb1-8ab7-4111-8086-ec847b232889", "kasia@przyklad.pl", true, false, null, "KASIA@PRZYKLAD.PL", "KASIA@PRZYKLAD.PL", "AQAAAAEAACcQAAAAEFu5aDDeUhl1gjkZj/PDxT3wMsZgbhI01kQ++JOs+ngMnoAN14Fmi6jt3sHmML0gBA==", null, false, "4e05640b-cde0-4468-b017-467b42839976", false, "kasia@przyklad.pl" }
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "LibraryAdress_City", "LibraryAdress_PostalCode", "LibraryAdress_Street", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, "Główna biblioteka na terenie Wyższej Szkoły Ekonomii i Informatyki", "Biblioteka Główna WSEI" },
                    { 2, null, null, null, "Biblioteka publiczna przy Polsko-Japońskiej Akademii Technik Komputerowych", "Biblioteka Publiczna PJTAK" },
                    { 3, null, null, null, "Biblioteka korporacyjna ABB", "Biblioteka ABB" },
                    { 4, null, null, null, "Biblioteka szkolna przy Technikum Informatycznym w Poznaniu", "Biblioteka Technikum Informatycznego w Poznaniu" }
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Description", "Name", "Adress_City", "Adress_PostalCode", "Adress_Street" },
                values: new object[,]
                {
                    { 1, "Uczelnia", "WSEI", "Kraków", "31-150", "Św. Filipa 17" },
                    { 2, "Uczelnia", "PJTAK", "Warszawa", "00-001", "Aleje Jerozolimskie 120" },
                    { 3, "Korporacja", "ABB", "Gdańsk", "80-001", "ul. Długa 10" },
                    { 4, "Szkoła średnia", "Technikum Informatyczne w Poznaniu", "Poznań", "61-001", "Stary Rynek 1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4a7e5705-0a0f-4e38-b169-f7c4d32a8cb4", "2b9da503-60ce-4adc-98df-2eac570a99af" },
                    { "4a7e5705-0a0f-4e38-b169-f7c4d32a8cb4", "638eccae-d4c4-4190-9135-a2008e5ac012" },
                    { "c860a04c-159b-440f-9096-c3e15377d9bb", "9b40da3d-39aa-453f-b41e-e497cced4a01" },
                    { "4a7e5705-0a0f-4e38-b169-f7c4d32a8cb4", "e32d1328-313d-43d0-b1af-42eb24deee58" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Created", "ISBN", "LibraryId", "Page_No", "Priority", "publication_date", "PublishingHouse", "Title" },
                values: new object[,]
                {
                    { 1, "Bolesław Prus", new DateTime(2024, 1, 2, 11, 38, 52, 480, DateTimeKind.Local).AddTicks(519), "1234567890", 1, "800", 1, new DateTime(1890, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wydawnictwo Epoka", "Lalka" },
                    { 2, "Adam Mickiewicz", new DateTime(2024, 1, 2, 11, 38, 52, 480, DateTimeKind.Local).AddTicks(569), "2345678901", 1, "340", 1, new DateTime(1834, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wydawnictwo Narodowe", "Pan Tadeusz" },
                    { 3, "Witold Gombrowicz", new DateTime(2024, 1, 2, 11, 38, 52, 480, DateTimeKind.Local).AddTicks(579), "3456789012", 1, "300", 1, new DateTime(1937, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wydawnictwo Literackie", "Ferdydurke" },
                    { 4, "Eliza Orzeszkowa", new DateTime(2024, 1, 2, 11, 38, 52, 480, DateTimeKind.Local).AddTicks(587), "4567890123", 1, "450", 1, new DateTime(1888, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wydawnictwo Zielona Sowa", "Nad Niemnem" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Created", "Email", "Name", "OrganizationId", "Phone", "Priority" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 2, 11, 38, 52, 480, DateTimeKind.Local).AddTicks(596), "adam@wsei.edu.pl", "Adam", 1, "127813268163", 1 },
                    { 2, new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 2, 11, 38, 52, 480, DateTimeKind.Local).AddTicks(599), "ewa@wsei.edu.pl", "Ewa", 3, "293443823478", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_LibraryId",
                table: "books",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_LibraryId",
                table: "Borrows",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_UserId",
                table: "Borrows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
