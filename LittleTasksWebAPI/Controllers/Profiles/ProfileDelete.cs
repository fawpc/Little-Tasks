using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Profiles
{
    public class ProfileDelete
    {
        public static string Template => "/profiles/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var profile = context.Profiles
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (profile == null)
            {
                return Results.NotFound();
            }

            context.Remove(profile);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
