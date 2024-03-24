using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using UserProfileManagment.Models;
using System.Globalization;

namespace UserProfileManagment.Controllers
{
    public class UpdateUserProfile
    {
        public static void UpdateuserProfile(string email, string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                List<UserProfile>? users = JsonSerializer.Deserialize<List<UserProfile>>(json);
                foreach (var user in users)
                {
                    if (user.Email.Equals(email))
                    {
                        //var userobj=new UserProfile{FirstName=user.FirstName}
                        Console.WriteLine("\n Enter 1 for add Education details\nEnter 2 for add skills\n Enter 3 for add WorkExp \n Enter 4 for add Social links");
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine($"Enter Education Details  (Degree, University, Grade):");
                            step1:
                                string[] educationInput = Console.ReadLine()?.Split(',');
                                if (educationInput.Length != 3)
                                {
                                    Console.WriteLine("Invalid input. Please enter in the format Degree, University, Gread.");
                                    goto step1;
                                }
                                if (user.Education == null)
                                    user.Education = new List<Education>();
                                user.Education.Add(new Education
                                { Degree = educationInput[0], University = educationInput[1], Grade = educationInput[2] }
                                //                         
                                );
                                //String newjson =AddExtraField.addExtraField(users[i], fileName);
                                string output = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(fileName, output);
                                Console.WriteLine("Your Education details successfully.");
                                break;
                            case 2:
                                Console.WriteLine($"Enter  your Skills:");
                                if (user.Skills == null)
                                    user.Skills = new List<string>();
                                string skill = Console.ReadLine();
                                user.Skills.Add(skill);
                                string skilloutput = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(fileName, skilloutput);
                                Console.WriteLine("Your Skill added successfully.");

                                break;
                            case 3:
                                Console.WriteLine("Enter Work Experience Details (Company, Profile, DurationInMonths, Location,CurrentlyWorking):");
                            step2:
                                string[] workExpInput = Console.ReadLine()?.Split(',');
                                if (workExpInput.Length != 5)
                                {
                                    Console.WriteLine("Invalid input. Please enter in the format,(Company, Profile, DurationInMonths, Location,CurrentlyWorking)");
                                    goto step2;
                                }
                                if (user.WorkExp == null)
                                    user.WorkExp = new List<WorkExperience>();
                                user.WorkExp.Add(new WorkExperience { Company = workExpInput[0], Profile = workExpInput[1], DurationInMonths = Convert.ToInt32(workExpInput[2]), Location = workExpInput[3], CurrentlyWorking = Convert.ToBoolean(workExpInput[4]) });
                                string Workoutput = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(fileName, Workoutput);
                                Console.WriteLine("Your Work Exp added successfully.");
                                break;
                            case 4:
                                Console.WriteLine($"Enter  your Social link:");
                                if (user.Social == null)
                                    user.Social = new List<string>();
                                string social = Console.ReadLine();
                                user.Social.Add(social);
                                string socialoutput = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(fileName, socialoutput);
Console.WriteLine("Your social added successfully.");
                                break;
                            default:
                                Console.WriteLine(" you enter wrong key ....");
                                break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("File not found.");
            }

        }
    }
}