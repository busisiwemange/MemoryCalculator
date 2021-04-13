using System;


namespace MemoryCalculator
{
    public class Calculator
    {
        //declare class fields , accept decimal parameters
        
        private decimal result;


        public Calculator()
        {
            
        }
        public decimal Result
        {
            get
            {
                return result;
            }
           
        }


        #region Methods - Add,Subcract,Multipy,Divide, Sqrt,+/-,1/X

        public decimal Add(decimal num1,decimal num2)
        {
            result = num1 + num2;
            return result;
        }
        public decimal Subcract(decimal num1, decimal num2)
        {
            result = num1 - num2;
            return result;
        }
        public decimal Multiply(decimal num1, decimal num2)
        {
            result = num1 * num2;
            return result;
        }
        public decimal Divide(decimal num1, decimal num2)
        {

            result = num1 / num2;
            return result;
        }

        public decimal NumSign(decimal num1)
        {
            //first check whether the value is posi+ or neg-, then change it
            if (num1 > 0)
            {
                result = -num1;
            }
            else if (num1 < 0)
                result = num1 * -1;


            return result;
        }

        public decimal Sqrt(decimal num1)
        {
            result = (decimal)(Math.Sqrt((double)num1));
            return result;

        }

        public decimal Reciprocal(decimal num1)
        {
            result = 1 / num1;
            return result;

        }
        #endregion


    }
}