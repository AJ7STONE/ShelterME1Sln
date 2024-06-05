using Microsoft.Maui.Controls;
using ShelterME1.Views;
using ShelterME1.Services;
using System.IO;

namespace ShelterME1
{
    public partial class App : Application
    {
        static DatabaseService databaseService;

        public static DatabaseService Database
        {
            get
            {
                if (databaseService == null)
                {
                    databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShelterME1.db3"));
                }
                return databaseService;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignupPage());
        }
    }
}
