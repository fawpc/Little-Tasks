namespace LittleTasksWebAPI.Domain.Tasks
{
    public class SubTask
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Points { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
