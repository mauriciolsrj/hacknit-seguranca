
using GD.Entity;

namespace GD.Infrastructure.Context.EF
{

    // AspNetUserLogins
    
    public class AspNetUserLoginsConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetUserLogins>
    {
        public AspNetUserLoginsConfiguration()
            : this("dbo")
        {
        }
 
        public AspNetUserLoginsConfiguration(string schema)
        {
            ToTable(schema + ".AspNetUserLogins");
            HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            Property(x => x.LoginProvider).HasColumnName("LoginProvider").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ProviderKey).HasColumnName("ProviderKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.AspNetUsers).WithMany(b => b.AspNetUserLogins).HasForeignKey(c => c.UserId); // FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId
        }
    }

}

