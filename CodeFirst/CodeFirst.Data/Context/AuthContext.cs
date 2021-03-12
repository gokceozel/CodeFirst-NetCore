using CodeFirst.Data.Entities.Auth.AuthEntites;
using Microsoft.EntityFrameworkCore;


namespace CodeFirst.Data.Context
{
    public class AuthContext : DbContext
    {
        #region fields
        #endregion

        #region constructors
        public AuthContext()
        {

        }
        #endregion

        #region Properties
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountRole> UserAccountRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
