namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, EventArgs e)
        {
            
        
            Button btn = sender as Button;
            if (btn == null) return;

            string value = btn.Text;

            // Check whether it is a number
            if (int.TryParse(value, out int digit))
            {
                textBox1.Text += digit.ToString();
            }
            else
            {
                // Operators or special functions
                switch (value)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        textBox1.Text += " " + value + " ";
                        break;
                    case "=":
                        CalculateResult();
                        break;
                    case "C":
                        textBox1.Text = "";
                        break;
                    case ",":
                        textBox1.Text += ",";
                        break;
                }
            }
        }

        private void CalculateResult()
        {
            try
            {
                // Split the text, e.g. '12 + 5'
                string[] parts = textBox1.Text.Split(' ');
                if (parts.Length != 3)
                {
                    textBox1.Text = "Invalid expression";
                    return;
                }

                double number1 = double.Parse(parts[0]);
                string op = parts[1];
                double number2 = double.Parse(parts[2]);

                double result = 0;

                switch (op)
                {
                    case "+": result = number1 + number2; break;
                    case "-": result = number1 - number2; break;
                    case "*": result = number1 * number2; break;
                    case "/":
                        if (number2 == 0)
                        {
                            textBox1.Text = "Division by zero!";
                            return;
                        }
                        result = number1 / number2;
                        break;
                }

                // Display result
                textBox1.Text = $"{number1} {op} {number2} = {result}";
            }
            catch
            {
                textBox1.Text = "Error while calculating!";
            }
        }
    }
}
  

