using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.Infra.Data;

namespace LittleTasksWebAPI.EndPoints.Profiles
{
    public class ProfilePost
    {
        public static string Template => "/profiles";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ProfileRequest profileRequest, ApplicationDbContext context)
        {
            var profile = new Profile
            {
                Name = profileRequest.Name,
                Description = profileRequest.Description
            };

            context.Profiles.Add(profile);
            context.SaveChanges();

            return Results.Created($"/profiles/{profile.Id}", profile.Id);
        }
    }
}
