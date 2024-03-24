using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;
using UserProfileManagment.Models;
namespace UserProfileManagment.Controllers
{
    public class GetUserByUsername
    {
        public static void GetUserByusername(string username, string fileName)
        {
            if (File.Exists(fileName))
            {
                bool flag = false;
                string json = File.ReadAllText(fileName);
                JsonArray jsonArray = JsonNode.Parse(json).AsArray();

                // Iterate over each object in the array and display it


                List<UserProfile>? users = JsonSerializer.Deserialize<List<UserProfile>>(json);
                foreach (var user in users)
                {
                    if (user.Username.Equals(username) || user.Email.Equals(username))
                    {
                        flag = true;
                        Console.WriteLine("\n");
                        string jsonSring=JsonSerializer.Serialize(user);
                        Console.WriteLine(jsonSring.ToString());
                       Console.WriteLine("\n");
                    }
                }
                if (flag)
                    Console.WriteLine("User found and sucessfully displayed");
                else
                    Console.WriteLine("\nUser not found");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}