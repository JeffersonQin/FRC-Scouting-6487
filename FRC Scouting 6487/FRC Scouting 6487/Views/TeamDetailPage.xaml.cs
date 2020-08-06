using FRC_Scouting_6487.Models;
using FRC_Scouting_6487.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FRC_Scouting_6487.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDetailPage : ContentPage
    {

        public TeamDetailPage()
        {
            InitializeComponent();
            this.ChassisPicker.ItemsSource = RobotProperties.ChassisTypes;
            this.ClimbPicker.ItemsSource = RobotProperties.ClimbTypes;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Title = "#Team " + ((TeamRobot)BindingContext).TeamNumber;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.Title = "#Team " + ((TeamRobot)BindingContext).TeamNumber;
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Are you sure to delete this team's information?", "Cancel", "Delete");
            if (action.Equals("Cancel")) return;
            var team = (TeamRobot)this.BindingContext;
            var teams = await App.Database.GetTeamsAsync();
            foreach (Team tb in teams)
            {
                if (tb.TeamNumber == team.TeamNumber)
                {
                    await App.Database.DeleteTeamAsync(tb);
                }
            }
            await Navigation.PopAsync();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            TeamRobot tr = (TeamRobot)this.BindingContext;
            Team saveTeam = new Team()
            {
                TeamNumber = tr.TeamNumber,
                TeamName = tr.TeamName,
                Country = tr.Country,
                TeamRobot = new Robot()
                {
                    RobotChassis = (RobotAttributes.Chassis)tr.RobotChassis,
                    RobotIntake = tr.RobotIntake,
                    RobotScoringFunctions = tr.RobotScoringFunctions,
                    RobotMass = tr.RobotMass,
                    IsPassiveLiftable = tr.IsPassiveLiftable,
                    IsActiveLiftable = tr.IsActiveLiftable,
                    IsDefensive = tr.IsDefensive,
                    RobotClimbType = (RobotAttributes.ClimbType)tr.RobotClimbType
                },
                Matches = tr.Matches
            };
            await App.Database.SaveTeamAsync(saveTeam, false);
        }
    }
}