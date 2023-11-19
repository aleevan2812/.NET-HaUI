using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
            txb12.Text = txb11.Text;
        }
        public int NativeErrorCode { get; }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            String Valor = "https://youtube.com/";
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = Valor,
                UseShellExecute = true
            };
           // System.Diagnostics.Process.Start(e.Uri.ToString());
            //System.ComponentModel.Win32Exception
            Process.Start(psi);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txb12.Text = txb11.Inlines.ElementAt(0).ToString();
        }
    }
}
