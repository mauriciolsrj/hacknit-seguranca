
namespace GD.Entity
{

    // AspNetRoles

    public class AspNetRoles
    {
        public string Id { get; set; } // Id (Primary key) (length: 128)
        public string Name { get; set; } // Name (length: 256)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<AspNetUsers> AspNetUsers { get; set; } // Many to many mapping
        
        public AspNetRoles()
        {
            AspNetUsers = new System.Collections.Generic.List<AspNetUsers>();
        }
    }

}

