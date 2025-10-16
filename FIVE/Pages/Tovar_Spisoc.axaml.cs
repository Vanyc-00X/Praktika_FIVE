using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using FIVE.Models;
using FIVE.Views;
using System.Linq;

namespace FIVE;

public partial class Tovar_Spisoc : UserControl
{
    public Tovar_Spisoc()
    {
        InitializeComponent();
        DataTovar.ItemsSource = App.DbContext.Tovars.ToList();
        ReData();
       
    }
    private MainWindow? GetWindow()
    {
        return this.VisualRoot as MainWindow;
    }
    private async void DrOkno()
    {
        var Sla = new Slauder();
        await Sla.ShowDialog(GetWindow());
        Zap();
    }
    private async void Zap()
    {
        UserVariableData.SelectBasket = new Basket();
        UserVariableData.SelectBasket.CountTovar = GlobalVariables.CountTovar;
        UserVariableData.SelectBasket.IdUser = UserVariableData.SelectedUserData.IdUser;
        UserVariableData.SelectBasket.IdTovar = UserVariableData.SelectedTovarData.IdTovar;

        App.DbContext.Baskets.Add(UserVariableData.SelectBasket as Basket);
        App.DbContext.SaveChanges();
    }

    public void ReData()
    {
        DataTovar.ItemsSource = App.DbContext.Tovars.ToList();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedTovar = DataTovar.SelectedItem as Tovar; // «амените Tovar на фактическое им€ класса модели товара

        if (selectedTovar != null)
        {
            
            UserVariableData.SelectedTovarData = selectedTovar;

            
            var cardTovar = new CardTovar();
            await cardTovar.ShowDialog(GetWindow());

        }
        if (GlobalVariables.FrameModde == 2)
        {
            DrOkno();
        }

    }
}