using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Core.Application.DTO
{
    public class VacancyResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        [AllowHtml]
        public string JobDescripRequirement { get; set; }
        [AllowHtml]
        public string Hyperlink { get; set; }
        public DateTime Deadline { get; set; }
    }
}
