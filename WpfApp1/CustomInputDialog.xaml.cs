using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CustomInputDialog.xaml
    /// </summary>
    public partial class CustomInputDialog : Window
    {
        private List<string> inputValues;
        public int size = 20;

        public CustomInputDialog(int numFields, List<string> labels)
        {
            InitializeComponent();

            // Set the font family to Cascadia Code
            FontFamily cascCodeFontFamily = new FontFamily("Cascadia Code");

            // Initialize the inputValues list with empty strings
            this.inputValues = new List<string>(numFields);
            for (int i = 0; i < numFields; i++)
            {
                inputValues.Add("");
            }

            // Create text fields and labels dynamically
            for (int i = 0; i < numFields; i++)
            {
                string labelText = labels[i];
                Label label = new Label() { Content = labelText, FontSize = size, FontFamily = cascCodeFontFamily };
                TextBox textBox = new TextBox() { Height = size, FontFamily = cascCodeFontFamily };

                // Create Border around the TextBox and set CornerRadius
                Border textBoxBorder = new Border();
                textBoxBorder.CornerRadius = new CornerRadius(5);
                textBoxBorder.BorderThickness = new Thickness(0.5);
                textBoxBorder.BorderBrush = SystemColors.ControlDarkBrush;
                textBoxBorder.Child = textBox;

                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto }); // Set TextBox height
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto }); // Set Label height

                // Add some margin between the Label and TextBox
                Grid.SetRow(label, 0);
                Grid.SetColumn(label, 0);
                Grid.SetRow(textBoxBorder, 1);
                Grid.SetColumn(textBoxBorder, 0);

                grid.Children.Add(label);
                grid.Children.Add(textBoxBorder);

                // Add the grid to the StackPanel
                dynamicContentPanel.Children.Add(grid);

                // Add a listener to the text field to store its value in the list
                int index = i; // To capture the current value of 'i'
                textBox.TextChanged += (sender, e) =>
                {
                    inputValues[index] = textBox.Text;
                };
            }

            Loaded += CustomInputDialog_Loaded;

        }

        private void CustomInputDialog_Loaded(object sender, RoutedEventArgs e)
        {
            // Calculate the total height of the dynamic content and button
            double totalHeight = dynamicContentPanel.ActualHeight + (size * 2) + OKButton.ActualHeight + 10; // Add some extra padding
            this.Height = totalHeight;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public List<string> GetInputValues()
        {
            return inputValues;
        }
    }
}
