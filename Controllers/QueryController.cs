using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class QueryController : Controller
    {
        
    private readonly ApplicationDBContex _context;

        public QueryController(ApplicationDBContex context)
        {
            _context = context;
        }

        public IActionResult QueryQA()
        {
            var query = from ques in _context.Questions
                        join ans in _context.Answers
                        on ques.TRID equals ans.QuestionId into joinedAnswer
                        from ans in joinedAnswer.DefaultIfEmpty()
                        select new
                        {
                            Question = ques,
                            Answer = ans
                        };

            var result = query.ToList();

            return View(result);
        }
        [HttpPost]
        public IActionResult QueryQA(QuestionsAnswersVM qsans)
        {
            

            return View(new QuestionsAnswersVM());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
