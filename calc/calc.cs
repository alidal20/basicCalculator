using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class basicCalculator : Form
    {
        private class Operation
        {
            public double number;
            public int operation;

            public Operation( double number , int operation )
            {
                this.number = number;
                this.operation = operation;
            }
        }

        // Indicates that the display content should be cleared
        // Next time user enters a value, the display will reset and print the new value
        bool newLine = true;

        // Indicates what type of input the calculator processed last time
        // 0 - number
        // 1 - operation
        int lastInput = 0;

        // Data structure that stores queued operations
        List<Operation> operations = new List<Operation>();

        // Save cache of last operation. 
        // Repeatedly pressing Enter or Clicking Equal will perform the cached operation
        Operation lastOperation = null;

        public basicCalculator()
        {
            InitializeComponent();
        }

        /**
         *  Function that handles event created when user clicks Numpad7
         * */
        private void num7_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if(newLine)
            {
                display("7");
                newLine = false;
            }
            else
            {
                addToDisplay("7");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad8
         * */
        private void num8_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("8");
                newLine = false;
            }
            else
            {
                addToDisplay("8");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad9
         * */
        private void num9_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("9");
                newLine = false;
            }
            else
            {
                addToDisplay("9");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad4
         * */
        private void num4_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("4");
                newLine = false;
            }
            else
            {
                addToDisplay("4");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad5
         * */
        private void num5_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("5");
                newLine = false;
            }
            else
            {
                addToDisplay("5");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad6
         * */
        private void num6_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("6");
                newLine = false;
            }
            else
            {
                addToDisplay("6");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad1
         * */
        private void num1_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("1");
                newLine = false;
            }
            else
            {
                addToDisplay("1");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad2
         * */
        private void num2_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("2");
                newLine = false;
            }
            else
            {
                addToDisplay("2");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad3
         * */
        private void num3_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (newLine)
            {
                display("3");
                newLine = false;
            }
            else
            {
                addToDisplay("3");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks Numpad0
         * */
        private void num0_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            // If user entered 0 while the calculator display is already showing 0,
            //  then do nothing.
            if (newLine && isOutputDisplayEmpty() )
            {
                newLine = true;
            }
            // If the display has another value and it is being discarded, then print 0
            else if( newLine )
            {
                display("0");
            }
            // If the existing display has a non-zero value and it is not being discarded,
            //  then add 0 to the existing value  
            else
            {
                addToDisplay("0");
                newLine = false;
            }
        }

        /**
         *  Function that handles event created when user clicks C button
         * */
        private void buttonC_Click(object sender, EventArgs e)
        {
            lastInput = 0;
            previousEntryOutput.Text = "";
            clearDisplay();
            newLine = true;
            lastOperation = null;
            operations.Clear();
        }

        /**
         *  Function that handles event created when user clicks CE button
         * */
        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            lastInput = 0;
            clearDisplay();
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Backspace button
         * */
        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (output.Text.Length == 1)
            {
                newLine = true;
                clearDisplay();
            }
            else
            {
                display( output.Text.Remove(output.Text.Length - 1, 1) );
            }
        }

        /**
         *  Function that handles event created when user clicks Sign Change button
         * */
        private void buttonSign_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if (isOutputDisplayEmpty())
            {
                ;
            }
            else if (output.Text[0] == '-')
            {
                display(output.Text.Remove(0, 1));
            }
            else
            {
                display("-" + output.Text);
            }
        }

        /**
         *  Function that handles event created when user clicks Decimal button
         * */
        private void buttonDot_Click(object sender, EventArgs e)
        {
            lastInput = 0;

            if ( newLine == true )
            {
                display("0.");
            }
            else if (!output.Text.Contains("."))
            {
                addToDisplay(".");
            }

            newLine = false;
        }

        /**
         *  Function that handles event created when user clicks Subtract button
         * */
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 1)
            {
                return;
            }
            else if( lastInput == 1 )
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 1));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 1));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Add button
         * */
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 2)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 2));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 2));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Multiply button
         * */
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 3)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 3));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 3));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Divide button
         * */
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            // If user pressed any of the operation button more than once in a row
            // Ignore that input
            if (lastInput == 1 && operations[operations.Count - 1].operation == 4)
            {
                return;
            }
            else if (lastInput == 1)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new Operation(Convert.ToDouble(output.Text), 4));
                displayPreviousEntries();
            }
            else
            {
                operations.Add(new Operation(Convert.ToDouble(output.Text), 4));
                displayPreviousEntries();
                calculate();
            }

            lastInput = 1;
            newLine = true;
        }

        /**
         *  Function that handles event created when user clicks Equals button
         * */
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            // If there are any queued operations, add the last operand and perform calculation. Clear the operations queue.
            if (operations.Count > 0)
            {
                // Cache last operation
                lastOperation = new Operation(Convert.ToDouble(output.Text), operations[operations.Count - 1].operation);
                operations.Add(lastOperation);
                calculate();
                operations.Clear();
                clearPreviousEntryDisplay();
            }
            // If there is no queued operations, but last operation has cache, then perform the last operation.
            else if ( lastOperation != null )
            {
                double value = Convert.ToDouble(output.Text);

                switch( lastOperation.operation )
                {
                    case 1:
                        output.Text = Convert.ToString(value - lastOperation.number);
                        break;
                    case 2:
                        output.Text = Convert.ToString(value + lastOperation.number);
                        break;
                    case 3:
                        output.Text = Convert.ToString(value * lastOperation.number);
                        break;
                    case 4:
                        output.Text = Convert.ToString(value / lastOperation.number);
                        break;
                }
            }
            // Do nothing if above 2 conditions aren't met.
            else
            {
                ;
            }

            newLine = true;
            lastInput = 0;
        }

        /**
         *  Function that performs calculation based on the value of operation and currentNum
         * */
        private async void calculate()
        {
            // Requires at least 2 operands to perform calculation
            if( operations.Count < 2 )
            {
                return;
            }
            else
            {
                double newValue = operations[0].number;

                for ( int i = 0; i < operations.Count - 1; i++ )
                {
                    switch( operations[i].operation )
                    {
                        case 1:
                            newValue = newValue - operations[i + 1].number;
                            break;
                        case 2:
                            newValue = newValue + operations[i + 1].number;
                            break;
                        case 3:
                            newValue = newValue * operations[i + 1].number;
                            break;
                        case 4:
                            if( operations[i + 1].number == 0 )
                            {
                                display("Division By Zero");
                                await Task.Delay( 1500 );
                                buttonC.PerformClick();
                                return;
                            }

                            newValue = newValue / operations[i + 1].number;
                            break;
                    }
                }

                display(Convert.ToString(newValue));
            }
        }

        /**
         *  Function that clears the contents of the Previous Entry Display Window
         * */
        private void clearPreviousEntryDisplay()
        {
            previousEntryOutput.Text = "";
        }

        /**
         *  Function that set new literal to previous entry Display window.
         *  @param literal string literal to add to the display
         * */
        private void displayPreviousEntries()
        {
            string newLiteral = "";

            for( int i = 0; i < operations.Count; i++ )
            {
                newLiteral += operations[i].number;
                
                switch( operations[i].operation )
                {
                    case 1:
                        newLiteral += " - ";
                        break;
                    case 2:
                        newLiteral += " + ";
                        break;
                    case 3:
                        newLiteral += " * ";
                        break;
                    case 4:
                        newLiteral += " / ";
                        break;
                }
            }

            if( newLiteral.Length > 62 )
            {
                previousEntryOutput.Text = newLiteral.Remove(62);
            }
            else
            {
                previousEntryOutput.Text = newLiteral;
            }
        }

        /**
         *  Function that changes the display of calculator to the given string literal.
         *  @param toDisplay String literal to display on the screen
         * */
        private void display( string toDisplay )
        {
            if( toDisplay.Length > 16 )
            {
                output.Text = toDisplay.Remove(16);
            }
            else
            {
                output.Text = toDisplay;
            }
        }

        /**
         *  Function that displays the given string literal in addition to current displayed content
         *  @param toDisplay String literal to add to the display screen
         * */
        private void addToDisplay(string toAdd)
        {
            string newString = output.Text + toAdd;

            if (newString.Length > 16)
            {
                output.Text = newString.Remove(16);
            }
            else
            {
                output.Text = newString;
            }
        }

        /**
         *  Function that clears the display contents
         * */
        private void clearDisplay()
        {
            output.Text = "0";
        }

        /**
         *  Output display is considered "empty" if it is only diplaying 0
         *  @return isEmpty true if the output display is only showing 0
         * */
        private bool isOutputDisplayEmpty()
        {
            return output.Text == "0";
        }

        /**
         *  Override ProcessCmdKey so that the form receives keyboard input before any other components
         *  and handle the event. 
         * */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch( keyData )
            {
                case Keys.NumPad9:
                    num9.PerformClick();
                    return true;
                case Keys.NumPad8:
                    num8.PerformClick();
                    return true;
                case Keys.NumPad7:
                    num7.PerformClick();
                    return true;
                case Keys.NumPad6:
                    num6.PerformClick();
                    return true;
                case Keys.NumPad5:
                    num5.PerformClick();
                    return true;
                case Keys.NumPad4:
                    num4.PerformClick();
                    return true;
                case Keys.NumPad3:
                    num3.PerformClick();
                    return true;
                case Keys.NumPad2:
                    num2.PerformClick();
                    return true;
                case Keys.NumPad1:
                    num1.PerformClick();
                    return true;
                case Keys.NumPad0:
                    num0.PerformClick();
                    return true;
                case Keys.Subtract:
                    buttonMinus.PerformClick();
                    return true;
                case Keys.Add:
                    buttonPlus.PerformClick();
                    return true;
                case Keys.Multiply:
                    buttonMultiply.PerformClick();
                    return true;
                case Keys.Divide:
                    buttonDivide.PerformClick();
                    return true;
                case Keys.Enter:
                    buttonEquals.PerformClick();
                    return true;
                case Keys.Escape:
                    buttonC.PerformClick();
                    return true;
                case Keys.Back:
                    buttonBackspace.PerformClick();
                    return true;
                case Keys.Decimal:
                    buttonDot.PerformClick();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
