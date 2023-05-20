using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.EndPoints.Profiles;
using LittleTasksWebAPI.EndPoints.Tasks;
using LittleTasksWebAPI.EndPoints.Users;
using LittleTasksWebAPI.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;



// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LittleTasksWebAPI
{
    public class Function
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEntityFrameworkNpgsql()
                                .AddDbContext<ApplicationDbContext>(options => options
                                    .UseNpgsql(builder.Configuration.GetConnectionString("LittleTasksWebAPIDb")));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors();            

            app.MapMethods(ProfilePut.Template, ProfilePut.Methods, ProfilePut.Handle);
            app.MapMethods(ProfileGetAll.Template, ProfileGetAll.Methods, ProfileGetAll.Handle);
            app.MapMethods(ProfilePost.Template, ProfilePost.Methods, ProfilePost.Handle);
            app.MapMethods(ProfileDelete.Template, ProfileDelete.Methods, ProfileDelete.Handle);
            app.MapMethods(ProfileGetById.Template, ProfileGetById.Methods, ProfileGetById.Handle);

            app.MapMethods(UserPut.Template, UserPut.Methods, UserPut.Handle);
            app.MapMethods(UserGetAll.Template, UserGetAll.Methods, UserGetAll.Handle);
            app.MapMethods(UserPost.Template, UserPost.Methods, UserPost.Handle);
            app.MapMethods(UserDelete.Template, UserDelete.Methods, UserDelete.Handle);
            app.MapMethods(UserGetById.Template, UserGetById.Methods, UserGetById.Handle);

            app.MapMethods(StatusPost.Template, StatusPost.Methods, StatusPost.Handle);
            app.MapMethods(StatusDelete.Template, StatusDelete.Methods, StatusDelete.Handle);
            app.MapMethods(StatusGetAll.Template, StatusGetAll.Methods, StatusGetAll.Handle);

            app.MapMethods(TaskPost.Template, TaskPost.Methods, TaskPost.Handle);
            app.MapMethods(TaskPut.Template, TaskPut.Methods, TaskPut.Handle);
            app.MapMethods(TaskDelete.Template, TaskDelete.Methods, TaskDelete.Handle);
            app.MapMethods(TaskGetByResponsableDependentId.Template, TaskGetByResponsableDependentId.Methods, TaskGetByResponsableDependentId.Handle);


            app.MapMethods(SubTaskPost.Template, SubTaskPost.Methods, SubTaskPost.Handle);
            app.MapMethods(SubTaskPut.Template, SubTaskPut.Methods, SubTaskPut.Handle);
            app.MapMethods(SubTaskDelete.Template, SubTaskDelete.Methods, SubTaskDelete.Handle);
            app.MapMethods(SubTaskGetGetByTaskId.Template, SubTaskGetGetByTaskId.Methods, SubTaskGetGetByTaskId.Handle);

            app.MapMethods(ResponsableDependentDelete.Template, ResponsableDependentDelete.Methods, ResponsableDependentDelete.Handle);
            app.MapMethods(ResponsableDependentPost.Template, ResponsableDependentPost.Methods, ResponsableDependentPost.Handle);
            app.MapMethods(ResponsableDependentGetAll.Template, ResponsableDependentGetAll.Methods, ResponsableDependentGetAll.Handle);

            app.Run();
        }
    }
}

