using FRC_Scouting_6487.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FRC_Scouting_6487.Data
{
    public class TeamDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TeamDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Team>().Wait();
        }

        public Task<List<Team>> GetTeamsAsync()
        {
            return _database.Table<Team>().ToListAsync();
        }

        public Task<Team> GetTeamAsync(int TeamNumber)
        {
            return _database.Table<Team>()
                .Where(i => i.TeamNumber == TeamNumber)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveTeamAsync(Team team, bool firstCreate)
        {
            if (firstCreate) return _database.InsertAsync(team);
            else return _database.UpdateAsync(team);
        }

        public Task<int> DeleteTeamAsync(Team team)
        {
            return _database.DeleteAsync(team);
        }

    }
}
