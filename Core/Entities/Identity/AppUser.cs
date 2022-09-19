using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Identity
{
    [Table("AspNetUsers")]
    public partial class AppUser : IdentityUser<int>
    {

        public AppUser()
        {
            userCertificates = new HashSet<UserCertificate>();
        }

        public ICollection<UserCertificate> userCertificates { get; set; }

    }
}
