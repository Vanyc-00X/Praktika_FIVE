using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using FIVE.Models;

namespace FIVE;

public partial class ReDaCt : Window
{
    public ReDaCt()
    {
        InitializeComponent();
        var user = UserVariableData.SelectedUserData;
        try
        {
            App.DbContext.Entry(user).Reference(u => u.IdHumanNavigation).Load();
            DataContext = UserVariableData.SelectedUserData;
        }
        catch { return; }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var DC = DataContext;
        if (string.IsNullOrEmpty(FIOText.Text) && string.IsNullOrEmpty(LoginText.Text) && string.IsNullOrEmpty(PassText.Text) && string.IsNullOrEmpty(EmailText.Text))
        {
            var userDataContext = DC as User;
            App.DbContext.Update(userDataContext);

        }
        App.DbContext.SaveChanges();
        Close();
    }
}