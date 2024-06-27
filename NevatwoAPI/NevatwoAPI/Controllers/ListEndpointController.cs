using Microsoft.AspNetCore.Mvc;
using NevatwoAPI.BDD;
using NevatwoAPI.Json;
using NLog;
using System.Text;

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

        #region Get
        // Liste des réponses
        // Doit récupérer l'ensemble de la liste des réponses d'une entreprise
        [HttpGet("grilles")]
        public IActionResult GetGrilles(int idEntreprise)
        {
            logger.Info($"Une demande de récupération des grilles pour l'entreprise {idEntreprise} a été effectuée");

            // Requête avec jointures pour récupérer les informations nécessaires
            List<GrilleCompleteEntrepriseJson> grilles = _context.ReponseEntreprise
                .Where(re => re.entreprise_id == idEntreprise)
                // Jointure entre les réponses d'entreprise et les questions sur l'ID de la question.
                // 're' représente un élément de ReponseEntreprise, et 'q' représente un élément de Questions.
                .Join(_context.Questions, re => re.question_id, q => q.id, (re, q) => new { re, q })
                // Jointure entre le résultat de la jointure précédente et la table Entreprise sur l'ID de l'entreprise.
                // 'combined' contient le résultat de la première jointure (qui inclut les éléments de ReponseEntreprise et Questions),
                // et 'e' représente un élément de Entreprise.
                .Join(_context.Entreprise, combined => combined.re.entreprise_id, e => e.id, (combined, e) => new GrilleCompleteEntrepriseJson
                {
                    Entreprise = e.name,
                    Question = combined.q.libelle,
                    ReponseValue = combined.re.reponse_value.ToString(),
                    Commentaire = combined.re.commentaire
                })
                .Distinct()
                .ToList();

            if (!grilles.Any())
            {
                logger.Warn($"Aucune grille n'a été trouvée pour l'entreprise {idEntreprise}");
                return NotFound();
            }

            return Ok(grilles);
        }

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
            logger.Info($"Une demande de récupération des questions pour une catégorie a été effectuée");
            List<string?> listQuestions = _context.Questions.Where(c => c.item.Contains(categorie))
                                                            .Select(c => c.libelle)
                                                            .Distinct()
                                                            .ToList();

            if (listQuestions.Count == 0)
            {
                logger.Warn($"Aucune question n'a été trouvée pour la catégorie {categorie}");
                return NotFound();
            }

            return Ok(listQuestions);
        }

        //Recherche de questions
        [HttpGet("/search/questions")]
        public IActionResult GetQuestionsSinceQuery(string q)
        {
            logger.Info($"Recherche de questions contenant: {q}");
            List<string?> questions = _context.Questions
                                    .Where(question => question.libelle.Contains(q))
                                    .Select(question => question.libelle)
                                    .Distinct()
                                    .ToList();

            if (!questions.Any())
            {
                logger.Warn($"Aucune question trouvée contenant: {q}");
                return NotFound();
            }

            return Ok(questions);
        }
        #endregion
    }
}
