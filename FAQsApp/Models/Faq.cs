using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FAQsApp.Models
{
    public class Faq
    {
        // EF treats Id or <classname>Id as primary key so it is auto generated incrementally
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Category Category { get; set; }
        public Topic Topic { get; set; }
    }
}
