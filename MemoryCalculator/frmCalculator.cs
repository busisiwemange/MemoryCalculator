using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryCalculator
{
    public partial class frmCalculator : Form
    {
        //class fields
        private decimal resultValue = 0;
        private string operation;
        private bool operatorDone = false;
       
        // declare instance of Calculator class 
        //and only create and assign memory at runtime
        private Calculator calculator;

        /*Collection to store history of all calulations
        calculation variable to store calculation done and add to colletion
        dateTime variable to store current date and time of calculation
        */
        private List<string> listCalulations = new List<string>();
        private string calculation;
        private DateTime dateTime = DateTime.Now;
       
        public frmCalculator()
        {
           InitializeComponent();
        }

        

        #region Entering numbers
        //event handler to get values of button numberes 0 to 9  that are clicked 
        //from their tag property 
        private void numberClicked(object sender, System.EventArgs e)
        {
            if ((txtDisplay.Text == "0" )|| operatorDone == true)
            {
               
                txtDisplay.Text = "";

            }
            operatorDone = false;
            Button button = (Button)sender;
            
            //if statement to control the decimal point entry to a number or to the textbox
            //tag property of decimal point button ". " is "," to prevent errors in lab
            if (button.Tag.ToString() == ",")
            {
                if (!(txtDisplay.Text.Contains(",")))
                {
                    txtDisplay.Text += button.Tag.ToString();
                }
            }
            else
            {
                txtDisplay.Text += button.Tag.ToString();
            }
            
        }
        #endregion

        #region Operations- Add, Sub,Multiply and Divide  
        private void operation_Click(object sender, EventArgs e)
        {
            try
            {
                operation = ((Button)sender).Tag.ToString();
                resultValue = Convert.ToDecimal(txtDisplay.Text);
                operatorDone = true;

            }
            catch (FormatException)
            {

                txtDisplay.Text = "";
            }
            
        }
        #endregion

        #region Equals, +/-,sqrt and 1/X
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                calculator = new Calculator();
                decimal operand1 = resultValue;
                decimal operand2 = Convert.ToDecimal(txtDisplay.Text);


                switch (operation)
                {
                    case "+":

                        txtDisplay.Text = calculator.Add(operand1, operand2).ToString();
                        calculation = dateTime + ", " + operand1 + " Add " + operand2 + " = " + txtDisplay.Text;
                        break;
                    case "-":
                        txtDisplay.Text = calculator.Subcract(operand1, operand2).ToString();
                        calculation = dateTime + ", " + operand1 + " Subcract " + operand2 + " = " + txtDisplay.Text;

                        break;
                    case "*":
                        txtDisplay.Text = calculator.Multiply(operand1, operand2).ToString();
                        calculation = dateTime + ", " + operand1 + " Multiply " + operand2 + " = " + txtDisplay.Text;
                        break;
                    case "/":
                        try
                        {
                            txtDisplay.Text = calculator.Divide(operand1, operand2).ToString();
                            calculation = dateTime + ", " + operand1 + " Divide " + operand2 + " = " + txtDisplay.Text;
                        }
                        catch (DivideByZeroException)
                        {
                            txtDisplay.Text = "Cannot divide by zero.";

                        }

                        break;
                    default:
                        break;
                }
                operatorDone = false;
                listCalulations.Add(calculation);

            }
            catch (FormatException)
            {

                txtDisplay.Text = "0";
            }
           
        }
        
        private void btnSign_Click(object sender, EventArgs e)
        {
            //method to change sign of a value
            try
            {
                calculator = new Calculator();
                txtDisplay.Text = calculator.NumSign(Convert.ToDecimal(txtDisplay.Text)).ToString();
               
            }
            catch (Exception)
            {
                //when user just cliks the operation without entering a number
                txtDisplay.Text = "0";
                operatorDone = false;
            }
           
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "")
            {
                //when user just cliks the operation without entering a number
                txtDisplay.Text = "0";
            }
            else
            {
                try
                {
                    decimal value =Convert.ToDecimal(txtDisplay.Text);
                    calculator = new Calculator();
                    txtDisplay.Text = calculator.Sqrt(Convert.ToDecimal(value)).ToString();
                    calculation = dateTime +", Sqrt " + value+" = " +calculator.Sqrt(Convert.ToDecimal(value)).ToString();
                    listCalulations.Add(calculation);
                }
               
                catch (FormatException)
                {
                    txtDisplay.Text = "0";
                }
                catch (OverflowException)
                {
                    //when  you try to find square root of negative number
                    txtDisplay.Text = "Math Error.";

                }
            }
           
        }
        private void btnReciprocal_Click(object sender, EventArgs e)
        {

            if (txtDisplay.Text =="")
            {
                //when user just cliks the operation without entering a number
                txtDisplay.Text = "0";
            }
            else
            {
                try
                {
                    decimal value = Convert.ToDecimal(txtDisplay.Text);
                    calculator = new Calculator();
                    txtDisplay.Text = calculator.Reciprocal(Convert.ToDecimal(value)).ToString();
                    calculation = dateTime + ", 1/" + value + " = " + calculator.Sqrt(Convert.ToDecimal(value)).ToString();
                    listCalulations.Add(calculation);
                }
                catch (FormatException)
                {
                    txtDisplay.Text = "Cannot divide by zero.";
                    

                }

                catch (DivideByZeroException)
                {
                    //if user tries to deivide by zero or
                    //just clicks the 1/X button without entering a value first
                    txtDisplay.Text = "Cannot divide by zero.";
                    

                }
                
            }
            
        }

        #endregion

        #region Memory function
        private void MemoryFunction_click(object sender, EventArgs e)
        {
            //cast sender tomtype button to be able to get or access its properties
            Button memoryButton = (Button)sender;
            string memoryFunction = memoryButton.Tag.ToString();         //get its tag property value
            MemoryCalculator memory = new MemoryCalculator();
            
            if (memoryFunction == "MC")
            {//clear memory 
                memory.MClear();
                btnMemory.Text = "";
                
            }
            else if (memoryFunction == "MR")
            {
                //recall the value of the memory 
                
                txtDisplay.Text = memory.MRecall().ToString();
                
            }
           else if (memoryFunction == "MS")
            {
                try
                {
                    memory.MSave(Convert.ToDecimal(txtDisplay.Text));

                    //indicate there is something in memory, saved to memory
                   
                }
                catch (FormatException)
                {

                    memory.MSave(0);
                }

                btnMemory.Text = "M";

            }

            else if (memoryFunction == "M+")
            {
                try
                {
                    memory.MPlus(Convert.ToDecimal(txtDisplay.Text));

                }
                catch (FormatException)
                {

                   memory.MPlus(0);
                }
                
                //indicate there is something in memory, add currently dispayed value to value in memory
                btnMemory.Text = "M";
                
            }
            
        }
        #endregion

        #region History button
        //create and display a history form.
        // show history of all calculations performed before the calculator is closed. 
        private void btnHistory_Click(object sender, EventArgs e)
        {
            //passing a list with all calculations peformed to be dispalyed 
            frmHistory newForm = new frmHistory(listCalulations);
            Calculator cal1 = newForm.GetNewItem();
            
        }
        
        #endregion

        #region Clear and Back button
       
        private void btnClear_Click(object sender, EventArgs e)
        { // clear all the values entered

            txtDisplay.Text = "0";
            resultValue = 0;
            operatorDone = false;
           
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {// erase the last digit entered
            if (operatorDone==true)
            {
                txtDisplay.Text = txtDisplay.Text;
            }
            else
            {
                if (txtDisplay.Text.Length > 1)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);

                }
                else
                {
                    txtDisplay.Text = "0";

                }
            }
            

        }



        #endregion

        
    }


}
