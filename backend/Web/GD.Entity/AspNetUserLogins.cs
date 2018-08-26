
namespace GD.Entity
{

    // AspNetUserLogins

    public class AspNetUserLogins
    {
        public string LoginProvider { get; set; } // LoginProvider (Primary key) (length: 128)
        public string ProviderKey { get; set; } // ProviderKey (Primary key) (length: 128)
        public string UserId { get; set; } // UserId (Primary key) (length: 128)

        // Foreign keys
        public virtual AspNetUsers AspNetUsers { get; set; } // FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId
    }

}

