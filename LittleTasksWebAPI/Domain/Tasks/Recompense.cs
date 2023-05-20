namespace LittleTasksWebAPI.Domain.Tasks
{
    public class Recompense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}
