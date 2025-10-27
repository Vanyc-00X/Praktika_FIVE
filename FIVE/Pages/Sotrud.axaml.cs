using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using FIVE.Models;
using FIVE.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FIVE;

public partial class Sotrud : UserControl
{
    public Sotrud()
    {
        InitializeComponent();
        var otbor = App.DbContext.Users.Where(t => t.IdRole != 3).Include(b => b.IdHumanNavigation).ToList();
        DataSotrudnic.ItemsSource = otbor;
    }

    private MainWindow? GetWindow()
    {
        return this.VisualRoot as MainWindow;
    }

    public void RedAte()
    {
        var otbor = App.DbContext.Users.Where(t => t.IdRole != 3).Include(b => b.IdHumanNavigation).ToList();
        DataSotrudnic.ItemsSource = otbor;

    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var creSo = new CreateSotrrud();
        await creSo.ShowDialog(GetWindow());
        RedAte();
    }
    private void DeleteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is User user)
        {
            if (user.IdHumanNavigation != null)
            {
                App.DbContext.Humans.Remove(user.IdHumanNavigation);
            }
            App.DbContext.Users.Remove(user);
            App.DbContext.SaveChanges();
            RedAte();






        }
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedKL = DataSotrudnic.SelectedItem as User;

        if (selectedKL != null)
        {

            UserVariableData.SelectedUserData = selectedKL;


            var cardTovar = new ReDaCt();
            await cardTovar.ShowDialog(GetWindow());
            RedAte();

        }
    }
}