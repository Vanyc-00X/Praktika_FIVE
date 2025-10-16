using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using FIVE.Data;
using FIVE.Models;
using FIVE.Views;
using System.Linq;


namespace FIVE;

public partial class GoWork : Window
{
    //private readonly MainWindow _mainWindow;

    public GoWork()
    {
        //_mainWindow = mainWindow;
        InitializeComponent();
        RefreshDate();
    }

    private void RefreshDate()
    {
        DataContext = App.DbContext;
    }

    private MainWindow? GetWindow()
    {
        return this.VisualRoot as MainWindow;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(LoginText.Text) || !string.IsNullOrEmpty(PassText.Text))
        {
            var selectedUser = App.DbContext.Users.FirstOrDefault(l => l.Login == LoginText.Text && l.Password == PassText.Text);
            UserVariableData.SelectedUserData = selectedUser;
            bool a = true;
            try
            {
                if (a == true && selectedUser != null)
                {
                    if (UserVariableData.SelectedUserData?.IdUser == selectedUser?.IdUser)
                    {

                        GlobalVariables.FrameModde = 1;

                    }
                }
            }
            catch { return; }
        }
        RefreshDate();
        Close();
    }
}