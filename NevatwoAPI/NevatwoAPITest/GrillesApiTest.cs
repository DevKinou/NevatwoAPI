using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using NevatwoAPI.Controllers;
using NevatwoAPI.BDD;
using NevatwoAPI.BDD.Model;
using NevatwoAPI.Json;

[TestClass]
public class ListEndpointControllerTests
{
    [TestMethod]
    // Verifie que les grilles sont bien renvoyées
    public void GetGrilles_ReturnsOkObjectResult_WithListOfGrilles()
    {
        // Arrange
        DbContextOptions<NevaTwoDbContext> options = new DbContextOptionsBuilder<NevaTwoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabaseForGetGrilles")
            .Options;

        using (NevaTwoDbContext context = new NevaTwoDbContext(options))
        {
            context.ReponseEntreprise.AddRange(
                new ReponseEntreprise { entreprise_id = 1, question_id = 1, reponse_value = 1, commentaire = "Comment 1" },
                new ReponseEntreprise { entreprise_id = 1, question_id = 2, reponse_value = 2, commentaire = "Comment 2" }
            );
            context.Questions.AddRange(
                new Questions { id = 1, libelle = "Question 1", axe = 1, item = "Category 1" },
                new Questions { id = 2, libelle = "Question 2", axe = 1, item = "Category 1" }
            );
            context.Entreprise.AddRange(
                new Entreprise { id = 1, name = "Entreprise 1" }
            );
            context.SaveChanges();
        }

        using (NevaTwoDbContext context = new NevaTwoDbContext(options))
        {
            ListEndpointController controller = new ListEndpointController(context);

            // Act
            IActionResult result = controller.GetGrilles(1);

            // Assert
            OkObjectResult okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            List<GrilleCompleteEntrepriseJson> returnValue = Xunit.Assert.IsType<List<GrilleCompleteEntrepriseJson>>(okResult.Value);
            Xunit.Assert.NotEmpty(returnValue);
        }
    }
}
