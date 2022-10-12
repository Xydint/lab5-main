using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab5.ViewModels;

namespace lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.FindControl<Button>("OpenFile").Click += async delegate
             {
                 var taskPath = new OpenFileDialog()
                 {
                     Title = "Open file",
                     Filters = null
                 }.ShowAsync((Window)this.VisualRoot);

                 string[]? path = await taskPath;

                 var context = this.DataContext as MainWindowViewModel;
                 context.PathOpen = path is null ? null : string.Join(@"\", path);
             };
            this.FindControl<Button>("SaveFile").Click += async delegate
             {
                 var taskPath = new OpenFileDialog()
                 {
                     Title = "Save file",
                     Filters = null
                 }.ShowAsync((Window)this.VisualRoot);

                 string[]? path = await taskPath;

                 var context = this.DataContext as MainWindowViewModel;
                 context.PathSave = path is null ? null : string.Join(@"\", path);
             };
        }

        private async void OpenSubWindowRegex(object sender, RoutedEventArgs e)
        {
            var w = new SubWindowRegex();
            w.DataContext = this.DataContext as MainWindowViewModel;
            w.ShowDialog((Window)this.VisualRoot);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
