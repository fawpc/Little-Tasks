using LittleTasksWebAPI.Domain.Profiles;

namespace LittleTasksWebAPI.Domain.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Identification { get; set; }//CPF
        public DateOnly DateOfBirth { get; set; }
    }
}
