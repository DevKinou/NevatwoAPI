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

        // Liste des grilles
        //[HttpGet("grilles")]
        //public IActionResult GetGrilles()
        //{
        //}

        //Liste des axes d'une grille
        //[HttpGet("grilles/{id}/axes")]
        //public IActionResult GetAxesSinceGrilles (int id)
        //{
        //}

        //Liste des catégories d'un axe
        [HttpGet("axes/{id}/categories")]
        public IActionResult GetCategoriesSinceAxeId(int id)
        {
            logger.Info($"Une demande de récupération des catégories pour l'axe {id} a été effectuée");
            List<string?> listCategories = _context.Questions.Where(c => c.axe == id).Select(c => c.item).Distinct().ToList();

            if (listCategories.Count == 0)
            {
                logger.Warn($"Aucune catégorie n'a été trouvée pour l'axe {id}");
                return NotFound();
            }

            return Ok(listCategories);
        }

        //Ensemble des questions d'une catégorie
        [HttpGet("categories/{categorie}/questions")]
        public IActionResult GetQuestionsSinceCategorie(string categorie)
        {
            logger.Info($"Une demande de récupération des questions pour la catégorie {categorie} a été effectuée");
            List<string?> listQuestions = _context.Questions.Where(c => c.item.Contains(categorie)).Select(c => c.libelle).Distinct().ToList();

            if (listQuestions.Count == 0)
            {
                logger.Warn($"Aucune question n'a été trouvée pour la catégorie {categorie}");
                return NotFound();
            }

            return Ok(listQuestions);
        }

        //[HttpGet("/search/questions?q=query")]
        //public IActionResult GetQuestionsSinceQuery(string query)
        //{
        //   
        //}
    }
}
