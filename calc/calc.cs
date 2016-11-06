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
        bool newLine = true;
        bool multiOperation = false;
        double currentNum = 0;
        int operation = 0;

        public basicCalculator()
        {
            InitializeComponent();
        }

        private void num7_Click(object sender, EventArgs e)
        {
            if(newLine)
            {
                output.Text = "7";
                newLine = false;
            }
            else
            {
                output.Text += 7;
                newLine = false;
            }
        }

        private void num8_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "8";
                newLine = false;
            }
            else
            {
                output.Text += 8;
                newLine = false;
            }
        }

        private void num9_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "9";
                newLine = false;
            }
            else
            {
                output.Text += 9;
                newLine = false;
            }
        }

        private void num4_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "4";
                newLine = false;
            }
            else
            {
                output.Text += 4;
                newLine = false;
            }
        }

        private void num5_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "5";
                newLine = false;
            }
            else
            {
                output.Text += 5;
                newLine = false;
            }
        }

        private void num6_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "6";
                newLine = false;
            }
            else
            {
                output.Text += 6;
                newLine = false;
            }
        }

        private void num1_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "1";
                newLine = false;
            }
            else
            {
                output.Text += 1;
                newLine = false;
            }
        }

        private void num2_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "2";
                newLine = false;
            }
            else
            {
                output.Text += 2;
                newLine = false;
            }
        }

        private void num3_Click(object sender, EventArgs e)
        {
            if (newLine)
            {
                output.Text = "3";
                newLine = false;
            }
            else
            {
                output.Text += 3;
                newLine = false;
            }
        }

        private void num0_Click(object sender, EventArgs e)
        {
            if (newLine && output.Text == "0" )
            {
                newLine = true;
            }
            else if( newLine )
            {
                output.Text = "0";
            }
            else
            {
                output.Text += 0;
                newLine = false;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            previousEntryOutput.Text = "";
            output.Text = "0";
            operation = 0;
            currentNum = 0;
            newLine = true;
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            output.Text = "0";
            newLine = true;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (output.Text.Length == 1)
            {
                newLine = true;
                output.Text = "0";
            }
            else
            {
                output.Text = output.Text.Remove(output.Text.Length - 1, 1);
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (output.Text[0] != '-' && output.Text != "0")
            {
                string text = output.Text;
                output.Text = '-' + text;
            }
            else if (output.Text[0] == '-')
            {
                output.Text = output.Text.Remove(0, 1);
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if( newLine == true )
            {
                output.Text = "0.";
            }
            else if (!output.Text.Contains("."))
            {
                output.Text += '.';
            }

            newLine = false;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            previousEntryOutput.Text += (output.Text + " - ");

            if (multiOperation)
            {
                calculate();
                output.Text = Convert.ToString(currentNum);
            }
            else
            {
                currentNum = Convert.ToDouble(output.Text);
                multiOperation = true;
            }

            operation = 1;
            newLine = true;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            previousEntryOutput.Text += (output.Text + " + ");

            if (multiOperation)
            {
                calculate();
                output.Text = Convert.ToString(currentNum);
            }
            else
            {
                currentNum = Convert.ToDouble(output.Text);
                multiOperation = true;
            }

            operation = 2;
            newLine = true;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            previousEntryOutput.Text += (output.Text + " * ");

            if (multiOperation)
            {
                calculate();
                output.Text = Convert.ToString(currentNum);
            }
            else
            {
                currentNum = Convert.ToDouble(output.Text);
                multiOperation = true;
            }

            operation = 3;
            newLine = true;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            previousEntryOutput.Text += (output.Text + " / ");

            if (multiOperation)
            {
                calculate();
                output.Text = Convert.ToString(currentNum);
            }
            else
            {
                currentNum = Convert.ToDouble(output.Text);
                multiOperation = true;
            }

            operation = 4;
            newLine = true;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if( operation > 0 )
            {
                calculate();

                output.Text = Convert.ToString(currentNum);
            }

            previousEntryOutput.Text = "";
            multiOperation = false;
            operation = 0;
            newLine = true;
        }

        void calculate()
        {
            switch (operation)
            {
                case 1:
                    currentNum = currentNum - Convert.ToDouble(output.Text);
                    break;
                case 2:
                    currentNum = currentNum + Convert.ToDouble(output.Text);
                    break;
                case 3:
                    currentNum = currentNum * Convert.ToDouble(output.Text);
                    break;
                case 4:
                    currentNum = currentNum / Convert.ToDouble(output.Text);
                    break;
            }
        }

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
