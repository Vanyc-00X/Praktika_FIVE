using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using FIVE.Models;
using System.Linq;

namespace FIVE;

public partial class EditBabbababa : Window
{
    public EditBabbababa()
    {
        InitializeComponent();
        CountT.Text = UserVariableData.SelectBasket.CountTovar.ToString();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
       
        if (int.TryParse(CountT.Text, out int result))
        {
            var ee = App.DbContext.Baskets.FirstOrDefault(b => b.IdBasket == UserVariableData.SelectBasket.IdBasket);
            ee.CountTovar = int.Parse(CountT.Text);

        }
        App.DbContext.SaveChanges();
        Close();
    }
}