using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindNthRootLogic.Tests
{
    [TestClass]
    public class FindRootNewtonTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Data.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("FindNthRootLogic.Tests\\Data.xml")]
        [TestMethod]
        public void FindNthRoot_ReturnRoot()
        {
            double number = XmlConvert.ToDouble(TestContext.DataRow["Number"].ToString());
            int n = XmlConvert.ToInt32(TestContext.DataRow["Root"].ToString());
            double accurancy = XmlConvert.ToDouble(TestContext.DataRow["Accurancy"].ToString());
            double expected = XmlConvert.ToDouble(TestContext.DataRow["ExpectedResult"].ToString());

            double actual = FindRootNewton.FindNthRoot(number, n, accurancy);

            Assert.AreEqual(expected, actual, accurancy);
        }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\InvalidData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("FindNthRootLogic.Tests\\InvalidData.xml")]
        [TestMethod]
        public void FindNthRoot_ThrowArgumentException()
        {
            double number = XmlConvert.ToDouble(TestContext.DataRow["Number"].ToString());
            int n = XmlConvert.ToInt32(TestContext.DataRow["Root"].ToString());
            double accurancy = XmlConvert.ToDouble(TestContext.DataRow["Accurancy"].ToString());

            Assert.ThrowsException<ArgumentException>(() => FindRootNewton.FindNthRoot(number, n, accurancy));
        }
    }
}
