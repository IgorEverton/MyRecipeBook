using FluentMigrator;

namespace MyRecipeBook.Infrastructure.Migrations.Versions;

[Migration(DataBaseVersion.TABLE_USERS)]
public class VersionSprint01 : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("Users").
            WithColumn("Id").AsGuid().PrimaryKey().NotNullable().
            WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true).
            WithColumn("Name").AsString(255).NotNullable().
            WithColumn("Email").AsString(255).NotNullable().
            WithColumn("Password").AsString(2000).NotNullable();
    }

}
