using System;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class Form1 : Form
    {
        private string currentInput = ""; 
        private string operation = "";
        private double firstNumber = 0; 
        private double secondNumber = 0; 

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text; 
            resultTextBox.Text = currentInput; 
        }

        private void buttonOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = Convert.ToDouble(currentInput); 
            operation = button.Text; 
            currentInput = ""; 
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            secondNumber = Convert.ToDouble(currentInput);

            double result = 0; 

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0) 
                        result = firstNumber / secondNumber;
                    else
                        MessageBox.Show("Cannot divide by zero");
                    break;
            }

            resultTextBox.Text = result.ToString();
            currentInput = ""; 
            operation = ""; 
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            currentInput = ""; 
            resultTextBox.Text = ""; 
            firstNumber = 0;
            secondNumber = 0; 
            operation = ""; 
        }
    }
}
