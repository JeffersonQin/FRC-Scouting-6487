using FRC_Scouting_6487.Lib;
using FRC_Scouting_6487.Models;
using Newtonsoft.Json;
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
    public partial class TeamsPage : ContentPage
    {
        public TeamsPage()
        {
            InitializeComponent();
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

        private void AddTeamButton_Clicked(object sender, EventArgs e)
        {
            //var team = new Team()
            //{
            //    TeamNumber = 6487,
            //    TeamName = "ClockworckNights",
            //    Country = "China"
            //};
            //await App.Database.SaveTeamAsync(team, true);
            Match match1 = new Match()
            {
                MatchIndex = 1,
                MatchStrategy = MatchAttributes.Strategy.Combine
            };
            Match match2 = new Match()
            {
                MatchIndex = 2,
                MatchStrategy = MatchAttributes.Strategy.Defense
            };
            Match match3 = new Match()
            {
                MatchIndex = 3,
                MatchStrategy = MatchAttributes.Strategy.Scoring
            };
            Match match4 = new Match()
            {
                MatchIndex = 4,
                MatchStrategy = MatchAttributes.Strategy.Wandering
            };
            List<Match> matches = new List<Match>
            {
                match1,
                match2,
                match3,
                match4
            };
            this.DisplayAlert("title", JSONHelper.ObjectToJSON(matches), "cancel");
        }
    }
}