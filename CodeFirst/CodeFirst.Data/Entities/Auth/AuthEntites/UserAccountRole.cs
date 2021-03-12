namespace CodeFirst.Data.Entities.Auth.AuthEntites
{
    public class UserAccountRole :AuthBase
    {
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}
