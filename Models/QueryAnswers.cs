using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class QueryAnswers
    {
        [Key]
        public int? TRID { get; set; }

        public string? Answer { get; set; }
        public int? QuestionId { get; set; }
    }
}
