using DBYTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBYTest.Controllers
{
    public class CategoryController : Controller
    {

        private readonly DemirbasYonetimiContext _db;

        public CategoryController(DemirbasYonetimiContext db)
        {
            _db = db;
        }

    }
}
