using System;
using CCGConversion;
using CCGConversion.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCGConversionTests
{

    /// <summary>
    /// Test for Files params are valid.
    /// </summary>
    [TestClass]
    public class DataBaseInputValidTests
    {
        /// <summary>
        /// Test for Database validation.
        /// </summary>
        [TestMethod]
        public void ConnectionString_ReturnsNoExtensionMessage()
        {
            // Arrange
            string[] args = { "DB\\testdata", "O\\xml", "P\\person" };
            string expectedOutput = string.Format(CCGConversion.Constants.FileInputConstants.NoExtension
                                                , "testdata");
            string actualOutput = "";
            // Act
            if (Conversion.CheckParams(args))
            {
                actualOutput = Conversion.CompleteMessage;
            }
            else if (Conversion.Problem != null)
            {
                actualOutput = Conversion.Problem.Message;
            }
            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        /// <summary>
        /// Test for Database validation.
        /// </summary>
        [TestMethod]
        public void ConnectionString_ReturnsFileMissingMessage()
        {
            // Arrange
            string[] args = { "DB\\connectionstring.txt", "O\\personnel.xml", "P\\person" };
            string expectedOutput = string.Format(CCGConversion.Constants.FileInputConstants.FileMissing
                                                , "connectionstring.txt");
            string actualOutput = "";
            // Act
            if (Conversion.CheckParams(args))
            {
                actualOutput = Conversion.CompleteMessage;
            }
            else if (Conversion.Problem != null)
            {
                actualOutput = Conversion.Problem.Message;
            }
            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        ///// <summary>
        ///// Test for Database validation.
        ///// </summary>
        //[TestMethod]
        //public void ConnectionString_ReturnsUnderConstructionMessage()
        //{
        //    // Arrange
        //    string[] args = { "DB\\connectionstring.txt", "O\\personnel.xml", "P\\person"  };
        //    string expectedOutput = CCGConversion.Constants.Conversion.IsUnderConstruction;
        //    string actualOutput = "";
        //    // Act
        //    if (Conversion.CheckParams(args))
        //    {
        //        actualOutput = Conversion.CompleteMessage;
        //    }
        //    else if (Conversion.Problem != null)
        //    {
        //        actualOutput = Conversion.Problem.Message;
        //    }
        //    // Assert
        //    Assert.AreEqual(expectedOutput, actualOutput);
        //}
    }
}
