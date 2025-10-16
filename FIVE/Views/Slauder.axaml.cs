using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Models;
using System;

namespace FIVE;

public partial class Slauder : Window
{
    public Slauder()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        GlobalVariables.CountTovar = Convert.ToInt32(slider.Value);
        Close();
    }
}