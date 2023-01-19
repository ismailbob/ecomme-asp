namespace ProjetE_comm.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public int PanierId { get; set; }
        public Panier? Panier { get; set; }
        public ICollection<Lignepanier>? LignePaniers { get; set; }

    }
}
