using DataEditTool.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DataEditTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EditorViewModel vm;

        public MainWindow(IServiceProvider provider)
        {
            InitializeComponent();

            vm = provider.GetService<EditorViewModel>();
            DataContext = vm;
        }
    }
}
