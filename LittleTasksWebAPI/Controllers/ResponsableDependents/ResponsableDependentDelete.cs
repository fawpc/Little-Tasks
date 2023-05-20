using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class ResponsableDependentDelete
    {
        public static string Template => "/responsabledependent/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var responsableDependent = context.ResponsableDependents
                .Where(rd => rd.Id == id)
                .FirstOrDefault();

            if (responsableDependent == null)
            {
                return Results.NotFound("Responsável - dependente não encontrado.");
            }

            context.Remove(responsableDependent);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
