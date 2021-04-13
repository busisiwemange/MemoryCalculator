# MemoryCalculator

Create a Memory Calculator.

For this project you’ll create a form that lets the user perform the functions provided by a memory calculator. You’ll also create two classes that perform the required operations. You’ll then create a second form to display a history of operations.

Basic Operation

• To perform an addition, subtraction, multiplication, or division operation, the user clicks the first number, followed by the appropriate operator key (+, -, *, /), followed by the second number and the equals key (=).

• To perform an addition, subtraction, multiplication, or division operation on the result of a previous operation, the user clicks another operator key, followed by another number and the equals key. The user can also repeat the previous operation on the result by clicking the equals keys without first clicking another operator and number.

• To calculate the square root or the reciprocal of a number or to change the sign of a number, the user clicks the number followed by the appropriate operator key (sqrt, 1/X, +/-).

• To calculate the square root or the reciprocal of the result of a previous operation, the user clicks the appropriate operator key.

• Each time the user clicks a number key, the number is displayed in the text box at the top of the form. This text box also displays the result of an operation when the user clicks the sqrt, 1/X, +/-, or = key.

• To erase the last digit entered, the user clicks the Back key.

• To clear all the values entered, the user clicks the Clear key.

Memory Function

• To clear the contents of memory, the user clicks the MC button. To save the value that’s currently displayed in memory, the user clicks the MS button. To recall the value that’s currently in memory and display it in the calculator, the user clicks the MR button. And to add the value that’s currently displayed to the value in memory, the user clicks the M+ button.

• An M is displayed in the box above the MC button whenever the memory contains a value. 

History Function

• The user can click the H button to show the history of all calculations performed before the calculator is closed. The history is shown in a list box on a new form.

• The history must include the date and time, as well as a description of the operation. 

Specifications

• Create a class named Calculator that implements the functions of the calculator. Design whatever methods and properties you need for this class.

• The Calculator class should accept decimal parameters and provide a decimal result for its calculated values.

• Create a class named MemoryCalculator that inherits the Calculator class. The MemoryCalculator class should add properties and methods as needed to implement the memory function.

• If the user tries to divide a number by zero, the calculator should display an error message in the text box. The form class should use a try-catch statement to catch a divide-by-zero exception.
