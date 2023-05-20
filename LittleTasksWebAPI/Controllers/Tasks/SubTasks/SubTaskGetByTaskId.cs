using LittleTasksWebAPI.EndPoints.Profiles;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class SubTaskGetGetByTaskId
    {
        public static string Template => "/subtasks/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var subTasks = context.SubTasks
                .Where(st => st.TaskId == id)
                .ToList();

            if (subTasks == null)
            {
                return Results.NotFound("Tarefas não encontradas para esse Responsável-Dependente.");
            }

            List<SubTaskResponse> response = new List<SubTaskResponse>();
            foreach (var subTask in subTasks)
            {
                var subTaskResponse = new SubTaskResponse
                {
                    Id = subTask.Id,
                    Name = subTask.Name,
                    Description = subTask.Description,
                    ExpirationDate = subTask.ExpirationDate,
                    TaskId = subTask.TaskId,
                    Points = subTask.Points,
                    StatusId = subTask.StatusId
                };
                response.Add(subTaskResponse);
            }

            return Results.Ok(response);
        }
    }
}
