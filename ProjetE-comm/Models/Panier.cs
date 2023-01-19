namespace ProjetE_comm.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public int nombreArticle { get; set; }
        public double total { get; set; }
        public ICollection<Commande>? Commandes { get; set; }
    }
}
