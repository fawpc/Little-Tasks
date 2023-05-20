using LittleTasksWebAPI.Domain.Tasks;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;

namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class RecompenseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
    }
}
