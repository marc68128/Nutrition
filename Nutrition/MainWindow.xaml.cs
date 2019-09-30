using Nutrition.ViewModels.Contracts;
using System.Windows;

namespace Nutrition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IMainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
