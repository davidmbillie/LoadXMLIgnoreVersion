using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace LoadXmlIgnoreVersion
{
    public static class XmlExtensions
    {
        /// <summary>
        /// Load XMLDocument from a Stream ignoring if the xml version is 1.1
        /// </summary>
        /// <param name="originalStream"></param>
        /// <returns></returns>
        public static XmlDocument LoadXmlIgnoreVersion(this Stream originalStream)
        {
            string tempFile = Path.GetTempFileName();
            XmlDocument xmlDoc = new XmlDocument();
            using (FileStream fileStream = new FileStream(tempFile, FileMode.Open, FileAccess.ReadWrite))
            using (StreamReader sr = new StreamReader(originalStream, Encoding.UTF8))
            {
                string firstLine = sr.ReadLine();
                originalStream.Seek(0, SeekOrigin.Begin);
                if (firstLine.Contains("xml") && firstLine.Contains("1.0"))
                {
                    xmlDoc.Load(originalStream);
                    return xmlDoc;
                }
                originalStream.CopyTo(fileStream);
            }

            string[] lines = File.ReadAllLines(tempFile);
            if (lines[0].Contains("xml") && lines[0].Contains("1.1"))
            {
                lines[0] = lines[0].Replace("1.1", "1.0");
                string allLines = string.Join(String.Empty, lines);
                allLines = Regex.Replace(allLines, PatternConstants.SpacesBetweenAngleBrackets, "><");
                allLines = Regex.Replace(allLines, PatternConstants.ControlCharacters + "|" +
                    PatternConstants.IllegalLineSeparator, String.Empty);
                File.WriteAllText(tempFile, allLines);
                xmlDoc.Load(tempFile);
            }
            File.Delete(tempFile);
            return xmlDoc;
        }
    }
}
