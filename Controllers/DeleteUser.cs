using UserProfileManagment.Models;
using System.Text.Json;
namespace UserProfileManagment.Controllers
{
    public class DeleteUser
    {
        public static void DeleteUserDetails(string userName,string filePath){

        if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<UserProfile> users = JsonSerializer.Deserialize<List<UserProfile>>(json);
                foreach (var user in users)
                {
                    if (user.Username.Equals(userName))
                    {
                        users.Remove(user);

                        string output = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filePath, output);

                        Console.WriteLine("User details deleted successfully.");
                        return;
                    }
                }
                Console.WriteLine("user Not found....");
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}