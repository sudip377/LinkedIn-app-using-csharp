using System.Text.Json;
using UserProfileManagment.Models;
namespace UserProfileManagment.Controllers
{
    public class AddUserProfile
    {
        public  static void AddRegistration( UserProfile user,string fileName)
        {
            List<UserProfile> users = new List<UserProfile>();

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                //Console.WriteLine(json);
                users = JsonSerializer.Deserialize<List<UserProfile>>(json);
            }

            users.Add(user);
            //making data in json formate
            string output = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, output);

            Console.WriteLine("User profile added successfully.");
        }
    }
}