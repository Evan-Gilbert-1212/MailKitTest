using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MailKitTest.Migrations
{
    public partial class CreatedEmailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sender = table.Column<string>(nullable: true),
                    EmailAddressFrom = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    EmailAddressTo = table.Column<string>(nullable: true),
                    EmailSubject = table.Column<string>(nullable: true),
                    EmailBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");
        }
    }
}
