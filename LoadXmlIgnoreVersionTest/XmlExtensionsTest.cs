using System.IO;
using System.Xml;
using static LoadXmlIgnoreVersion.TestMethods;

using NUnit.Framework;

namespace LoadXmlIgnoreVersion
{
    public class XmlExtensionsTest
    {
        [Test]
        [TestCase("coverage.xml")]
        [TestCase("coverage1.xml")]
        public void LoadXml_ReturnsDocument(string fileName)
        {
            string xmlFullPath = FullXmlPath(fileName);
            XmlDocument result = new XmlDocument();
            using (FileStream fileStream = new FileStream(xmlFullPath, FileMode.Open, FileAccess.Read))
            {
                result = fileStream.LoadXmlIgnoreVersion();
            }
            Assert.NotNull(result);
            Assert.Greater(result.ChildNodes.Count, 0);
            //check if spaces were removed from between angle brackets
            Assert.True(result.InnerXml.Contains("><"));
        }

        [Test]
        [TestCase("junitResult.xml")]
        [TestCase("build.xml")]
        public void LoadXml_ReturnsDocumentForXmlVersionOnePtOne(string fileName)
        {
            string xmlFullPath = FullXmlPath(fileName);
            XmlDocument result = new XmlDocument();
            using (FileStream fileStream = new FileStream(xmlFullPath, FileMode.Open, FileAccess.Read))
            {
                result = fileStream.LoadXmlIgnoreVersion();
            }
            Assert.NotNull(result);
            Assert.Greater(result.ChildNodes.Count, 0);
            //check if spaces were removed from between angle brackets
            Assert.True(result.InnerXml.Contains("><"));
        }
    }
}