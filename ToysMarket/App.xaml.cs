using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ToysMarket
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Models.Users User { get; set; } = new Models.Users();
        public static Models.ToysEntities ToysEntities = new Models.ToysEntities();
    }
}
