using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace Reflector
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuCloseItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowAssemblyInformation(string path)
        {
            Assembly assembly = Assembly.LoadFile(path);
            textBox.Text = $"Main information about assembly: {assembly.FullName}" + Environment.NewLine + Environment.NewLine;
            Type[] types = assembly.GetTypes();
            textBox.Text += "Types of assembly:" + Environment.NewLine + Environment.NewLine;
            foreach (var type in types)
            {
                textBox.Text += $"Type : {type}" + Environment.NewLine;
                MethodInfo[] methods = type.GetMethods();
                if (methods != null)
                {
                    textBox.Text += "Methods of this type:" + Environment.NewLine;
                    foreach (var method in methods)
                        textBox.Text += $"Method: {method.Name}" + Environment.NewLine;
                    textBox.Text += Environment.NewLine;
                }
            }
        }

        private void MenuOpenItem_Click(object sender, RoutedEventArgs e)
        {
            var path = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            path = fileDialog.FileName;
            try
            {
                ShowAssemblyInformation(path);
            }
            catch(Exception)
            {
                System.Windows.MessageBox.Show("Select the .exe of the C# program or its .dll.", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }
        }
    }
}