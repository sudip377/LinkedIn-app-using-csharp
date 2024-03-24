using UserProfileManagment.Models;
using System.Text.Json;
using System.Collections.Generic;
namespace UserProfileManagment.Helpers
{
    public class Userhelper
    {
         public static bool emailIdCheck(string userEmail,string fileName){
            bool Flag=false;
             if (File.Exists(fileName))
            {  
                 string json = File.ReadAllText(fileName);
                List<UserProfile> ?users = JsonSerializer.Deserialize<List<UserProfile>>(json);
                    foreach (var user in users)
                    { 
                        if (user.Email.Equals(userEmail))
                        {  
                            Flag=true;
                            break;

                        }
                    }
                   
               return Flag;
            }
            else
            {
                Console.WriteLine("File not found.");
                return false;
            }
         }
         public static bool userNameCheck(string userName,string fileName){
            bool Flag=false;
             if (File.Exists(fileName))
            {  
                 string json = File.ReadAllText(fileName);
                List<UserProfile> ?users = JsonSerializer.Deserialize<List<UserProfile>>(json);
                    foreach (var user in users)
                    { 
                        if(user.Username==userName){
                            Flag=true;
                        }
                    }
                   
               return Flag;
            }
            else
            {
                Console.WriteLine("File not found.");
                return false;
            }
         }
    }
}