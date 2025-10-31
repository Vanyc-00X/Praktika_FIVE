using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using FIVE.Models;
using FIVE.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIVE;

public partial class BAbaBA : UserControl
{
    public static List<Basket> otbor {  get; set; }
    public static List<BaPol> otbor2 { get; set; }

    public void ReFresh()
    {
        if (GlobalVariables.PravNumber == 3)
        {
            DataBasket.IsVisible = false;
            otbor = App.DbContext.Baskets
           .Where(t => t.IdUser == UserVariableData.SelectedUserData.IdUser)
           .Include(b => b.IdTovarNavigation).ToList();
            DataBasket.ItemsSource = otbor;
        }
        else
        {
            DataPolBa.IsVisible = false;
            otbor2 = App.DbContext.BaPols.ToList();
            DataPolBa.ItemsSource = otbor2;


        }
        
        ReFresh();
    }
    public BAbaBA()
    {
        InitializeComponent();
        GlobalVariables.PravNumber = UserVariableData.SelectedUserData.IdRole;





        if (GlobalVariables.PravNumber == 3)
        {
            DataPolBa.IsVisible = false;
            otbor = App.DbContext.Baskets
           .Where(t => t.IdUser == UserVariableData.SelectedUserData.IdUser)
           .Include(b => b.IdTovarNavigation).ToList();
            DataBasket.ItemsSource = otbor;
        }
        else
        {
            
            DataBasket.IsVisible = false;
            otbor2 = App.DbContext.BaPols.ToList();
            DataPolBa.ItemsSource = otbor2;


        }

    }
    private MainWindow? GetWindow()
    {
        return this.VisualRoot as MainWindow;
    }

    


    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is int basketId && UserVariableData.SelectedUserData.IdRole != 3)
        {
            
            var basketToDelete = App.DbContext.Baskets
                .FirstOrDefault(b => b.IdBasket == basketId);

            if (basketToDelete != null)
            {
                App.DbContext.Baskets.Remove(basketToDelete);
                await App.DbContext.SaveChangesAsync();

                
                var otbor = App.DbContext.Baskets
                    .Where(t => t.IdUser == UserVariableData.SelectedUserData.IdUser)
                    .Include(b => b.IdTovarNavigation)
                    .ToList();
                DataBasket.ItemsSource = otbor;
            }
        }
        ReFresh();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {

        var selectedTovar = DataBasket.SelectedItem as Basket;


       UserVariableData.SelectBasket = selectedTovar;

       var asd = new EditBabbababa();
        await asd.ShowDialog(GetWindow());
        ReFresh();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GlobalVariables.PravNumber == 3 && DataBasket.ItemsSource != null)
        {
            
            var d = otbor;
            string text = "";
            foreach (var item in otbor)
            {
                var kod_tov = item.IdTovar;
                var count = item.CountTovar;
                
                text += $" количество: {count}  товар:{kod_tov} ";
            }





            var bagdjd = new BaPol()
            {
                IdTovar = text,
                IdUser = UserVariableData.SelectedUserData.IdUser,
                Count = "АПЕЛЬСИН"

            };


            
            App.DbContext.BaPols.Add(bagdjd);
           
            App.DbContext.SaveChanges();

        }
        else
        {
            return;

        }

    }
}