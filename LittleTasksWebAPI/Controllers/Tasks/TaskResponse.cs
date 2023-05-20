using LittleTasksWebAPI.Domain.Tasks;
using LittleTasksWebAPI.Domain.Users;

namespace LittleTasksWebAPI.EndPoints.Tasks
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Points { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public Guid ResponsableDependentId { get; set; }
        public ResponsableDependent ResponsableDependent { get; set; }
        public List<SubTask> SubTasks { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
