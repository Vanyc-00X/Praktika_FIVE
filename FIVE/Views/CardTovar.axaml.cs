using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using FIVE.Models;
using FIVE.Views;
using System.Threading.Tasks;

namespace FIVE;

public partial class CardTovar : Window
{
    public CardTovar()
    {
        InitializeComponent();
        DataContext = UserVariableData.SelectedTovarData;
        ManeTovarText.Text = UserVariableData.SelectedTovarData.NameTovar;
        SellText.Text = UserVariableData.SelectedTovarData.Sell.ToString();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {   
            if(GlobalVariables.PravNumber != 3) {
            try
            {
                var TovarDataContext = DataContext as Tovar;
                if (TovarDataContext != null)
                {
                    App.DbContext.Tovars.Update(TovarDataContext);
                    App.DbContext.SaveChanges();
                }
            }
            catch { return; }
            
            }
            else { ShowError(); }
        
            Close();


    }
    private MainWindow? GetWindow()
    {
        return this.VisualRoot as MainWindow;
    }

   

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        GlobalVariables.FrameModde = 2;
        Button_Click(sender, e);
    }

    private async Task ShowError()
    {
        var messageBox = new Window
        {
            Title = "Œ¯Ë·Í‡",
            Content = new TextBlock { Text = "Õ≈“” œ–¿¬" },
            Width = 300,
            Height = 150
        };
        await messageBox.ShowDialog(this);
    }
}