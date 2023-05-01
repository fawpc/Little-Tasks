using LittleTasksWebAPI.Domain.Users;
using LittleTasksWebAPI.Infra.Data;

namespace LittleTasksWebAPI.EndPoints.Users
{
    public class UserPost
    {
        public static string Template => "/users";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(UserRequest userRequest, ApplicationDbContext context)
        {
            var profile = context.Profiles
                .Where(profile => profile.Id == userRequest.ProfileId)
                .FirstOrDefault();

            if (profile == null)
            {
                return Results.NotFound("Profile not fount");
            }

            var user = new User
            {
                ProfileId = userRequest.ProfileId,
                Name = userRequest.Name,
                Identification = userRequest.Identification,
                Email = userRequest.Email,
                Password = userRequest.Password,
                DateOfBirth = DateOnly.Parse(userRequest.DateOfBirth)
            };
           
            context.Users.Add(user);
            context.SaveChanges();

            return Results.Created($"/profiles/{user.Id}", user.Id);
        }
    }
}
