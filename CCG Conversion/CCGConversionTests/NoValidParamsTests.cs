using System;
using CCGConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCGConversionTests
{
    /// <summary>
    /// Test for Files params are valid.
    /// </summary>
    [TestClass]
    public class NoValidParamsTests
    {
        /// <summary>
        /// Test for No valid params.
        /// </summary>
        [TestMethod]
        public void NoParams_ReturnsNoParamsMessage()
        {
            // Arrange
            string[] args = null;
            string expectedOutput = CCGConversion.Constants.Conversion.NoParams;
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
        public void JustOneParam_ReturnsNoParamsMessage()
        {
            // Arrange
            string[] args = { "" };
            string expectedOutput = CCGConversion.Constants.Conversion.NoParams;
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
        public void JustMarkerParams_ReturnsNoParamsMessage()
        {
            // Arrange
            string[] args = { "F\\", "O\\" };
            string expectedOutput = CCGConversion.Constants.Conversion.NoParams;
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
        public void NO_Usable_InputParams_ReturnsNoParamsMessage()
        {
            // Arrange
            string[] args = { "Q\\testdata", "O\\xml" };
            string expectedOutput = CCGConversion.Constants.Conversion.NoParams;
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
    }
}
