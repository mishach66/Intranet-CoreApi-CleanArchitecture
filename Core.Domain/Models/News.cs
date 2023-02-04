using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Basics;

namespace Core.Domain.Models
{
    public class News : AuditableEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        [AllowHtml]
        public string Hyperlink { get; set; }
    }
}
