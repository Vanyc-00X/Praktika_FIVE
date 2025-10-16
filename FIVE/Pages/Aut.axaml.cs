using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using FIVE.Views;
using System.Threading.Tasks;

namespace FIVE;

public partial class Aut : UserControl
{
    public Aut()
    {
        InitializeComponent();
    }

    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    private MainWindow? GetOkno()
    {
        return this.VisualRoot as MainWindow;
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var goWork = new GoWork();
        await goWork.ShowDialog(GetWindow());
        GetOkno().FoundOkno();
    }

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var CreateCl = new CreateClient();
        await CreateCl.ShowDialog(GetWindow());

    }
}