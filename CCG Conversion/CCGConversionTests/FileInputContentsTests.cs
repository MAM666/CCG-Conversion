using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CCGConversion.ConversionOutput;
using CCGConversion.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCGConversionTests
{
    [TestClass]
    public class FileInputContentsTests
    {
        [TestMethod]
        public void ValidPersonCSV_ReturnsValidPersonXML()
        {
            // Arrange
            XMLOutputPerson xmlOutput = new XMLOutputPerson("");
            string[] lines = new string[] { "name,address_line1,address_line2", "Dave,Street,Town" };
            // Act            
            xmlOutput.Process(lines);

            List<Person> expectedOutput = new List<Person>
            {
                new Person()
                {
                    Name = "Dave",
                    Address = new Address()
                    {
                        Line1 = "Street",
                        Line2 = "Town"
                    }
                }
            };

            var tmp = expectedOutput.Except<Person>(xmlOutput.Results, new PersonComparer());

            // Assert
            Assert.IsTrue(tmp.Count() == 0);
        }

        [TestMethod]
        public void ValidPersonCSV_ReturnsValidPersonJSON()
        {
            // Arrange
            JSONOutputPerson xmlOutput = new JSONOutputPerson("");
            string[] lines = new string[] { "name,address_line1,address_line2", "Dave,Street,Town" };
            // Act            
            xmlOutput.Process(lines);

            List<Person> expectedOutput = new List<Person>
            {
                new Person()
                {
                    Name = "Dave",
                    Address = new Address()
                    {
                        Line1 = "Street",
                        Line2 = "Town"
                    }
                }
            };

            var tmp = expectedOutput.Except<Person>(xmlOutput.Results, new PersonComparer());

            // Assert
            Assert.IsTrue(tmp.Count() == 0);
        }

        [TestMethod]
        public void XMLOutput_UnderscoreRule_ReturnsValidXML()
        {
            // Arrange
            XMLOutput_UnderscoreRule xmlOutput = new XMLOutput_UnderscoreRule("");
            string[] lines = new string[] { "name,address_line1,address_line2", "Dave,Street,Town" };

            XElement expectedOutput = new XElement("header");
            XElement row = new XElement("row");
            XElement item = new XElement("name", "Dave");
            row.Add(item);
            item = new XElement("address");
            XElement child = new XElement("line1", "Street");
            item.Add(child);
            child = new XElement("line2", "Town");
            item.Add(child);
            row.Add(item);
            expectedOutput.Add(row);

            // Act            
            xmlOutput.Process(lines);
            // Assert
            Assert.IsTrue(expectedOutput.ToString().Equals(xmlOutput.Results.ToString()));
        }

    }
}
