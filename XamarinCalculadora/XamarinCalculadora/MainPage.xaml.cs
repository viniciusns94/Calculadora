using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCalculadora
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int currentState = 1; //determinar qual operador esta sendo inserido primeiro ou segundo termo
        string mathOperator;  //determinar qual dos operadores foi selecionado  
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
            onClear(new object(), new EventArgs());
        }

        void onClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.result_text.Text = "0";
        }

        void onSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.result_text.Text == "0" || currentState < 0)
            {
                this.result_text.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.result_text.Text += pressed;

            double number;
            if (double.TryParse(this.result_text.Text, out number))
            {
                this.result_text.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }
    }
}
