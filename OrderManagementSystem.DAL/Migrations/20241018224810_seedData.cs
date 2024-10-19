using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                        INSERT INTO [People].[Users]
                                ([Id],[UserName],[Email],[PasswordHash],[IsAdmin],[Salt],[FullName],[CreatedDate]
                                ,[AddedBy],[ModifiedDate],[ModifiedBy],[IsDeleted],[IsActive],[DeletedDate],[DeletedBy])
                                VALUES('762751A8-B808-4FD5-BED7-4FD53D004276','admin','admin@admin.com','N9XwlxE2w6foFcp2dttCQA=='
                                ,1,'n1xdl54xsefeghk9z3xodibpmctoneyj','Admin',GETDATE(),null,null,null,0,1,null,null)
                                GO
                                INSERT [People].[Users] ([Id], [UserName], [Email], [PasswordHash], [IsAdmin], [Salt], [FullName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'eef5a089-f6b6-4edf-8b51-bb45308e3524', N'user1', N'user1@user.com', N'N9XwlxE2w6foFcp2dttCQA==', 0, N'n1xdl54xsefeghk9z3xodibpmctoneyj', N'مستخدم 1', CAST(N'2024-10-19T01:00:42.6321385' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [People].[Users] ([Id], [UserName], [Email], [PasswordHash], [IsAdmin], [Salt], [FullName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'fec652e4-b472-4348-8a4f-c30e491573d6', N'user2', N'user2@user.com', N'N9XwlxE2w6foFcp2dttCQA==', 0, N'n1xdl54xsefeghk9z3xodibpmctoneyj', N'مستخدم 2', CAST(N'2024-10-19T01:03:10.2980616' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [People].[Customers] ([Id], [Name], [Email], [Phone], [Address], [DateOfBirth], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'79c35a6d-1ab9-40f5-9708-7091f511d0df', N'Customer 1', N'customer1@customer.com', N'641651', N'Egypt', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-19T02:46:52.4550037' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [People].[Customers] ([Id], [Name], [Email], [Phone], [Address], [DateOfBirth], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'a9e24ef1-8efa-438f-82b0-be0e354347b6', N'Customer 2', N'customer2@customer.com', N'684630646', N'UAE', CAST(N'2024-10-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-19T12:50:19.5574937' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', CAST(N'2024-10-19T12:50:29.6890553' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', 1, 1, CAST(N'2024-10-19T12:52:24.0033818' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276')
                                GO
                                INSERT [People].[Customers] ([Id], [Name], [Email], [Phone], [Address], [DateOfBirth], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c491540c-5088-4d96-8bf2-ef8b387a750d', N'Customer 3', N'customer3@customer.com', N'64161648', N'SA', CAST(N'2024-10-19T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-19T01:05:20.2359403' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'620e9f44-41fb-431d-966b-29a521c46802', N'منتج 6 ', CAST(80.00 AS Decimal(18, 2)), 9, N'fec652e4-b472-4348-8a4f-c30e491573d6', CAST(N'2024-10-19T01:18:40.1971941' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'f400edff-76e5-4ef1-bfc7-59612588f2d3', N'منتج 1', CAST(10.00 AS Decimal(18, 2)), 400, N'fec652e4-b472-4348-8a4f-c30e491573d6', CAST(N'2024-10-19T00:51:13.9977402' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', CAST(N'2024-10-19T00:56:10.9342842' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'620ec223-3e74-4d83-a5c2-6749318c1d38', N'منتج 8 ', CAST(50.00 AS Decimal(18, 2)), 96, N'fec652e4-b472-4348-8a4f-c30e491573d6', CAST(N'2024-10-19T01:19:05.2500112' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'46db9fc1-3253-44fa-b2b4-8d8f5e1fa256', N'منتج 2', CAST(100.00 AS Decimal(18, 2)), 50, N'fec652e4-b472-4348-8a4f-c30e491573d6', CAST(N'2024-10-19T00:56:38.8970984' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'95d86804-3316-4e7e-b13b-8ee2373b8f89', N'منتج 5', CAST(12.00 AS Decimal(18, 2)), 50, N'eef5a089-f6b6-4edf-8b51-bb45308e3524', CAST(N'2024-10-19T01:18:22.4227122' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'6545c6b3-beaf-44f8-acd4-97137eccd234', N'منتج 3', CAST(500.00 AS Decimal(18, 2)), 5, N'eef5a089-f6b6-4edf-8b51-bb45308e3524', CAST(N'2024-10-19T01:14:59.1423801' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'c264bbd1-4762-44f7-8dd4-b978d0605997', N'منتج 7', CAST(100.00 AS Decimal(18, 2)), 40, N'eef5a089-f6b6-4edf-8b51-bb45308e3524', CAST(N'2024-10-19T01:18:52.3382790' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                INSERT [Guide].[Products] ([Id], [Name], [Price], [StockQuantity], [OwnerId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES (N'0e047cc6-cda9-43e9-91a3-fd96c1aec5a3', N'منتج 4', CAST(50.00 AS Decimal(18, 2)), 200, N'eef5a089-f6b6-4edf-8b51-bb45308e3524', CAST(N'2024-10-19T01:15:40.8245786' AS DateTime2), N'762751a8-b808-4fd5-bed7-4fd53d004276', NULL, NULL, 0, 1, NULL, NULL)
                                GO
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete from [Guide].[Products]
                                   delete from [People].[Customers]
                                   delete from [People].[Users]");

        }
    }
}
