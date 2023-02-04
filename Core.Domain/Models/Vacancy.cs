using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Domain.Basics;

namespace Core.Domain.Models
{
    public class Vacancy : AuditableEntity
    {
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
