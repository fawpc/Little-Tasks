using LittleTasksWebAPI.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace LittleTasksWebAPI.EndPoints.Users
{
    public class UserGetById
    {
        public static string Template => "/users/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var user = context.Users
                .Where(user => user.Id == id)
                .FirstOrDefault();

            if (user == null)
            {
                return Results.NotFound();
            }

            var userResponse = new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                Identification = user.Identification,
                Name = user.Name,
                ProfileId = user.ProfileId,
                DateOfBirth = user.DateOfBirth
            };

            return Results.Ok(userResponse);
        }
    }
}
