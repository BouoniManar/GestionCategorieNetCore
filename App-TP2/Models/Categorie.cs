namespace App_TP2.Models
{
	public class Categorie
	{
		public int id { get; set; }
		public string nom { get; set; }
		public IEnumerable<SousCategorie> SousCategories { get; set; }
	}
}
