namespace Store.Models
{
    using Store.Entity;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class of AccountModel.
    /// </summary>
    public class AccountModel
    {
        private List<Account> accounts;

        public AccountModel()
        {
            accounts = new List<Account>();

            accounts.Add(new Account()
            {
                Username = "admin",
                Password = "123",
                Roles = new string[] { "admin" }
            });
        }

        public Account find(string username)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username));
        }

        public Account login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }
    }
}
