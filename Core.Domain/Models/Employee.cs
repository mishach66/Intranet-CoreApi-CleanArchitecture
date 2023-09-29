using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Basics;
using Microsoft.AspNetCore.Http;

namespace Core.Domain.Models
{
    public enum Languages
    {
        Georgian,
        English,
        French,
        Spanish,
        Other
    }
    
    public class Employee : AuditableEntity
    {
        public string? Givenname { get; set; }
        public string? Surname { get; set; }
        public string? IdNumber { get; set; }
        public string? SurnameGivenname { get; set; }
        public string? GivennameSurname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? Address { get; set; }
        public string? AdditionalInfo { get; set; }
        public Languages? Language { get; set; }

        #region
        /// <summary>
        /// სურათის ატვირთვა
        /// </summary>

        //[Column(TypeName = "nvarchar(500)")]
        //[DisplayName("სურათის სახელი")]
        public string? ImageName { get; set; }

        //[DisplayName("სურათის ატვირთვა")]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        #endregion

        public Guid? CityId { get; set; }
        public City City { get; set; }
        public Guid? SexId { get; set; }
        public Sex Sex { get; set; }
        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }
    }
}
