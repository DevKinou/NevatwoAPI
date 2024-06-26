using Microsoft.AspNetCore.Mvc;
using NevatwoAPI.BDD;
using NLog;

namespace NevatwoAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ListEndpointController : ControllerBase
    {
        private readonly NevaTwoDbContext _context;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ListEndpointController(NevaTwoDbContext context)
        {
            _context = context;
        }

        [HttpGet("axes/{id}/categories")]
        public IActionResult GetCategoriesSinceAxes(int id)
        {
            logger.Info($"Une demande de récupération des catégories pour l'axe {id} a été effectuée");
            List<string?> listCategories = _context.Questions.Where(c => c.axe == id).Select(c => c.item).Distinct().ToList();

            if(listCategories.Count == 0)
            {
                logger.Warn($"Aucune catégorie n'a été trouvée pour l'axe {id}");
                return NotFound();
            }

            return Ok(listCategories);
        }
    }
}
