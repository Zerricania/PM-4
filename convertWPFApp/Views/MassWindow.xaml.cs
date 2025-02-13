using System.Windows;
using System.Windows.Controls;

namespace convertWPFApp.Views;

public partial class MassWindow : Window
{
    public MassWindow()
    {
        InitializeComponent();
    }

    private void massConvertButton_Click(object sender, RoutedEventArgs e)
    {
        double inputValue;
        if (double.TryParse(InputTextBox.Text, out inputValue))
        {
            string? fromUnit = ((ComboBoxItem)FromComboBox.SelectedItem)?.Content.ToString();
            string? toUnit = ((ComboBoxItem)ToComboBox.SelectedItem)?.Content.ToString();

            if (fromUnit != null && toUnit != null)
            {
                double result = ConvertMass(inputValue, fromUnit, toUnit);
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

    private double ConvertMass(double value, string from, string to)
    {
        var exchangeRates = new Dictionary<string, double>
        {
            { "Gram", 1 },       
            { "Kilogram", 1000 },   
            { "Pound", 453.5 }      
        };

        if (exchangeRates.ContainsKey(from) && exchangeRates.ContainsKey(to))
        {
            double valueInGram = value * exchangeRates[from]; 
            return valueInGram / exchangeRates[to]; 
        }

        return value; 
    }
}