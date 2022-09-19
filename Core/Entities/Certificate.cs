using Core.Entities.Identity;
using System;
using System.Collections.Generic;


namespace Core.Entities
{
    public class Certificate : BaseEntity
    {
        public Certificate()
        {
            userCertificates = new HashSet<UserCertificate>();

        }
        public string Name { get; set; }
        public DateTime CertificateDate { get; set; }

        public ICollection<UserCertificate> userCertificates { get; set; }


    }
}
