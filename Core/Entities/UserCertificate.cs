using Core.Entities.Identity;
using System;
using System.Collections.Generic;


namespace Core.Entities
{
    public partial class UserCertificate : BaseEntity
    {
        public UserCertificate()
        {
         
        }

        public int CertificateId { get; set; }
        public int UserId { get; set; }

        public AppUser User { get; set; }
        public Certificate Certificate { get; set; }

    }
}
