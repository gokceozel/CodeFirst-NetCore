using System.Collections.Generic;

namespace CodeFirst.Data.Entities.Auth.AuthEntites
{
    public class UserAccount : AuthBase
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public List<UserAccountRole> UserAccountRoles { get; set; }
    }
}
