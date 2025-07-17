USE DineEaseDB;

CREATE TABLE [dbo].[FoodProduct] (
    [ProductID]   INT             NOT NULL,
    [ProductName] VARCHAR(100)    NULL,
    [Category]    VARCHAR(50)     NULL,
    [Price]       DECIMAL(10, 2)  NULL,
    [Description] TEXT            NULL,
    [Image]       VARBINARY(MAX)  NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [OrderID]      INT             IDENTITY (1, 1) NOT NULL,
    [CustomerName] NVARCHAR(100)   NOT NULL,
    [ProductName]  NVARCHAR(100)   NOT NULL,
    [Price]        DECIMAL(10, 2)  NOT NULL,
    [Quantity]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

CREATE TABLE [dbo].[menu] (
    [name]        VARCHAR(50),
    [addFor]      VARCHAR(50),
    [price]       DECIMAL(10, 2),
    [description] VARCHAR(255),
    [imagePath]   NVARCHAR(500)
);

-- OPTIONAL: Add Users table
CREATE TABLE [dbo].[Users] (
    [UserID]   INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50),
    [Password] NVARCHAR(255),
    [Email]    NVARCHAR(100),
    [Role]     NVARCHAR(50) -- 'Admin' or 'User'
);
CREATE TABLE Admin (
    AdminID INT PRIMARY KEY IDENTITY,
    CanteenID NVARCHAR(50),
    OwnerName NVARCHAR(100),
    ContactNumber NVARCHAR(20),
    ValidTill DATE,
    TotalRevenue DECIMAL(10, 2)
);

