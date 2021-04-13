using System;


namespace MemoryCalculator
{
    public class Calculator
    {
        //declare class fields , accept decimal parameters
        private decimal operand1, operand2, result;


        public Calculator(decimal ope1, decimal ope2)
        {
            this.Operand1 = ope1;
            this.Operand2 = ope2;
        }

        #region //properties
        public decimal Operand1
        {
            get { return operand1; }
            set { operand1 = value; }
        }

        public decimal Operand2
        {
            get { return operand2; }
            set { operand2 = value; }
        }
        #endregion

        #region //methods - 

        private decimal Add(decimal operand1, decimal operand2)
        {

            result = operand1 + Operand2;
            return result;

        }

        #endregion
    }
}