using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.EndPoints.Profiles;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class SubTaskPut
    {
        public static string Template => "/subtasks/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, SubTaskRequest subTaskRequest, ApplicationDbContext context)
        {
            var subTask = context.SubTasks
                .Where(st => st.Id == id)
                .FirstOrDefault();

            if (subTask == null)
            {
                return Results.NotFound("SubTarefa não encontrada.");
            }

            if (subTaskRequest.StatusId == null)
            {
                return Results.BadRequest("Status não informado.");
            }

            var status = context.Status.Where(s => s.Id == subTaskRequest.StatusId).FirstOrDefault();
            if (status == null)
            {
                return Results.NotFound("Status inválido");
            }

            subTask.StatusId = subTaskRequest.StatusId;
            subTask.Points = subTaskRequest.Points;
            subTask.Description = subTaskRequest.Description;
            subTask.Name = subTaskRequest.Name;
            subTask.ExpirationDate = subTaskRequest.ExpirationDate;

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
