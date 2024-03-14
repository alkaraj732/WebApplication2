using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class QuestionsAnswersVM
    {
        [Key]
        public int? TRIDQ { get; set; }

        public int? TRIDA { get; set; }

        public string? Answer { get; set; }
        public int? QuestionId { get; set; }
        public string? Questions { get; set; }
        public string? IsActive { get; set; }

        public DateTime? KeyedIn { get; set; }

        public int? KeyedBy { get; set; }
    }
}
