using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.Data.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsBloked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    personConditions = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oranches = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    ShabaNumber = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timings = table.Column<int>(type: "int", nullable: false),
                    Xxpenses = table.Column<int>(type: "int", nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SubCategoryCostId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryIncomeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgetings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    personConditions = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capitals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryCosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryIncomes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creditors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creditors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debtors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debtors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debtors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    personConditions = table.Column<int>(type: "int", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    PersonConditions = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettledLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSpent = table.Column<bool>(type: "bit", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    FirstInstallmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeFrame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettledLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettledLoans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomeLists_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListExpenses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListExpenses_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubcategoryCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryCostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoryCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubcategoryCosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubcategoryCosts_CategoryCosts_CategoryCostId",
                        column: x => x.CategoryCostId,
                        principalTable: "CategoryCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubcategoryIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryIncomeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoryIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubcategoryIncomes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubcategoryIncomes_CategoryIncomes_CategoryIncomeId",
                        column: x => x.CategoryIncomeId,
                        principalTable: "CategoryIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactsId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhonNumber = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PersonConditions = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChecNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    SubcategoryCostId = table.Column<int>(type: "int", nullable: true),
                    SubcategoryIncomeId = table.Column<int>(type: "int", nullable: true),
                    MemderId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Xxpenses = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checks_Members_MemderId",
                        column: x => x.MemderId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checks_SubcategoryCosts_SubcategoryCostId",
                        column: x => x.SubcategoryCostId,
                        principalTable: "SubcategoryCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checks_SubcategoryIncomes_SubcategoryIncomeId",
                        column: x => x.SubcategoryIncomeId,
                        principalTable: "SubcategoryIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FromAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetsId = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    CapitalId = table.Column<int>(type: "int", nullable: true),
                    DebtsId = table.Column<int>(type: "int", nullable: true),
                    FundsId = table.Column<int>(type: "int", nullable: true),
                    PersonsId = table.Column<int>(type: "int", nullable: true),
                    CreditorsId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryIncomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FromAccounts_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FromAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FromAccounts_Capitals_CapitalId",
                        column: x => x.CapitalId,
                        principalTable: "Capitals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FromAccounts_Creditors_CreditorsId",
                        column: x => x.CreditorsId,
                        principalTable: "Creditors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FromAccounts_Debts_DebtsId",
                        column: x => x.DebtsId,
                        principalTable: "Debts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FromAccounts_Funds_FundsId",
                        column: x => x.FundsId,
                        principalTable: "Funds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FromAccounts_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FromAccounts_SubcategoryIncomes_SubCategoryIncomeId",
                        column: x => x.SubCategoryIncomeId,
                        principalTable: "SubcategoryIncomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Criticisms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SubcategoryCostId = table.Column<int>(type: "int", nullable: true),
                    SubcategoryIncomeId = table.Column<int>(type: "int", nullable: true),
                    MemderId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Xxpenses = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FromAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criticisms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criticisms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criticisms_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criticisms_FromAccounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "FromAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criticisms_Members_MemderId",
                        column: x => x.MemderId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criticisms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criticisms_SubcategoryCosts_SubcategoryCostId",
                        column: x => x.SubcategoryCostId,
                        principalTable: "SubcategoryCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Criticisms_SubcategoryIncomes_SubcategoryIncomeId",
                        column: x => x.SubcategoryIncomeId,
                        principalTable: "SubcategoryIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a2f20316-520f-44c9-b88f-77457bf3096e", "admin@example.com", true, "Admin", true, false, "User", false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEBqkkKahNjNVf1P97tIhVDl2qfuJjst37cxHGQ4H+p9+00yq+TxIjb2BRp7pYfkE6w==", "1234567890", false, 1, "8a381403-4670-41aa-85e7-8d8f47931b27", false, "admin" },
                    { 2, 0, "97d39508-2c2f-458b-90de-6e61fd808928", "employee@example.com", true, "Employee", true, false, "User", false, null, "EMPLOYEE@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAEPQ9bjQ331y1/5TIM9PWp5hNBWr9FxEU0/OXISVhPPXV1LMOHXAmtWempL90X4e5/A==", "0987654321", false, 2, "c0863d64-831b-4c86-9715-3b4a815d2af3", false, "employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "CategoryCosts",
                columns: new[] { "Id", "IsPublic", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, true, "اغذیه", 1 },
                    { 2, true, "مسکن", 1 },
                    { 3, true, "البسه و پوشاک", 1 },
                    { 4, true, "خودرو", 1 },
                    { 5, true, "ایاب و ذهاب مسافرت", 1 },
                    { 6, true, "اموزش و تحصیلات", 1 },
                    { 7, true, "فرهنگی و سرگرمی", 1 },
                    { 8, true, "هدایا", 1 },
                    { 9, true, "بهداشتی درمانی", 1 },
                    { 10, true, "هزینه های اداری", 1 },
                    { 11, true, "دیون اسلامی", 1 },
                    { 12, true, "سرمایه گزاری", 1 }
                });

            migrationBuilder.InsertData(
                table: "CategoryIncomes",
                columns: new[] { "Id", "IsPublic", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, true, "حقوق", 1 },
                    { 2, true, "فروش", 1 },
                    { 3, true, "سود سرمایه", 1 },
                    { 4, true, "یارانه و هدایا", 1 },
                    { 5, true, "درآمد اجاره", 1 }
                });

            migrationBuilder.InsertData(
                table: "Funds",
                columns: new[] { "Id", "Amount", "IsDeleted", "IsPublic", "Name", "PersonConditions", "UserId" },
                values: new object[,]
                {
                    { 1, 0m, false, true, "کیف پول", 0, 1 },
                    { 2, 0m, false, true, "گاو صندوق", 0, 1 },
                    { 3, 0m, false, true, " منزل", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "SubcategoryCosts",
                columns: new[] { "Id", "Amount", "CategoryCostId", "IsPublic", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 10000000m, 1, true, "تنقلات", 1 },
                    { 2, 10000000m, 1, true, "گوشت قرمز", 1 },
                    { 3, 10000000m, 1, true, "مرغ", 1 },
                    { 4, 10000000m, 1, true, "ماهی و میگو", 1 },
                    { 5, 10000000m, 1, true, "برنج", 1 },
                    { 6, 10000000m, 1, true, "نان", 1 },
                    { 7, 10000000m, 1, true, "لبنیات", 1 },
                    { 8, 10000000m, 1, true, "نوشیدنی", 1 },
                    { 9, 10000000m, 1, true, "حبوبات", 1 },
                    { 10, 10000000m, 1, true, "غلات", 1 },
                    { 11, 10000000m, 1, true, "میوه و تره بار", 1 },
                    { 12, 10000000m, 1, true, "غذای بیرون", 1 },
                    { 13, 10000000m, 1, true, "رستوران", 1 },
                    { 14, 10000000m, 1, true, "کافی شاپ", 1 },
                    { 15, 10000000m, 1, true, "سایر", 1 },
                    { 16, 10000000m, 2, true, "قبض اب", 1 },
                    { 17, 10000000m, 2, true, "قبض برق", 1 },
                    { 18, 10000000m, 2, true, "قبض گاز", 1 },
                    { 19, 10000000m, 2, true, "قبض تلفن", 1 },
                    { 20, 10000000m, 2, true, "شارژ ساختمان", 1 },
                    { 21, 10000000m, 2, true, "اجاره منزل", 1 },
                    { 22, 10000000m, 2, true, "لوازم منزل", 1 },
                    { 23, 10000000m, 2, true, "قبض شارژ موبایل", 1 },
                    { 24, 10000000m, 2, true, "بیمه ساختمان", 1 },
                    { 25, 10000000m, 2, true, "تعمیرات ساختمان", 1 },
                    { 26, 10000000m, 2, true, "عوارض شهرداری", 1 },
                    { 27, 10000000m, 2, true, "مالیات", 1 },
                    { 28, 10000000m, 2, true, "سایر", 1 },
                    { 29, 10000000m, 3, true, "خیاطی", 1 },
                    { 30, 10000000m, 3, true, "خرید پوشاک", 1 },
                    { 31, 10000000m, 3, true, "خشکشویی", 1 },
                    { 32, 10000000m, 3, true, "سایر", 1 },
                    { 33, 10000000m, 4, true, "بنزین", 1 },
                    { 34, 10000000m, 4, true, "تعویض روغن", 1 },
                    { 35, 10000000m, 4, true, "جرایم رانندگی", 1 },
                    { 36, 10000000m, 4, true, "طرح ترافیک", 1 },
                    { 37, 10000000m, 4, true, "پارکینگ", 1 },
                    { 38, 10000000m, 4, true, "بیمه ثالث", 1 },
                    { 39, 10000000m, 4, true, "بیمه بدنه", 1 },
                    { 40, 10000000m, 4, true, "تغییرات اساسی", 1 },
                    { 41, 10000000m, 4, true, "عوارض خودرو", 1 },
                    { 42, 10000000m, 4, true, "سایر", 1 },
                    { 43, 10000000m, 5, true, "کرایه اژانس", 1 },
                    { 44, 10000000m, 5, true, "کرایه تاکسی", 1 },
                    { 45, 10000000m, 5, true, "کرایه اتوبوس", 1 },
                    { 46, 10000000m, 5, true, "کرایه مترو", 1 },
                    { 47, 10000000m, 5, true, "سرویس", 1 },
                    { 48, 10000000m, 5, true, "بلیط قطار", 1 },
                    { 49, 10000000m, 5, true, "بلیط هواپیما", 1 },
                    { 50, 10000000m, 5, true, "بلیط اتوبوس", 1 },
                    { 51, 10000000m, 5, true, "کرایه هتل و محل اقامت", 1 },
                    { 52, 10000000m, 6, true, "کلاس های ورزشی", 1 },
                    { 53, 10000000m, 6, true, "شهریه مدرسه", 1 },
                    { 54, 10000000m, 6, true, "شهریه دانشگاه", 1 },
                    { 55, 10000000m, 6, true, "شهریه مهد کودک", 1 },
                    { 56, 10000000m, 6, true, "لوازم التحریر", 1 },
                    { 57, 10000000m, 6, true, "کلاس های آموزش", 1 },
                    { 58, 10000000m, 6, true, "سایر", 1 },
                    { 59, 10000000m, 7, true, "نرم افزار", 1 },
                    { 60, 10000000m, 7, true, "کتاب", 1 },
                    { 61, 10000000m, 7, true, "روزنامه و مجله", 1 },
                    { 62, 10000000m, 7, true, "فیلم", 1 },
                    { 63, 10000000m, 7, true, "سینما", 1 },
                    { 64, 10000000m, 7, true, "موسیقی", 1 },
                    { 65, 10000000m, 7, true, "تیاتر", 1 },
                    { 66, 10000000m, 7, true, "کنسرت", 1 },
                    { 67, 10000000m, 7, true, "اینترنت", 1 },
                    { 68, 10000000m, 7, true, "بازی و سرگرمی", 1 },
                    { 69, 10000000m, 7, true, "اماكن فرهنگی", 1 },
                    { 70, 10000000m, 7, true, "سایر", 1 },
                    { 71, 10000000m, 8, true, "سوغات", 1 },
                    { 72, 10000000m, 8, true, "فرهنگی", 1 },
                    { 73, 10000000m, 8, true, "لوازم", 1 },
                    { 74, 10000000m, 8, true, "سایر", 1 },
                    { 75, 10000000m, 9, true, "ویزیت پزشک", 1 },
                    { 76, 10000000m, 9, true, "لوازم بهداشتی", 1 },
                    { 77, 10000000m, 9, true, "لوازم ارایشی", 1 },
                    { 78, 10000000m, 9, true, "لوازم پزشکی", 1 },
                    { 79, 10000000m, 9, true, "دندان پزشکی", 1 },
                    { 80, 10000000m, 9, true, "جراحی", 1 },
                    { 81, 10000000m, 9, true, "بستری", 1 },
                    { 82, 10000000m, 9, true, "آزمایشگاه", 1 },
                    { 83, 10000000m, 9, true, "تصویر برداری", 1 },
                    { 84, 10000000m, 9, true, "دارو", 1 },
                    { 85, 10000000m, 9, true, "بیمه ها", 1 },
                    { 86, 10000000m, 9, true, "سایر", 1 },
                    { 87, 10000000m, 10, true, "هزینه های تشکیل پرونده", 1 },
                    { 88, 10000000m, 10, true, "هزینه دادرسی", 1 },
                    { 89, 10000000m, 10, true, "هزینه پست", 1 },
                    { 90, 10000000m, 10, true, "هزینه مشاور", 1 },
                    { 91, 10000000m, 10, true, "هزینه دعاوی", 1 },
                    { 92, 10000000m, 10, true, "هزینه ثبت نام در کارگاه", 1 },
                    { 93, 10000000m, 10, true, "سایر", 1 },
                    { 94, 10000000m, 11, true, "زکات", 1 },
                    { 95, 10000000m, 11, true, "خمس", 1 },
                    { 96, 10000000m, 11, true, "صدقه", 1 },
                    { 97, 10000000m, 11, true, "کفاره", 1 },
                    { 98, 10000000m, 11, true, "نذری", 1 },
                    { 99, 10000000m, 11, true, "وقف", 1 },
                    { 100, 10000000m, 11, true, "سایر دیون اسلامی", 1 },
                    { 101, 10000000m, 12, true, "سهام", 1 },
                    { 102, 10000000m, 12, true, "اوراق قرضه", 1 },
                    { 103, 10000000m, 12, true, "سرمایه گذاری در املاک", 1 },
                    { 104, 10000000m, 12, true, "سرمایه گذاری در ارز", 1 },
                    { 105, 10000000m, 12, true, "سرمایه گذاری در طلا", 1 },
                    { 106, 10000000m, 12, true, "سرمایه گذاری در کریپتوکارنسی", 1 },
                    { 107, 10000000m, 12, true, "سرمایه گذاری در صندوق های سرمایه گذاری", 1 },
                    { 108, 10000000m, 12, true, "سایر سرمایه گذاری ها", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubcategoryIncomes",
                columns: new[] { "Id", "Amount", "CategoryIncomeId", "IsPublic", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 10000000m, 1, true, "حقوق ماهیانه", 1 },
                    { 2, 10000000m, 1, true, "عیدی", 1 },
                    { 3, 10000000m, 1, true, "پاداش", 1 },
                    { 4, 10000000m, 1, true, "مزایا", 1 },
                    { 5, 10000000m, 1, true, "سایر حقوق", 1 },
                    { 6, 10000000m, 2, true, "لوازم", 1 },
                    { 7, 10000000m, 2, true, "مسکن", 1 },
                    { 8, 10000000m, 2, true, "خودرو", 1 },
                    { 9, 10000000m, 2, true, "سایر فروش", 1 },
                    { 10, 10000000m, 3, true, "سود سپرده بانکی", 1 },
                    { 11, 10000000m, 3, true, "سود اوراق مشارکت", 1 },
                    { 12, 10000000m, 3, true, "سود سهام", 1 },
                    { 13, 10000000m, 3, true, "سایر سود سرمایه", 1 },
                    { 14, 10000000m, 4, true, "یارانه نقدی", 1 },
                    { 15, 10000000m, 4, true, "هدیه", 1 },
                    { 16, 10000000m, 4, true, "سایر یارانه و هدایا", 1 },
                    { 17, 10000000m, 5, true, "اجاره آپارتمان", 1 },
                    { 18, 10000000m, 5, true, "اجاره مغازه", 1 },
                    { 19, 10000000m, 5, true, "اجاره شرکت", 1 },
                    { 20, 10000000m, 5, true, "سایر درآمد اجاره", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_UserId",
                table: "Banks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgetings_UserId",
                table: "Budgetings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Capitals_UserId",
                table: "Capitals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCosts_UserId",
                table: "CategoryCosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryIncomes_UserId",
                table: "CategoryIncomes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_BankId",
                table: "Checks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_EventId",
                table: "Checks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_MemderId",
                table: "Checks",
                column: "MemderId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_ProjectId",
                table: "Checks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_SubcategoryCostId",
                table: "Checks",
                column: "SubcategoryCostId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_SubcategoryIncomeId",
                table: "Checks",
                column: "SubcategoryIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_UserId",
                table: "Checks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Creditors_UserId",
                table: "Creditors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Criticisms_EventId",
                table: "Criticisms",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Criticisms_FromAccountId",
                table: "Criticisms",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Criticisms_MemderId",
                table: "Criticisms",
                column: "MemderId");

            migrationBuilder.CreateIndex(
                name: "IX_Criticisms_ProjectId",
                table: "Criticisms",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Criticisms_SubcategoryCostId",
                table: "Criticisms",
                column: "SubcategoryCostId");

            migrationBuilder.CreateIndex(
                name: "IX_Criticisms_SubcategoryIncomeId",
                table: "Criticisms",
                column: "SubcategoryIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Criticisms_UserId",
                table: "Criticisms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_UserId",
                table: "Debtors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_UserId",
                table: "Debts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_AssetsId",
                table: "FromAccounts",
                column: "AssetsId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_BankId",
                table: "FromAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_CapitalId",
                table: "FromAccounts",
                column: "CapitalId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_CreditorsId",
                table: "FromAccounts",
                column: "CreditorsId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_DebtsId",
                table: "FromAccounts",
                column: "DebtsId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_FundsId",
                table: "FromAccounts",
                column: "FundsId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_PersonsId",
                table: "FromAccounts",
                column: "PersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_FromAccounts_SubCategoryIncomeId",
                table: "FromAccounts",
                column: "SubCategoryIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Funds_UserId",
                table: "Funds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeLists_BankId",
                table: "IncomeLists",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeLists_UserId",
                table: "IncomeLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListExpenses_BankId",
                table: "ListExpenses",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_ListExpenses_UserId",
                table: "ListExpenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ContactsId",
                table: "Persons",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SettledLoans_UserId",
                table: "SettledLoans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryCosts_CategoryCostId",
                table: "SubcategoryCosts",
                column: "CategoryCostId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryCosts_UserId",
                table: "SubcategoryCosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryIncomes_CategoryIncomeId",
                table: "SubcategoryIncomes",
                column: "CategoryIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryIncomes_UserId",
                table: "SubcategoryIncomes",
                column: "UserId");
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
                name: "Budgetings");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropTable(
                name: "Criticisms");

            migrationBuilder.DropTable(
                name: "Debtors");

            migrationBuilder.DropTable(
                name: "IncomeLists");

            migrationBuilder.DropTable(
                name: "ListExpenses");

            migrationBuilder.DropTable(
                name: "SettledLoans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "FromAccounts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SubcategoryCosts");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Capitals");

            migrationBuilder.DropTable(
                name: "Creditors");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "Funds");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "SubcategoryIncomes");

            migrationBuilder.DropTable(
                name: "CategoryCosts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CategoryIncomes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
