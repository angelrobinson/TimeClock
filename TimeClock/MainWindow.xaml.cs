using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Types
        {
            CODING,
            RESEARCH,
            TESTING
        }

        private const decimal codeWage = 25.00m;
        private const decimal researchWage = 16.00m;
        private const decimal testingWage = 20.00m;
        private DateTime timeIn;
        private DateTime timeOut;
        private double codeTimeWorked;
        private double researchTimeWorked;
        private double testingTimeWorked;
        private string typeOfWork;

        public MainWindow()
        {
            InitializeComponent();
            clockIN.IsEnabled = false;
            clockOUT.IsEnabled = false;
            
            
        }

        private void clockIN_Click(object sender, RoutedEventArgs e)
        {
            timeIn = DateTime.Now;
            richTextBox.AppendText($"Clocked in: {timeIn}");
            richTextBox.AppendText(Environment.NewLine);
            clockIN.IsEnabled = false;
            clockOUT.IsEnabled = true;
        }

        private void clockOUT_Click(object sender, RoutedEventArgs e)
        {
            timeOut = DateTime.Now;
            richTextBox.AppendText($"Clocked out: {timeOut}");
            richTextBox.AppendText(Environment.NewLine);
            clockOUT.IsEnabled = false;
            clockIN.IsEnabled = true;
            setHoursWorked();

        }

        private void setHoursWorked()
        {
            if (typeOfWork == Types.CODING.ToString())
            {
                codeTimeWorked += timeOut.Subtract(timeIn).TotalHours;
                richTextBox.AppendText($"Coding time spent: {codeTimeWorked.ToString("N2")}");
                richTextBox.AppendText(Environment.NewLine);
            }
            else if (typeOfWork == Types.RESEARCH.ToString())
            {
                researchTimeWorked += timeOut.Subtract(timeIn).TotalHours;
                richTextBox.AppendText($"Research time spent: {researchTimeWorked.ToString("N2")}");
                richTextBox.AppendText(Environment.NewLine);
            }
            else if (typeOfWork == Types.TESTING.ToString())
            {
                testingTimeWorked += timeOut.Subtract(timeIn).TotalHours;
                richTextBox.AppendText($"Testing time spent: {testingTimeWorked.ToString("N2")}");
                richTextBox.AppendText(Environment.NewLine);
            }
        }

        private void workType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (workType.SelectedIndex)
            {
                case 0:
                    typeOfWork = Types.RESEARCH.ToString();
                    break;
                case 2:
                    typeOfWork = Types.TESTING.ToString();
                    break;
                default:
                    typeOfWork = Types.CODING.ToString();
                    break;
            }

            clockIN.IsEnabled = true;
            richTextBox.AppendText($"Type of work: {typeOfWork}");
            richTextBox.AppendText(Environment.NewLine);
        }

        private void calc_Click(object sender, RoutedEventArgs e)
        {
            decimal codePrice = (decimal) codeTimeWorked * codeWage;
            decimal reserchPrice = (decimal)codeTimeWorked * researchWage;
            decimal testingPrice = (decimal)codeTimeWorked * testingWage;
            decimal totalPrice = codePrice + reserchPrice + testingPrice;

            richTextBox.AppendText($"Coding: {codePrice}");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText($"Research: {reserchPrice}");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText($"Testing: {testingPrice}");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText($"Total: {totalPrice}");
            richTextBox.AppendText(Environment.NewLine);
        }
    }
}
