using System.Windows;
using System.Windows.Controls;

namespace convertWPFApp.Views;

public partial class LenghWindow : Window
{
    public LenghWindow()
    {
        InitializeComponent();
    }

    private void LenghConvertButton_OnClick(object sender, RoutedEventArgs e)
    {
        double inputValue;
        if (double.TryParse(InputTextBox.Text, out inputValue))
        {
            string? fromUnit = ((ComboBoxItem)FromComboBox.SelectedItem)?.Content.ToString();
            string? toUnit = ((ComboBoxItem)ToComboBox.SelectedItem)?.Content.ToString();

            if (fromUnit != null && toUnit != null)
            {
                double result = ConvertLengh(inputValue, fromUnit, toUnit);
                ResultTextBlock.Text = $"{inputValue} {fromUnit} = {result:F2} {toUnit}";
            }
            else
            {
                MessageBox.Show("Please select both currencies.");
            }
        }
        else
        {
            MessageBox.Show("Please enter a valid number.");
        }
    }

    private double ConvertLengh(double value, string from, string to)
    {
        var exchangeRates = new Dictionary<string, double>
        {
            { "Metres", 1 },       
            { "Kilometres", 1000},   
            { "Centimetres", 0.01}      
        };

        if (exchangeRates.ContainsKey(from) && exchangeRates.ContainsKey(to))
        {
            double valueInMetres = value * exchangeRates[from]; 
            return valueInMetres / exchangeRates[to]; 
        }

        return value; 
    }
}