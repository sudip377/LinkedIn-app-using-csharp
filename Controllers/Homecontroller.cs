using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using UserProfileManagment.Helpers;
using UserProfileManagment.Models;
namespace UserProfileManagment.Controllers
{
    public class Homecontroller
    {
        public static string fileName = "UserDB.json";


        public static void Menu()
        {
            Console.WriteLine("\nEnter key accroding to below menu....");
            Console.WriteLine("Press 1 for Profile creation....");
            Console.WriteLine("Press 2 for  fetching Profile details ....");
            Console.WriteLine("Press 3 for Profile details fetch by userName ....");
            Console.WriteLine("Press 4 for Profile details update....");
            Console.WriteLine("Press 5 for Profile delete ...");
            string? presskey1 = Console.ReadLine();
            int presskey = Convert.ToInt32(presskey1);


            switch (presskey)
            {
                case 1:
                //callled add method
                    UserProfile user = new UserProfile();
                    Console.WriteLine("Enter your FirstName:");
                firstName:
                    string? firstName = Console.ReadLine();
                    if (Validation.isString(firstName))
                        user.FirstName = firstName;
                    else
                    {
                        Console.WriteLine("!!firstName  can't be empty or not include any integer so re enter the firstname");
                        goto firstName;
                    }
                    Console.WriteLine("Enter your LastName:");
                lastName:
                    string? lastName = Console.ReadLine();
                    if (Validation.isString(lastName))
                        user.LastName = lastName;
                    else
                    {
                        Console.WriteLine("!!LastName  can't be empty or not include any integer so re enter lastname");
                        goto lastName;
                    }
                    Console.WriteLine("Enter your DoB in DD/MM/YY formate:");
                dobinput:
                    string? dateOfBirth = Console.ReadLine();
                    if (Validation.isValidDate(dateOfBirth) == true)
                    {
                        user.DateOfBirth = dateOfBirth;

                    }
                    else
                    {
                        Console.WriteLine(" Enter valid date");
                        goto dobinput;
                    }
                    Console.WriteLine("Enter your Email:");
                Emailinput:
                    string? email = Console.ReadLine();
                    if (Validation.isValidEmail(email) == true)
                    {
                        user.Email = email;
                    }
                    else
                    {
                        goto Emailinput;
                    }
                    Console.WriteLine("Enter your userName:");
                userName:
                    string? userName = Console.ReadLine();
                    if (Userhelper.userNameCheck(userName, fileName) == true)
                    {
                        Console.WriteLine("!!this user name not available");
                        goto userName;
                    }
                    else
                    {
                        user.Username = userName;
                    }
                    Console.WriteLine("Enter your phoneNumber:");
                phoneinput:
                    string? phoneNumber = Console.ReadLine();
                    if (Validation.isvalidPhoneNo(phoneNumber) == true)
                    {
                        user.PhoneNumber = phoneNumber;
                    }
                    else
                    {
                        Console.WriteLine("!Please Enter Valid Phone number");
                        goto phoneinput;
                    }
                    Console.WriteLine("Enter your Nationality:");
                nationality:
                    string? nationality = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nationality))
                    {
                        Console.WriteLine("nationality cant be empty");
                        goto nationality;
                    }
                    else
                        user.Nationality = nationality;
                    //below if else condition cheking user present or not
                    if (Userhelper.emailIdCheck(user.Email, fileName) == true && Userhelper.userNameCheck(user.Username, fileName) == true)
                    {
                        Console.WriteLine("Email & username already Present");
                    }
                    else if (Userhelper.emailIdCheck(user.Email, fileName) == true)
                    {
                        Console.WriteLine("!!Email id already Present");
                    }
                    else if (Userhelper.userNameCheck(user.Username, fileName) == true)
                    {
                        Console.WriteLine("!! username id already Present");
                    }
                    else
                    {
                        AddUserProfile.AddRegistration(user, fileName);
                    }
                    break;
                case 2:
                    GetUser.GetUsers(fileName);
                    break;
                case 3:
                    //call GetUserInfoByEmailAndUsername method to fetch user details
                    //Console.WriteLine("Enter user Email:");
                    //string myemail = Console.ReadLine();
                    Console.WriteLine("Enter user userName:");
                    string? myuserName = Console.ReadLine();
                    GetUserByUsername.GetUserByusername(myuserName, fileName);
                    break;
                case 4:
                    //call userdetails update methodby Email
                    Console.WriteLine(" For update your details Enter user Email:");
                step2:
                    string? mymail = Console.ReadLine();
                    if (Validation.isValidEmail(mymail) != true)
                    {
                        goto step2;
                    }
                    else if (Userhelper.emailIdCheck(mymail, fileName) != true)
                    {
                        Console.WriteLine("User not found");
                    }
                    else
                    {
              UpdateUserProfile.UpdateuserProfile(mymail,fileName);
                        //UpdateUserDetails.UpdateuserDetails(mymail, fileName);
                    }

                    break;
                case 5:
                    //call delet method
                    Console.WriteLine("Enter user userName:");
                    string? uSerName = Console.ReadLine();
                    if (Userhelper.userNameCheck(uSerName, fileName) == true)
                    {
                        DeleteUser.DeleteUserDetails(uSerName, fileName);
                    }
                    else
                    {
                        Console.WriteLine("user not found");
                    }

                    break;
                default:
                    //call user not found method
                    Console.WriteLine(" you enter wrong key ....");
                    break;
            }


        }
    }
}