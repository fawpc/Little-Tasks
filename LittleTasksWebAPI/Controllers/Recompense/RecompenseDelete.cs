using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class RecompenseDelete
    {
        public static string Template => "/recompenses/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var recompense = context.Recompenses
                .Where(r => r.Id == id)
                .FirstOrDefault();

            if (recompense == null)
            {
                return Results.NotFound("Prêmio não encontrado.");
            }

            context.Remove(recompense);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
