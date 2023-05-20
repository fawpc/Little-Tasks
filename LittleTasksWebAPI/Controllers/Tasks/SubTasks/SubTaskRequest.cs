using LittleTasksWebAPI.Domain.Tasks;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;

namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class SubTaskRequest
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Points { get; set; }
        public Guid StatusId { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
