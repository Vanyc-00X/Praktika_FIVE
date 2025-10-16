using Avalonia.Controls;
using FIVE.Models;
using System.ComponentModel.Design;

namespace FIVE.Views
{

    

    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            FoundOkno();


        }


        public void FoundOkno()
        {
            while (true)
            {
                if (GlobalVariables.FrameModde == 0) { ReplaceControl(new Aut()); break; }
                else if (GlobalVariables.FrameModde == 1) { ReplaceControl(new AllControl()); break; }
                else if (GlobalVariables.FrameModde == 2) { ReplaceControl(new AllControl()); break; }
                else continue;
            }
            
        }


        public  void ReplaceControl(Control control)
        {
            MainUI.Content = control;
        }
    }
}