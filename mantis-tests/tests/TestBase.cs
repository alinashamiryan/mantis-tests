using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    public class TestBase
    {
     public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

         [TestFixtureSetUp]
        public void SetupApplicationMananger()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder bilder = new StringBuilder();
            for(int i=0; i<l; i++)
            {
                int num = 174+ Convert.ToInt32(rnd.NextDouble() * 81);
               
                bilder.Append(Convert.ToChar(num));
            }
            return bilder.ToString();
        }
    }
}
