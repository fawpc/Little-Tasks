using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace LittleTasksWebAPI.EndPoints.Users
{
    public class UserDelete
    {
        public static string Template => "/users/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var user = context.Users
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (user == null)
            {
                return Results.NotFound();
            }

            context.Remove(user);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
