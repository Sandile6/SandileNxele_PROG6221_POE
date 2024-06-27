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
using System.Windows.Shapes;

namespace SanelePoe
{
    /// <summary>
    /// Interaction logic for AddStepWindow.xaml
    /// </summary>
    public partial class AddStepWindow : Window
    {
        public string NewStep { get; private set; }

        public AddStepWindow()
        {
            InitializeComponent();
        }

        private void SaveStep_Click(object sender, RoutedEventArgs e)
        {
            NewStep = StepDescriptionTextBox.Text;
            if (!string.IsNullOrEmpty(NewStep))
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter the step description.");
            }
        }
    }
}