using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class RecompenseGetByTaskId
    {
        public static string Template => "/tasks/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var tasks = context.Tasks
                .Where(task => task.ResponsableDependentId == id)
                .ToList();

            if (tasks == null)
            {
                return Results.NotFound("Tarefas não encontradas para esse Responsável-Dependente.");
            }

            List<TaskResponse> response = new List<TaskResponse>();
            foreach (var task in tasks)
            {
                var taskResponse = new TaskResponse
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    ExpirationDate = task.ExpirationDate,
                    ResponsableDependentId = id,
                    Points = task.Points,
                    StatusId = task.StatusId
                };
                response.Add(taskResponse);
            }

            return Results.Ok(response);
        }
    }
}
