
using GD.Entity;

namespace GD.Infrastructure.Context.EF
{

    // AspNetUserClaims
    
    public class AspNetUserClaimsConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AspNetUserClaims>
    {
        public AspNetUserClaimsConfiguration()
            : this("dbo")
        {
        }
 
        public AspNetUserClaimsConfiguration(string schema)
        {
            ToTable(schema + ".AspNetUserClaims");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("nvarchar").HasMaxLength(128);
            Property(x => x.ClaimType).HasColumnName("ClaimType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ClaimValue).HasColumnName("ClaimValue").IsOptional().HasColumnType("nvarchar");

            // Foreign keys
            HasRequired(a => a.AspNetUsers).WithMany(b => b.AspNetUserClaims).HasForeignKey(c => c.UserId); // FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId
        }
    }

}

