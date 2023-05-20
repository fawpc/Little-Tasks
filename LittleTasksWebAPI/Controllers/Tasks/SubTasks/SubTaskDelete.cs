using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class SubTaskDelete
    {
        public static string Template => "/subtasks/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var subTask = context.SubTasks
                .Where(st => st.Id == id)
                .FirstOrDefault();

            if (subTask == null)
            {
                return Results.NotFound("SubTarefa não encontrada.");
            }

            context.Remove(subTask);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
