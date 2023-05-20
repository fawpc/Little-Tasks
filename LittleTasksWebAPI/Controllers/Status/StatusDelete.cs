using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class StatusDelete
    {
        public static string Template => "/status/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var status = context.Status
                .Where(s => s.Id == id)
                .FirstOrDefault();

            if (status == null)
            {
                return Results.NotFound("Status não encontrado.");
            }

            context.Remove(status);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
