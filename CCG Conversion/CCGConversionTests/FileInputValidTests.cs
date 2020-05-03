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
    public class FileInputValidTests
    {
        [TestMethod]
        public void NO_Extension_ReturnsNoExtensionMessage()
        {
            // Arrange
            string[] args = { @"F\testdata", @"O\xml", @"P\person" };
            string expectedOutput = string.Format(CCGConversion.Constants.FileInputConstants.NoExtension, "testdata");
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

        //[TestMethod]
        //public void NO_Usable_FileInputType_ReturnsFileMissingMessage()
        //{
        //    // Arrange
        //    string[] args = { "F\\testdata.xyz", "O\\xml", "P\\person" };
        //    string expectedOutput = string.Format(CCGConversion.Constants.FileInputConstants.FileMissing, "testdata.xyz");
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

        [TestMethod]
        public void NO_ValidExtension_ReturnsNoValidExtensionMessage()
        {
            // Arrange
            string[] args = { "F\\testdata.abc", "O\\xml", "P\\person" };
            string expectedOutput = string.Format(CCGConversion.Constants.FileInputConstants.NoValidExtension, "testdata.abc");
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

        [TestMethod]
        public void NO_ValidOutputOption_ReturnsNoValidOutPutMessage()
        {
            // Arrange
            string[] args = { "F\\testdata.csv", "O\\abc", "P\\person" };
            string expectedOutput = string.Format(CCGConversion.Constants.Conversion.NoValidOutputType, "abc");
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

        [TestMethod]
        public void SameInputOutput_ReturnsSameInputOutPutMessage()
        {
            // Arrange
            string[] args = { "F\\testdata.csv", "O\\csv", "P\\person" };
            string expectedOutput = CCGConversion.Constants.Conversion.InputOutputSame;
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

        //[TestMethod]
        //public void PersonCSVNoData_ReturnsNoDataMessage()
        //{
        //    // Arrange
        //    string[] args = { "F\\testdata1.csv", "O\\xml", "P\\person" };
        //    string expectedOutput = CCGConversion.Constants.Conversion.NoDataToProcess;
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
