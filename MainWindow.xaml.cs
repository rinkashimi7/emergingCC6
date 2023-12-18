using System.Windows;

using EmployeeWPF.ViewModels;
namespace EmployeeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
        }
    }
}
