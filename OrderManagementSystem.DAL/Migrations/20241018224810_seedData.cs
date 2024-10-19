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
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete from [People].[Users] where Id='762751A8-B808-4FD5-BED7-4FD53D004276'");
        }
    }
}
