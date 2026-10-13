using System;

namespace BeeDone.Models
{
    public class Tache
    {
        public int Id { get; set; }
        public string? Nom { get; set; }

        public string? Description { get; set; }
        public DateTime DateAjout { get; set; }

        private static int _idCompteur = 0;

        public Tache(string nom, DateTime dateAjout, string description = "") : this(nom, description)
        {
            DateAjout = dateAjout;
        }

        public Tache(string nom, string description = " ")
        {
            Id = _idCompteur++;
            Nom = nom;
            Description = description;
            DateAjout = DateTime.Now;
        }

    }
}
