namespace CalculatorWithDelegates
{
    //DELEGATE
    delegate double Operation(int i, int j);
    
    public partial class MainPage : ContentPage
    {
        //Using DELEGATE
        static double Result(string exp)
        {
            string x = "", y = "";
            int k = 0;
            while (exp[k] >= '0' && exp[k] <= '9')
            {
                x += exp[k];
                k++;
            }

            for (int i = k + 1; i < exp.Length; i++)
                y += exp[i];

            if (exp[k] == '+')
            {
                Operation op1 = new Operation(Sum);
                return op1(int.Parse(x), int.Parse(y));

            }
            if (exp[k] == '-')
            {
                Operation op2 = new Operation(Sub);
                return op2(int.Parse(x), int.Parse(y));

            }
            if (exp[k] == '*')
            {
                Operation op3 = new Operation(Mul);
                return op3(int.Parse(x), int.Parse(y));

            }
            Operation op = new Operation(Div);
            return op(int.Parse(x), int.Parse(y));

        }
        //אפשר להוסיף פעולות חשבוניות נוספות
        static double Sum(int i, int j)
        { return i + j; }
        static double Mul(int i, int j)
        { return i * j; }
        static double Sub(int i, int j)
        { return i - j; }
        static double Div(int i, int j)
        { return (double)i / j; }

        public MainPage()
        {
            InitializeComponent();



            foreach (IElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Clicked += Button_Click;
                }
            }

        }


        //with delegate
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Text;

            if (str == "AC")
                textLabel.Text = "";
            else if (str == "=")
            {
                //string? v = new DataTable().Compute(textLabel.Text, null).ToString();//כך היה קודם
                string? v = Result(textLabel.Text).ToString();
                textLabel.Text += " = " + v;
            }
            else
            {

                textLabel.Text += str;

            }
        }


    }
}
