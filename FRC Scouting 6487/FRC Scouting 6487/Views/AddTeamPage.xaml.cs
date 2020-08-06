using FRC_Scouting_6487.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace FRC_Scouting_6487.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeamPage : ContentPage
    {
        public AddTeamPage()
        {
            InitializeComponent();
            On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var team = (Team)this.BindingContext;
            #region Check if team exists in the database
            var teams = await App.Database.GetTeamsAsync();
            foreach (Team tb in teams)
            {
                if (tb.TeamNumber == team.TeamNumber)
                {
                    await this.DisplayAlert("Error", "The team number already exists in the database.", "Cancel");
                    return;
                }
            }
            #endregion
            // TODO: Server, Check whether the Team No. Exists
            #region Save team into the database
            team.TeamRobot = new Robot() {
                RobotChassis = RobotAttributes.Chassis.Other,
                RobotIntake = 0,
                RobotScoringFunctions = 0,
                RobotMass = 0,
                IsPassiveLiftable = false,
                IsActiveLiftable = false,
                IsDefensive = false,
                RobotClimbType = RobotAttributes.ClimbType.None
            };
            team.Matches = new List<Match>();
            // Debug
            //await this.DisplayAlert("a", team.MatchesData, "cancel");
            //await this.DisplayAlert("a", team.TeamRobotData, "cancel");
            await App.Database.SaveTeamAsync(team, true);
            #endregion
            #region Pop back to the tableview
            await Navigation.PopModalAsync();
            #endregion
            // TODO: Server, Upload
        }
    }
}