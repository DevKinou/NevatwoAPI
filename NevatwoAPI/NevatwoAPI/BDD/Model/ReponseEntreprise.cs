namespace NevatwoAPI.BDD.Model
{
    public class ReponseEntreprise
    {
        public int id { get; set; }
        public int? entreprise_id { get; set; }
        public int? question_id { get; set; }
        public int? reponse_value { get; set; }
        public string? commentaire { get; set; }
    }
}
