using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.EndPoints.Profiles;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class TaskPut
    {
        public static string Template => "/tasks/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, TaskRequest taskRequest, ApplicationDbContext context)
        {
            var task = context.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (task == null)
            {
                return Results.NotFound("Tarefa não encontrada.");
            }

            if (taskRequest.StatusId == null)
            {
                return Results.BadRequest("Status não informado.");
            }

            var status = context.Status.Where(s => s.Id == taskRequest.StatusId).FirstOrDefault();
            if (status == null)
            {
                return Results.NotFound("Status inválido");
            }

            task.StatusId = taskRequest.StatusId;
            task.Points = taskRequest.Points;
            task.Description = taskRequest.Description;
            task.Name = taskRequest.Name;
            task.ExpirationDate = taskRequest.ExpirationDate;

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
