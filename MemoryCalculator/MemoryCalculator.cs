using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCalculator
{
    public class MemoryCalculator: Calculator
    {
        //strore memory Value
        public decimal memoryValue ;

        public MemoryCalculator():base()
        {
         
        }

        //public decimal MemoryValue
        //{
        //    get { return memoryValue; }
        //    set { memoryValue = ; }

        //}
        public decimal MClear()
        {
            // clear the contents of memory
             memoryValue = 0;
             return memoryValue;
            
        }

        public decimal MSave(decimal value)
        {
            // save the value that’s currently displayed in memory
            memoryValue = value;
            return memoryValue;
        }
        public decimal MPlus(decimal value)
        {
            // add the value that’s currently displayed to the value in memory, 
             memoryValue += value;
             return memoryValue;
        }
        public decimal MRecall()
        {
            // recall the value that’s currently in memory
            return memoryValue ;
        }
    }
}
