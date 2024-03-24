using System.Text.RegularExpressions;
namespace UserProfileManagment.Helpers
{
    public class Validation
    {
        private const string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        // A Regex object to perform the validation
        private static Regex emailRegex = new Regex(emailPattern);
        // Check if the email is null or empty
        public static bool isValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email Id can't empty Please re enter the  Valid Email Id");
                return false;
            }
            else
            {
                if (emailRegex.IsMatch(email) == false)
                {
                    Console.WriteLine("!Please re enter the  Valid Email Id");
                    return false;
                }
                else
                    return true;
            }
        }
        public const string mobRex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public static bool isvalidPhoneNo(string phoneNumber)
        {  
            if (phoneNumber.Length==10){
                     return Regex.IsMatch(phoneNumber, mobRex);
            }
        
            else return false;
        }

        public static bool isValidDate(string mydate)

        {
            if (string.IsNullOrEmpty(mydate))
            {
                Console.Write("Dob can't be Empty");
                return false;
            }
            else if (DateTime.TryParseExact(mydate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                DateTime currentDate = DateTime.Today;
                return parsedDate <= currentDate;
            }
            else
            {   
                return false;
            }
        }
        public static bool isString(string value){
            const string regex=@"^[A-Za-z]+$";
            return Regex.IsMatch(value,regex);

        }
    }
}