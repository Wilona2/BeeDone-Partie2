using BeeDone.Data;
using BeeDone.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BeeDone.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class TachesPage : Page
{
    public MainViewModel ViewModel { get; }

    public TachesPage()
    {
        ViewModel = new MainViewModel(new TacheDataProvider());
        InitializeComponent();
        /* Explication de : Loaded += MaisonPage_Loaded;
        Loaded est un événement que la page déclenche quand elle a été ajoutée à l’écran et que ses contrôles sont prêts.
        += ajoute une méthode à la liste de celles à appeler quand l’événement se produit. Sur un événement, ce n’est pas une addition.
        MaisonsPage_Loaded est la méthode appelée à ce moment-là, ici on souhaite charger les données du ViewModel. 
            Elle doit avoir la signature attendue par l’événement: (object sender, RoutedEventArgs e).
        */

        // En résumé : Quand la page est prête à l’écran, appelle MaisonsPage_Loaded qui va charger les données du ViewModel pour la vue
        Loaded += MaisonPage_Loaded;
    }

    private void MaisonPage_Loaded(object sender, RoutedEventArgs e)
    {
        ViewModel.ChargerTaches();
    }
    private async void btnAjouterTache_Click(object sender, RoutedEventArgs e)
    {
        if (!ViewModel.AjouterTache())
        {
            // Afficher un message d'erreur dans dialogue
            ContentDialog dialogue = new ContentDialog()
            {
                Title = "Erreur",
                Content = "Veuillez entrer une tâche avant d'ajouter.",
                CloseButtonText = "OK",
                XamlRoot = this.Content.XamlRoot
            };

            await dialogue.ShowAsync();
        }

    }

    private async void btnSupprimerTache_Click(object sender, RoutedEventArgs e)
    {
        if (!ViewModel.SupprimerTache())
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Erreur",
                Content = "Veuillez sélectionner une tâche à supprimer.",
                CloseButtonText = "OK",
                XamlRoot = this.Content.XamlRoot
            };
            await dialog.ShowAsync();

        }
    }

    private void btnFermerDetails_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}
