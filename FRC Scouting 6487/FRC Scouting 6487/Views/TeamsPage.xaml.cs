using FRC_Scouting_6487.Lib;
using FRC_Scouting_6487.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FRC_Scouting_6487.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsPage : ContentPage
    {

        public TeamsPage()
        {
            InitializeComponent();
        }

        private async void TeamListViewRefreshHandler(object sender, EventArgs e)
        {
            // TODO: Server, Refresh Data
            await this.DisplayAlert("Refresh Success / Fail", "....", "OK");
            this.TeamListView.EndRefresh();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TeamListView.ItemsSource = await App.Database.GetTeamsAsync();
        }

        private void TeamSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            this.DisplayAlert("Searched", "abc", "Cancel");
        }

        private async void AddTeamButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTeamPage()
            {
                BindingContext = new Team()
            }, animated: true);
        }

        private async void TeamListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // Debug
                //await this.DisplayAlert("Here", "Here", "Here");
                Team t = e.SelectedItem as Team;
                //await this.DisplayAlert(t.TeamNumber + "", t.TeamName, t.Country);
                TeamRobot tr = new TeamRobot()
                {
                    TeamNumber = t.TeamNumber,
                    TeamName = t.TeamName,
                    Country = t.Country,
                    RobotChassis = (int)t.TeamRobot.RobotChassis,
                    RobotIntake = t.TeamRobot.RobotIntake,
                    RobotScoringFunctions = t.TeamRobot.RobotScoringFunctions,
                    RobotMass = t.TeamRobot.RobotMass,
                    IsPassiveLiftable = t.TeamRobot.IsPassiveLiftable,
                    IsActiveLiftable = t.TeamRobot.IsActiveLiftable,
                    IsDefensive = t.TeamRobot.IsDefensive,
                    RobotClimbType = (int)t.TeamRobot.RobotClimbType,
                    Matches = t.Matches
                };
                //await this.DisplayAlert(t.TeamNumber + "", t.TeamName, t.Country);
                await Navigation.PushAsync(new TeamDetailPage()
                {
                    BindingContext = tr
                }, animated: true);
            }
        }
    }
}