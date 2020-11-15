using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLibrary;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorUnitTest
{
    [TestClass]
    public class SymbolsCalculatorTest
    {
        [TestMethod]
        public void APlusBTest()
        {
            // Arrange

            var ListOfCalcStrings = new List<string>();
            var expression1 = "c = a + b";
            ListOfCalcStrings.Add(expression1);

            var InputDataKeyValue = new Dictionary<string, double?>();
            InputDataKeyValue.Add("a", 2);
            InputDataKeyValue.Add("b", 4);

            var OutputDataKeyValue = new Dictionary<string, double?>();
            OutputDataKeyValue.Add("c", null);

            var calculator = new SymbolsCalculator(ListOfCalcStrings,InputDataKeyValue,OutputDataKeyValue);
            var expected = new Dictionary<string, double?>();
            expected.Add("c", 6);

            // Act
            var actual = calculator.MakeCalculations();

            // Assert
            bool areEqual = actual.SequenceEqual(expected);

            Assert.AreEqual(true, areEqual, "Result is not calculated correctly");
        }

        [TestMethod]
        public void APlusBMultuplyDTest()
        {
            // Arrange

            var ListOfCalcStrings = new List<string>();
            var expression1 = "c = (a + b)*d";
            ListOfCalcStrings.Add(expression1);

            var InputDataKeyValue = new Dictionary<string, double?>();
            InputDataKeyValue.Add("a", 2);
            InputDataKeyValue.Add("b", 4);
            InputDataKeyValue.Add("d", 3);

            var OutputDataKeyValue = new Dictionary<string, double?>();
            OutputDataKeyValue.Add("c", null);

            var calculator = new SymbolsCalculator(ListOfCalcStrings, InputDataKeyValue, OutputDataKeyValue);
            var expected = new Dictionary<string, double?>();
            expected.Add("c", 18);

            // Act
            var actual = calculator.MakeCalculations();

            // Assert
            bool areEqual = actual.SequenceEqual(expected);

            Assert.AreEqual(true, areEqual, "Result is not calculated correctly");
        }

        [TestMethod]
        public void TwoExpressionsTest()
        {
            // Arrange

            var ListOfCalcStrings = new List<string>();
            var expression1 = "c = (a + b)*d";
            var expression2 = "ee = c+1";

            ListOfCalcStrings.Add(expression1);
            ListOfCalcStrings.Add(expression2);

            var InputDataKeyValue = new Dictionary<string, double?>();
            InputDataKeyValue.Add("a", 2);
            InputDataKeyValue.Add("b", 4);
            InputDataKeyValue.Add("d", 3);

            var OutputDataKeyValue = new Dictionary<string, double?>();
            OutputDataKeyValue.Add("c", null);
            OutputDataKeyValue.Add("ee", null);

            var calculator = new SymbolsCalculator(ListOfCalcStrings, InputDataKeyValue, OutputDataKeyValue);
            var expected = new Dictionary<string, double?>();
            expected.Add("c", 18);
            expected.Add("ee", 19);

            // Act
            var actual = calculator.MakeCalculations();

            // Assert
            bool areEqual = actual.SequenceEqual(expected);

            Assert.AreEqual(true, areEqual, "Result is not calculated correctly");
        }

    }
}
