using Core.Domain.Basics;

namespace Core.Domain.Models
{
    public class LanguageСlassifier : AuditableEntity
    {
        public string? LanguageName { get; set; }
        public ICollection<Language>? Languages { get; set; }

        public LanguageСlassifier()
        {
            Languages = new HashSet<Language>();
        }
    }
}
