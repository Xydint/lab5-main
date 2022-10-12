using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab5.ViewModels;

namespace lab5.Views
{
    public partial class SubWindowRegex : Window
    {
        public SubWindowRegex()
        {

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.FindControl<Button>("OkButton").Click += async delegate
            {
                (this.DataContext as MainWindowViewModel).RegexString =
                (this.DataContext as MainWindowViewModel).RegexStringNew;
                Close();
            };

            this.FindControl<Button>("CancelButton").Click += async delegate
            {
                (this.DataContext as MainWindowViewModel).RegexStringNew =
                (this.DataContext as MainWindowViewModel).RegexString;
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
