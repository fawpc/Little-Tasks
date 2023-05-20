using LittleTasksWebAPI.Domain.Tasks;
using LittleTasksWebAPI.Domain.Users;
using LittleTasksWebAPI.Infra.Data;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class ResponsableDependentPost
    {
        public static string Template => "/responsabledependent";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ResponsableDependent responsableDependent, ApplicationDbContext context)
        {
            context.ResponsableDependents.Add(responsableDependent);
            context.SaveChanges();

            return Results.Created($"/responsabledependent/{responsableDependent.Id}", responsableDependent.Id);
        }
    }
}
