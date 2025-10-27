using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using FIVE.Models;
using FIVE.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIVE;

public partial class Clients : UserControl
{
    public Clients()
    {
        InitializeComponent();
        var otbor = App.DbContext.Users.Where(t => t.IdRole == 3).Include(b => b.IdHumanNavigation).ToList();
        DataClient.ItemsSource = otbor;
        RefreshData();
    }
    private void RefreshData()
    {
        var otbor = App.DbContext.Users.Where(t => t.IdRole == 3).ToList();
        DataClient.ItemsSource = otbor;
    }
    private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is User user)
        {
            App.DbContext.Users.Remove(user);
            App.DbContext.SaveChanges();
            RefreshData();





        }
    }
    private MainWindow? GetWindow()
    {
        return this.VisualRoot as MainWindow;
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedKL = DataClient.SelectedItem as User;

        if (selectedKL != null)
        {

            UserVariableData.SelectedUserData = selectedKL;


            var cardTovar = new ReDaCt();
            await cardTovar.ShowDialog(GetWindow());
            RefreshData();

        }
    }
}