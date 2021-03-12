using System.Collections.Generic;

namespace CodeFirst.Data.Entities.Auth.AuthEntites
{
    public class UserRole :AuthBase
    {
        public string UserRoleName { get; set; }
        public List<UserAccountRole> UserAccountRoles { get; set; }
    }
}
