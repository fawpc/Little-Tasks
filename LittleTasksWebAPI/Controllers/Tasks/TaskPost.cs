using LittleTasksWebAPI.Infra.Data;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class TaskPost
    {
        public static string Template => "/tasks";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(TaskRequest taskRequest, ApplicationDbContext context)
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

            if (taskRequest.ResponsableDependentId == null)
            {
                return Results.BadRequest("Responsável-Dependente Não informado");
            }

            var responsableDependent = context.ResponsableDependents.Where(rd => rd.Id == taskRequest.ResponsableDependentId).FirstOrDefault();
            if (responsableDependent == null)
            {
                return Results.BadRequest("Responsável-Dependente Não encontrado.");
            }

            var task = new Task
            {
                Name = taskRequest.Name,
                ExpirationDate = taskRequest.ExpirationDate,
                Description = taskRequest.Description,
                Points = taskRequest.Points,
                ResponsableDependentId = taskRequest.ResponsableDependentId,
                StatusId = taskRequest.StatusId
            };

            context.Tasks.Add(task);
            context.SaveChanges();

            return Results.Created($"/tasks/{task.Id}", task.Id);
        }
    }
}
