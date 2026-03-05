namespace ProjectManagement.Domain.Entities
{
    public class ProjectTask 
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? AssignedToId { get; set; }

        // Relacionamentos
        public virtual Project Project { get; set; }
        public virtual User AssignedTo { get; set; }
    }

    public enum TaskStatus
    {
        Todo,
        InProgress,
        Done,
        Blocked
    }
}