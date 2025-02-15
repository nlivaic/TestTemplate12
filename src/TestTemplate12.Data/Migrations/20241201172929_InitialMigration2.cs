using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTemplate12.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InboxState_MessageId_ConsumerId",
                table: "InboxState");

            migrationBuilder.AddColumn<Guid>(
                name: "LockId",
                table: "OutboxState",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OutboxState",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageType",
                table: "OutboxMessage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "LockId",
                table: "InboxState",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InboxState",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InboxState_MessageId_ConsumerId",
                table: "InboxState",
                columns: new[] { "MessageId", "ConsumerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OutboxMessage_InboxState_InboxMessageId_InboxConsumerId",
                table: "OutboxMessage",
                columns: new[] { "InboxMessageId", "InboxConsumerId" },
                principalTable: "InboxState",
                principalColumns: new[] { "MessageId", "ConsumerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OutboxMessage_OutboxState_OutboxId",
                table: "OutboxMessage",
                column: "OutboxId",
                principalTable: "OutboxState",
                principalColumn: "OutboxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutboxMessage_InboxState_InboxMessageId_InboxConsumerId",
                table: "OutboxMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_OutboxMessage_OutboxState_OutboxId",
                table: "OutboxMessage");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_InboxState_MessageId_ConsumerId",
                table: "InboxState");

            migrationBuilder.DropColumn(
                name: "LockId",
                table: "OutboxState");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OutboxState");

            migrationBuilder.DropColumn(
                name: "MessageType",
                table: "OutboxMessage");

            migrationBuilder.DropColumn(
                name: "LockId",
                table: "InboxState");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InboxState");

            migrationBuilder.CreateIndex(
                name: "IX_InboxState_MessageId_ConsumerId",
                table: "InboxState",
                columns: new[] { "MessageId", "ConsumerId" },
                unique: true);
        }
    }
}
