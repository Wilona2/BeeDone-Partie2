using BeeDone.Data;
using BeeDone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeDone.ViewModels
{
    public class MainViewModel
    {
        private readonly ITacheDataProvider _tacheDataProvider;
        public ObservableCollection<Tache> Taches { get; } = new ObservableCollection<Tache>();
        public string NouvelleTache { get; set; }
        public Tache TacheSelectionnee { get; set; }

        public MainViewModel(ITacheDataProvider tacheDataProvider)
        {
            _tacheDataProvider = tacheDataProvider;
        }

        public void ChargerTaches()
        {
            foreach (Tache tache in _tacheDataProvider.GetTaches())
            {
                Taches.Add(tache);
            }
        }

        public bool AjouterTache()
        {
            string? titreTache = NouvelleTache?.Trim();

            if (string.IsNullOrEmpty(titreTache))
                return false;

            Tache nouvelleTache = new Tache(titreTache);
            Taches.Add(nouvelleTache);
            NouvelleTache = string.Empty;
            return true;
        }

        public bool SupprimerTache()
        {
            if (TacheSelectionnee is null)
                return false;

            Taches.Remove(TacheSelectionnee);
            return true;
        }
    }
}
