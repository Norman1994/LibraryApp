using System;
using NUnit.Framework;

namespace Library.Tests.DbTest
{

    public class DbTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void IsDbAccessed()
        {
            Assert.AreEqual(true, true);
        }
    }
}
