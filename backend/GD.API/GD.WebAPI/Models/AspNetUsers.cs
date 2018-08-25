namespace GD.API.Models
{
    public class AspNetUsers
    {
        public string Id { get; set; } // Id (Primary key) (length: 128)
        public string Email { get; set; } // Email (length: 256)
        public bool EmailConfirmed { get; set; } // EmailConfirmed
        public string PasswordHash { get; set; } // PasswordHash
        public string SecurityStamp { get; set; } // SecurityStamp
        public string PhoneNumber { get; set; } // PhoneNumber
        public bool PhoneNumberConfirmed { get; set; } // PhoneNumberConfirmed
        public bool TwoFactorEnabled { get; set; } // TwoFactorEnabled
        public System.DateTime? LockoutEndDateUtc { get; set; } // LockoutEndDateUtc
        public bool LockoutEnabled { get; set; } // LockoutEnabled
        public int AccessFailedCount { get; set; } // AccessFailedCount
        public string UserName { get; set; } // UserName (length: 256)
        public string Matricula { get; set; } // Matricula (length: 32)
        public int? LotacaoId { get; set; } // LotacaoId

        public string Inscricao { get; set; } // Inscricao (length: 32)
        public System.DateTime? ValidadeLicenca { get; set; } // ValidadeLicenca
        public string LocalAtuacao { get; set; } // LocalAtuacao (length: 128)
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude
        public string Foto { get; set; } // Foto (length: 256)

        public AspNetUsers()
        {

        }
    }
}
