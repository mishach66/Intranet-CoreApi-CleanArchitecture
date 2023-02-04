namespace Core.Domain.Basics;

public abstract class SharedEntity : BaseEntity
{
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }
}
