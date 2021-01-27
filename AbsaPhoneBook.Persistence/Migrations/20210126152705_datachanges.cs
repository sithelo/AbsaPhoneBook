using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsaPhoneBook.Persistence.Migrations
{
    public partial class datachanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phonebooks",
                columns: table => new
                {
                    PhonebookId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonebooks", x => x.PhonebookId);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    PhonebookId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_Entries_Phonebooks_PhonebookId",
                        column: x => x.PhonebookId,
                        principalTable: "Phonebooks",
                        principalColumn: "PhonebookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Phonebooks",
                columns: new[] { "PhonebookId", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Personal" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Work" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Business" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Leisure" }
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryId", "CreatedDate", "LastModifiedDate", "Name", "PhonebookId", "Phonenumber" },
                values: new object[,]
                {
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John Bedfordview", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "07189898989" },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peter NorthCliff", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "0723333333" },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kensington Cape", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "07155555555" },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Spanish guitar hits with Manuel", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "0712222222" },
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "City Stadium", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "0747777777" },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "James Work", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PhonebookId",
                table: "Entries",
                column: "PhonebookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Phonebooks");
        }
    }
}
