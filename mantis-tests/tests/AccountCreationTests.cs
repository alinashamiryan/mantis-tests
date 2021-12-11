using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests:TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile=File.Open("config_inc.php", FileMode.Open)) 
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccounRegistration()
        {
            AccountData account = new AccountData()
            { 
            Name="testuser5",
            Password ="password",
            Email= "testuser5@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);
            app.Registration.Register(account);
        }

       [TestFixtureTearDown]
       public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
