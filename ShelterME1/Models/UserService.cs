using ShelterME1.Models;
using SQLite;
using System.Threading.Tasks;

namespace ShelterME1.Services
{
    public class UserService
    {
        private readonly SQLiteAsyncConnection _database;

        public UserService()
        {
            _database = new SQLiteAsyncConnection("your_database_path.db3");
            _database.CreateTableAsync<User>().Wait();
        }

        public async Task<bool> RegisterUser(User user)
        {
            // Check if the username already exists
            var existingUser = await _database.Table<User>().Where(u => u.Username == user.Username).FirstOrDefaultAsync();
            if (existingUser != null)
                return false; // Username already exists

            // Save the new user to the database
            await _database.InsertAsync(user);
            return true; // Registration successful
        }
    }
}
