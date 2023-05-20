using LittleTasksWebAPI.Domain.Tasks;
using LittleTasksWebAPI.Infra.Data;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class StatusPost
    {
        public static string Template => "/status";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(Status status, ApplicationDbContext context)
        {
            context.Status.Add(status);
            context.SaveChanges();

            return Results.Created($"/status/{status.Id}", status.Id);
        }
    }
}
