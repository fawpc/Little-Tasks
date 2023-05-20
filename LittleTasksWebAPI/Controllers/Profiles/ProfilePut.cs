using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Profiles
{
    public class ProfilePut
    {
        public static string Template => "/profiles/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ProfileRequest profileRequest, ApplicationDbContext context)
        {
            var profile = context.Profiles
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (profile == null)
            {
                return Results.NotFound();
            }

            profile.Name = profileRequest.Name;
            profile.Description = profileRequest.Description;

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
