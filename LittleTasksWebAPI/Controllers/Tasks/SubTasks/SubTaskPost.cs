using LittleTasksWebAPI.Domain.Tasks;
using LittleTasksWebAPI.Infra.Data;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class SubTaskPost
    {
        public static string Template => "/subtasks";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(SubTaskRequest taskRequest, ApplicationDbContext context)
        {
            if (taskRequest.StatusId == null)
            {
                return Results.BadRequest("Status não informado.");
            }
            var status = context.Status.Where(s => s.Id == taskRequest.StatusId).FirstOrDefault();
            if (status == null)
            {
                return Results.BadRequest("Status não encontrado.");
            }

            var subTask = new SubTask
            {
                Name = taskRequest.Name,
                ExpirationDate = taskRequest.ExpirationDate,
                Description = taskRequest.Description,
                Points = taskRequest.Points,
                StatusId = taskRequest.StatusId,
                TaskId = taskRequest.TaskId
            };

            context.SubTasks.Add(subTask);
            context.SaveChanges();

            return Results.Created($"/subtasks/{subTask.Id}", subTask.Id);
        }
    }
}
