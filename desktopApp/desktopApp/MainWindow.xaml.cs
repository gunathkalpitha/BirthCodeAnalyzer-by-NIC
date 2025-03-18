using System;
using System.Windows;
using NIC_project;

namespace BirthCodeAnalyzer
{
    public partial class MainWindow : Window
    {
        private Nic nicAnalyzer;

        public MainWindow()
        {
            InitializeComponent();
            nicAnalyzer = new Nic();
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string nicNumber = txtNIC.Text;

            if (string.IsNullOrEmpty(nicNumber))
            {
                lblResult.Text = "Please enter a valid NIC number.";
                return;
            }

          
            lblResult.Text = "";

          
            nicAnalyzer.GetNic(nicNumber);

          
            string result = nicAnalyzer.Analyze();

 
            lblResult.Text = result;
        }
    }
}