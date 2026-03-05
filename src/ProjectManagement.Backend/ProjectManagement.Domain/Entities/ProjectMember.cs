namespace ProjectManagement.Domain.Entities
{
    public class ProjectMember
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public ProjectRole Role { get; set; }
        public DateTime JoinedAt { get; set; }

        public virtual Project? Project { get; set; }
        public virtual User? User { get; set; }
    }

    public enum ProjectRole
    {
        Owner,
        Manager,
        Member,
        Viewer
    }
}