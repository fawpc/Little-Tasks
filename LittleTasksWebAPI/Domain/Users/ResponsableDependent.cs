namespace LittleTasksWebAPI.Domain.Users
{
    public class ResponsableDependent
    {
        public Guid Id { get; set; }
        public Guid ResponsableId { get; set; }
        public Guid DependentId { get; set; }
    }
}
