using LittleTasksWebAPI.EndPoints.Profiles;
using LittleTasksWebAPI.Infra.Data;


namespace LittleTasksWebAPI.EndPoints.Users
{
    public class UserGetAll
    {
        public static string Template => "/users/";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var users = context.Users.ToList();
            if (!users.Any())
            {
                return Results.NotFound();
            }
            var usersResponse = users.Select(p => new UserResponse { Id = p.Id, Email = p.Email, Identification = p.Identification, Name = p.Name, ProfileId = p.ProfileId, DateOfBirth = p.DateOfBirth });

            return Results.Ok(usersResponse);
        }
    }
}
