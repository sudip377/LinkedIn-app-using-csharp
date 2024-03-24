using System.Text.Json.Serialization;
using UserProfileManagment.Models;

namespace UserProfileManagment.Models
{
  public class UserProfile :AddExtraDetails {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Username { get; set; }
    public string? Nationality { get; set; }
  }
  public class AddExtraDetails 
{
  //[JsonIgnore]
    public List<Education>? Education { get; set; }
   // [JsonIgnore]
    public List<string>? Skills { get; set; }
   // [JsonIgnore]
    public List<WorkExperience>? WorkExp { get; set; }
  //  [JsonIgnore]
    public List<string> ?Social { get; set; }
}
public class Education
{
    public string? Degree { get; set; }
    public string? University { get; set; }
    public string? Grade { get; set; }
}
public class WorkExperience
{
    public string? Company { get; set; }
    public string? Profile{ get; set; }
    public int DurationInMonths  { get; set; }
    public string? Location { get; set; }
    public bool CurrentlyWorking{get;set;}
}
}