using Microsoft.AspNetCore.Mvc;
using NevatwoAPI.BDD;
using NLog;

namespace NevatwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AxesController : ControllerBase
    {
        private readonly NevaTwoDbContext _context;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AxesController(NevaTwoDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/categories")]
        public IActionResult GetCategoriesSinceAxes(int id)
        {
            logger.Info($"Une demande de récupération des catégories pour l'axe {id} a été effectuée");
            List<string?> listCategories = _context.Questions.Where(c => c.axe == id).Select(c => c.item).Distinct().ToList();
            return Ok(listCategories);
        }
    }
}
