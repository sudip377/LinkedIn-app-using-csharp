using System.Text.Json;
namespace UserProfileManagment.Controllers
{
    public class GetUser
    {
        public static void GetUsers( string filePath){
             string jsonString = File.ReadAllText(filePath);
            //Console.WriteLine(jsonString);
            // Parse the JSON data
            JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
            if (jsonString == "[]")
            {
                Console.WriteLine("No users are present  " + jsonString);
            }
            // Iterate over the JSON elements
            else
            {
                Console.WriteLine("\n **......Below details available in JSON file.....**\n");
                foreach (JsonElement element in jsonDocument.RootElement.EnumerateArray())
                {
                    // Do something with each element
                    Console.WriteLine(element.ToString());
                }
            }
        }
    }
}