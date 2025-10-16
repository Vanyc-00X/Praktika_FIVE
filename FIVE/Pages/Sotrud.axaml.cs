using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FIVE;

public partial class Sotrud : UserControl
{
    public Sotrud()
    {
        InitializeComponent();
        var otbor = App.DbContext.Users.Where(t => t.IdRole != 3).ToList();
        DataSotrudnic.ItemsSource = otbor;
    }
}