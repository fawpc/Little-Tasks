using LittleTasksWebAPI.Domain.Tasks;
using LittleTasksWebAPI.Domain.Users;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class ResponsableDependentGetAll
    {
        public static string Template => "/responsabledependent";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var responsableDependents = context.ResponsableDependents.ToList();

            var responsableDependentsResponse = responsableDependents.Select(rd => new ResponsableDependent { Id = rd.Id, ResponsableId = rd.ResponsableId, DependentId = rd.DependentId });

            return Results.Ok(responsableDependentsResponse);
        }
    }
}
