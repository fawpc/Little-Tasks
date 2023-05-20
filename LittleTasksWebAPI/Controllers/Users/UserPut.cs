using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;


namespace LittleTasksWebAPI.EndPoints.Users
{
    public class UserPut
    {
        public static string Template => "/users/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, UserRequest userRequest, ApplicationDbContext context)
        {
            var user = context.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (user == null)
            {
                return Results.NotFound();
            }
            user.Name = userRequest.Name;
            user.Email = userRequest.Email;
            user.Password = userRequest.Password;
            user.Identification = userRequest.Identification;
            user.ProfileId = userRequest.ProfileId;
            user.DateOfBirth = DateOnly.Parse(userRequest.DateOfBirth);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}

