using Core.Domain.Basics;
using Core.Domain.CustomModelBinder;
using Microsoft.AspNetCore.Mvc;

namespace Core.Domain.Models
{
    [ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class Language : AuditableEntity
    {
        //public string? LanguageName { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? LanguageСlassifierId { get; set; }
        public Employee? Employee { get; set; }
        public LanguageСlassifier? LanguageСlassifier { get; set; }

        //public ICollection<Employee> Employees { get; set; }
        //public Language()
        //{
        //    Employees = new HashSet<Employee>();
        //}
    }
}
