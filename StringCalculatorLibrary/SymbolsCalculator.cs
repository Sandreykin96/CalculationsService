using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StringCalculatorLibrary
{
    public class SymbolsCalculator
    {
        public List<string> ListOfCalcStrings { get; set; }
        public Dictionary<string, double?> InputDataKeyValue { get; set; }
        public Dictionary<string, double?> CalculatedDataKeyValue { get; set; }

        public SymbolsCalculator(List<string> listOfCalcStrings, Dictionary<string, double?> inputDataKeyValue)
        {
            ListOfCalcStrings = listOfCalcStrings;
            InputDataKeyValue = inputDataKeyValue;
            CalculatedDataKeyValue = new Dictionary<string, double?>();
        }

        public Dictionary<string, double?> MakeCalculations()
        {
            foreach (var expression in ListOfCalcStrings)
            {
                CalculateExpression(expression);
            }
            return CalculatedDataKeyValue;
        }

        private void CalculateExpression(string expression)
        {
           
           var splittedExpression = expression.Split('=');
           var leftPiece = splittedExpression.First().Replace(" ", "");
           var rightPiece = splittedExpression.Last();
           
           rightPiece = ReplaceWordsByNums(rightPiece);

            double? result = null;
            try
            {
                result = MakeCalkOfMathString(rightPiece);
            }
            finally
            {
                if (result != null)
                {
                    CalculatedDataKeyValue.Add(leftPiece, result);
                }
            }            
        }

        private string ReplaceWordsByNums(string rightPiece)
        {

            char[] delimiter = { '/', '*', '+', '-', '^', '(', ')' };

            var splitted = rightPiece.Split(delimiter);

            var dict = new Dictionary<string, double?>();

            foreach (var item in splitted)
            {
                var word = item.Replace(" ", "");
                if (InputDataKeyValue.ContainsKey(word))
                {
                    dict[item] = InputDataKeyValue[word];
                }
                if (CalculatedDataKeyValue.ContainsKey(word))
                {
                    dict[item] = CalculatedDataKeyValue[word];
                }
            }

            foreach (var item in dict)
            {
                rightPiece = rightPiece.Replace(item.Key, item.Value.ToString());
            }

            return rightPiece;
        }

        private double MakeCalkOfMathString(string expression)
        {
            return MathParser.process(expression);
        }
    }
}
