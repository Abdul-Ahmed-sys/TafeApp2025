using System;
using System.Windows;
using System.Windows.Controls;

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = cProduct.TotalPayment.ToString("C");

                // Add Wrap Charge ($5.00)
                decimal totalAfterWrap = cProduct.TotalPayment + 5.00m;
                wrapChargeTextBox.Text = totalAfterWrap.ToString("C");

                // Add Delivery Charge ($25.00)
                decimal totalAfterDelivery = totalAfterWrap + 25.00m;
                totalChargeTextBox.Text = totalAfterDelivery.ToString("C");

                // Add GST (x1.1)
                decimal totalAfterGST = totalAfterDelivery * 1.1m;
                gstChargeTextBox.Text = totalAfterGST.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            wrapChargeTextBox.Text = "";
            totalChargeTextBox.Text = "";
            gstChargeTextBox.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
