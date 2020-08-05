using System;
using Xamarin.Forms;
using FRC_Scouting_6487.Views;
using FRC_Scouting_6487.Data;
using System.IO;

namespace FRC_Scouting_6487
{
    public partial class App : Application
    {

        static TeamDatabase database;

        public static TeamDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TeamDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
