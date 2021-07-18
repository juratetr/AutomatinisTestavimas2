using NUnit.Framework;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2
{
    public class Class1
    {
        [Test]
        public static void TestIf4IsEven()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }

        [Test]
        public static void TestNowIs19()
        {
            DateTime CurrentTime = DateTime.Now;
            //Assert.AreEqual(19, CurrentTime.Hour, "Dabar ne 19 valanda");
            Assert.IsTrue(CurrentTime.Hour.Equals(20), "Dabar ne 19 valanda");

        }
        [Test]
        public static void TestDivide995()
        { int leftower = 995 % 3;
            Assert.AreEqual(2, leftower, "Nesidalina is 3");

        }
        [Test]
        public static void TestIsMonday()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Monday, CurrentTime.DayOfWeek, "Dabar ne pirmadienis");

        }
        [Test]
        public static void TestWait5Sec()
        { Thread.Sleep(5000); 
        }
    }
}
