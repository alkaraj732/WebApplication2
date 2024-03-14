using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class QueryQuestions
    {
        [Key]
        public int? TRID { get; set; }
        public string Questions { get; set; }
        public string IsActive { get; set; }
        
        public DateTime KeyedIn { get; set; }

        public int KeyedBy { get; set; }
    }
}
