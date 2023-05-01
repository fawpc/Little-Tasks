using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace LittleTasksWebAPI.EndPoints.Profiles
{
    public class ProfileGetAll
    {
        public static string Template => "/profiles/";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var profiles = context.Profiles.ToList();
            if (!profiles.Any())
            {
                return Results.NotFound();
            }
            var profilesResponse = profiles.Select(p => new ProfileResponse {Id = p.Id, Name = p.Name, Description = p.Description });

            return Results.Ok(profilesResponse);
        }
    }
}
