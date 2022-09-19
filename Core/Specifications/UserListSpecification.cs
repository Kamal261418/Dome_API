using Core.Entities;
using Core.Entities.Identity;
using System.Linq;

namespace Core.Specifications
{
    public class UserListSpecification : BaseSpecifcation<AppUser>
    {
        public UserListSpecification() : base()
        {
            AddInclude(x => x.userCertificates);

        }
    }
}
