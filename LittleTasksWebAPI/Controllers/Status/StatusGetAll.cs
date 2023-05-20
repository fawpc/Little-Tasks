using LittleTasksWebAPI.Domain.Tasks;
using LittleTasksWebAPI.Domain.Users;
using LittleTasksWebAPI.EndPoints.Users;
using LittleTasksWebAPI.Infra.Data;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class StatusGetAll
    {
        public static string Template => "/status";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var status = context.Status.ToList();

            var statusResponse = status.Select(s => new Status { Id = s.Id, Name = s.Name, Description = s.Description });

            return Results.Ok(statusResponse);
        }
    }
}
