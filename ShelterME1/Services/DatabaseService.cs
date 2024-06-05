using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ShelterME1.Models;

namespace ShelterME1.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Volunteer>().Wait();
            _database.CreateTableAsync<Donor>().Wait();
            _database.CreateTableAsync<ShelterME1.Models.Resource>().Wait();
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<Volunteer>> GetVolunteersAsync()
        {
            return _database.Table<Volunteer>().ToListAsync();
        }

        public Task<int> SaveVolunteerAsync(Volunteer volunteer)
        {
            return _database.InsertAsync(volunteer);
        }

        public Task<int> DeleteVolunteerAsync(Volunteer volunteer)
        {
            return _database.DeleteAsync(volunteer);
        }

        public Task<List<Donor>> GetDonorsAsync()
        {
            return _database.Table<Donor>().ToListAsync();
        }

        public Task<int> SaveDonorAsync(Donor donor)
        {
            return _database.InsertAsync(donor);
        }

        public Task<int> DeleteDonorAsync(Donor donor)
        {
            return _database.DeleteAsync(donor);
        }

        public Task<int> SaveResourceAsync(ShelterME1.Models.Resource resource)
        {
            return _database.InsertAsync(resource);
        }

        public Task<List<ShelterME1.Models.Resource>> GetResourcesAsync()
        {
            return _database.Table<ShelterME1.Models.Resource>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

    }
}

