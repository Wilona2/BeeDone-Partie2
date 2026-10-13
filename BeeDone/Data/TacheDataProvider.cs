using BeeDone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeDone.Data
{
    public class TacheDataProvider : ITacheDataProvider
    {
        public List<Tache> GetTaches()
        {
            List<Tache> taches = new List<Tache>();

            taches.Add(new Tache("Faire l'épicerie"));
            taches.Add(new Tache("Réviser WinUI"));

            return taches;

        }
    }
}
