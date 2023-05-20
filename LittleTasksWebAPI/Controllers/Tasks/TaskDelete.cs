using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class TaskDelete
    {
        public static string Template => "/tasks/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var task = context.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (task == null)
            {
                return Results.NotFound("Tarefa não encontrada.");
            }

            context.Remove(task);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
