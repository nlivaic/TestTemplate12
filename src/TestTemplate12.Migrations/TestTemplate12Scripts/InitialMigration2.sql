BEGIN TRANSACTION;
DROP INDEX [IX_InboxState_MessageId_ConsumerId] ON [InboxState];

ALTER TABLE [OutboxState] ADD [LockId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

ALTER TABLE [OutboxState] ADD [RowVersion] rowversion NULL;

ALTER TABLE [OutboxMessage] ADD [MessageType] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [InboxState] ADD [LockId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

ALTER TABLE [InboxState] ADD [RowVersion] rowversion NULL;

ALTER TABLE [InboxState] ADD CONSTRAINT [AK_InboxState_MessageId_ConsumerId] UNIQUE ([MessageId], [ConsumerId]);

ALTER TABLE [OutboxMessage] ADD CONSTRAINT [FK_OutboxMessage_InboxState_InboxMessageId_InboxConsumerId] FOREIGN KEY ([InboxMessageId], [InboxConsumerId]) REFERENCES [InboxState] ([MessageId], [ConsumerId]);

ALTER TABLE [OutboxMessage] ADD CONSTRAINT [FK_OutboxMessage_OutboxState_OutboxId] FOREIGN KEY ([OutboxId]) REFERENCES [OutboxState] ([OutboxId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241201172929_InitialMigration2', N'9.0.0');

COMMIT;
GO

