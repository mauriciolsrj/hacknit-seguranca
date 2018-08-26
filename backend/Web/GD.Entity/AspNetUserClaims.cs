
namespace GD.Entity
{

    // AspNetUserClaims

    public class AspNetUserClaims
    {
        public int Id { get; set; } // Id (Primary key)
        public string UserId { get; set; } // UserId (length: 128)
        public string ClaimType { get; set; } // ClaimType
        public string ClaimValue { get; set; } // ClaimValue

        // Foreign keys
        public virtual AspNetUsers AspNetUsers { get; set; } // FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId
    }

}

