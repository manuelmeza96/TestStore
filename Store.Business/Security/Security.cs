namespace Store.Business
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Store.Entity;

    /// <summary>
    /// Class of Security.
    /// </summary>
    public class Security
    {
        /// <summary>
        /// Method SignIn.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="account"></param>
        public async void SignIn(HttpContext httpContext, Account account)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetUserClaims(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        /// <summary>
        /// Method SignOut.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="account"></param>
        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        /// <summary>
        /// Method GetUserClaims.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public IEnumerable<Claim> GetUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));
            foreach (var role in account.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
