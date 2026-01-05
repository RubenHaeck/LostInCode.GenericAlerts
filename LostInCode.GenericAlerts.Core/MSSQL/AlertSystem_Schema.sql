-- Alert configuraties per entiteit/grid
CREATE TABLE AlertSubscriptions (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId NVARCHAR(450) NOT NULL,
    EntityType NVARCHAR(100) NOT NULL, -- Bijv: "Order", "Customer", "Invoice"
    EntityFilter NVARCHAR(MAX), -- JSON filter voor specifieke items
    Frequency INT NOT NULL, -- 0=Instant, 1=Daily, 2=Weekly
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    LastSentAt DATETIME2 NULL,
    NotificationEmail NVARCHAR(256) NOT NULL,
    CONSTRAINT FK_AlertSubscriptions_Users FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);

-- Log van wijzigingen per entiteit
CREATE TABLE EntityChanges (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    EntityType NVARCHAR(100) NOT NULL,
    EntityId NVARCHAR(100) NOT NULL,
    ChangeType NVARCHAR(20) NOT NULL, -- Create, Update, Delete
    ChangedBy NVARCHAR(450) NOT NULL,
    ChangedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ChangeData NVARCHAR(MAX), -- JSON met details van wijziging
    IsProcessed BIT NOT NULL DEFAULT 0,
    ProcessedAt DATETIME2 NULL
);

CREATE INDEX IX_EntityChanges_NotProcessed 
ON EntityChanges(EntityType, IsProcessed, ChangedAt);

CREATE INDEX IX_AlertSubscriptions_Active 
ON AlertSubscriptions(EntityType, IsActive, Frequency);