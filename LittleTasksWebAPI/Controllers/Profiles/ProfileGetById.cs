using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace LittleTasksWebAPI.EndPoints.Profiles
{
    public class ProfileGetById
    {
        public static string Template => "/profiles/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var profile = context.Profiles
                .Where(profile => profile.Id == id)
                .FirstOrDefault();

            if (profile == null)
            {
                return Results.NotFound();
            }

            var profileResponse = new ProfileResponse
            {
                Id = profile.Id,
                Name = profile.Name,
                Description = profile.Description
            };

            return Results.Ok(profileResponse);
        }
    }
}
