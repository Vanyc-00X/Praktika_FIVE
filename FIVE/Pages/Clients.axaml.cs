using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace FIVE;

public partial class Clients : UserControl
{
    public Clients()
    {
        InitializeComponent();
        var otbor = App.DbContext.Users.Where(t => t.IdRole == 3).ToList();
        DataClient.ItemsSource = otbor;
    }
}