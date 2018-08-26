
using GD.Entity;

namespace GD.Infrastructure.Context.EF
{

    // AspNetUsers
    
    public class AspNetUsersConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetUsers>
    {
        public AspNetUsersConfiguration()
            : this("dbo")
        {
        }
 
        public AspNetUsersConfiguration(string schema)
        {
            ToTable(schema + ".AspNetUsers");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.EmailConfirmed).HasColumnName("EmailConfirmed").IsRequired().HasColumnType("bit");
            Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SecurityStamp).HasColumnName("SecurityStamp").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed").IsRequired().HasColumnType("bit");
            Property(x => x.TwoFactorEnabled).HasColumnName("TwoFactorEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc").IsOptional().HasColumnType("datetime");
            Property(x => x.LockoutEnabled).HasColumnName("LockoutEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.AccessFailedCount).HasColumnName("AccessFailedCount").IsRequired().HasColumnType("int");
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
        }
    }

}

