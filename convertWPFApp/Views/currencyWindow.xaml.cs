using System.Windows;
using System.Windows.Controls;

namespace convertWPFApp.Views;

public partial class CurrencyWindow
{
    public CurrencyWindow()
    {
        InitializeComponent();
    }

    private void ConvertButton_Click(object sender, RoutedEventArgs e)
    {
        double inputValue;
        if (double.TryParse(InputTextBox.Text, out inputValue))
        {
            string? fromUnit = ((ComboBoxItem)FromComboBox.SelectedItem)?.Content.ToString();
            string? toUnit = ((ComboBoxItem)ToComboBox.SelectedItem)?.Content.ToString();

            if (fromUnit != null && toUnit != null)
            {
                double result = ConvertCurrency(inputValue, fromUnit, toUnit);
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

    private double ConvertCurrency(double value, string from, string to)
    {
        var exchangeRates = new Dictionary<string, double>
        {
            { "Tenge", 1 },       
            { "Dollar", 470 },   
            { "Ruble", 5.3 }      
        };

        if (exchangeRates.ContainsKey(from) && exchangeRates.ContainsKey(to))
        {
            double valueInKzt = value * exchangeRates[from]; 
            return valueInKzt / exchangeRates[to]; 
        }

        return value; 
    }
}