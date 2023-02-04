namespace Core.Domain.Basics
{
    public abstract class AuditableEntity : BaseEntity
    {
        public int? Version { get; set; } = 0;

        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }

        public DateTime? DateUpdated { get; set; }
        public Guid? UpdatedBy { get; set; }

        public DateTime? DateDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
