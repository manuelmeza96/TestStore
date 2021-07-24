namespace Store.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Store.Business;
    using Store.Entity;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Xunit.Sdk;

    [TestClass]
    public class SecurityTest
    {
        /// <summary>
        /// Example Unit Test.
        /// </summary>
        [TestMethod]     
        public void TestGetUserClaims()
        {
            //Arrange.
            Account account = new Account();
            account.Username = "admin";
            account.Password = "123";
            account.Roles = new string[] { "admin" };

            //Act.
            Security security = new Security();
            IEnumerable<Claim> claims = security.GetUserClaims(account);

            //Assert.
            Assert.IsNotNull(claims);
        }
    }
}
