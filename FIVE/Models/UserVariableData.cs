using Avalonia.Controls;
using FIVE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIVE.Models
{
    public static class GlobalVariables
    {
        public static int FrameModde { get; set; } = 0;
        public static int CountTovar { get; set;} = 1;
        
        public static List<object> Basket_Pol = new List<object>();

        
    }


    internal class UserVariableData
    {
        public static User SelectedUserData { get; set; }
        public string UserName { get; set; }

        public static Tovar SelectedTovarData { get; set; }

        public static Human SelectHuman { get; set; }

        public static Basket SelectBasket { get; set; }

    }
}
