namespace ProjetE_comm.Models
{
    public class Lignepanier
    {
        public int Id { get; set; }
        public int quantite { get; set; }
        public int ProductId { get; set; }
        public int CommandeId { get; set; }
        public Product? Product { get; set; }
        public Commande? Commande { get; set; }

    }
}
