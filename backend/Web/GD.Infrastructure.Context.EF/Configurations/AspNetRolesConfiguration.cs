
using GD.Entity;

namespace GD.Infrastructure.Context.EF
{

    // AspNetRoles

    public class AspNetRolesConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetRoles>
    {
        public AspNetRolesConfiguration()
            : this("dbo")
        {
        }
 
        public AspNetRolesConfiguration(string schema)
        {
            ToTable(schema + ".AspNetRoles");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            HasMany(t => t.AspNetUsers).WithMany(t => t.AspNetRoles).Map(m => 
            {
                m.ToTable("AspNetUserRoles", "dbo");
                m.MapLeftKey("RoleId");
                m.MapRightKey("UserId");
            });
        }
    }

}

