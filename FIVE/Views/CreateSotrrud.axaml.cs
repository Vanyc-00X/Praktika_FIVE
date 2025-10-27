using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FIVE;

public partial class CreateSotrrud : Window
{
    public CreateSotrrud()
    {
        InitializeComponent();

        var user = new User
        {
            IdHumanNavigation = new Human(),
            IdRole = 2
        };
        DataContext = user;
    }
    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(LoginText.Text) && !string.IsNullOrEmpty(PassText.Text) &&
            !string.IsNullOrEmpty(FIOText.Text) && !string.IsNullOrEmpty(EmailText.Text) &&
            !string.IsNullOrEmpty(PhoneText.Text))
        {
            var user = DataContext as User;
            if (user != null && user.IdHumanNavigation != null)
            {

                if (App.DbContext.Users.Any(u => u.Login == user.Login))
                {
                    await ShowError("Пользователь с таким логином уже существует");
                    return;
                }

                if (App.DbContext.Humans.Any(h => h.Email == user.IdHumanNavigation.Email))
                {
                    await ShowError("Пользователь с таким email уже существует");
                    return;
                }

                try
                {
                    App.DbContext.Humans.Add(user.IdHumanNavigation);
                    App.DbContext.Users.Add(user);
                    App.DbContext.SaveChanges();
                    this.Close();
                }
                catch
                {
                    Console.WriteLine("😢😢 ГИГАЧАТ ТОП ХЕХЕХЕХЕХЕХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕХЕХЕХХЕХХЕХХЕХЕХЕХЕХЕХХЕХЕХЕХЕХЕХЕХЕХЕХЕХ)");
                }
            }
        }
    }

    private async Task ShowError(string message)
    {
        var messageBox = new Window
        {
            Title = "Ошибка",
            Content = new TextBlock { Text = message },
            Width = 300,
            Height = 150
        };
        await messageBox.ShowDialog(this);
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}