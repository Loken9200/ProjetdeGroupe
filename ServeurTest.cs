using LeGrandRestaurant.Test.Utilities;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class ServeurTest
    {
        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur " +
              "QUAND on récupére son chiffre d'affaires " +
              "ALORS celui-ci est à 0")]
        public void CA_0_NouveauServeur()
        {
            var serveur = ServeurBuilder.Default;

            var chiffreAffaires = serveur.ChiffreAffaires;
            
            Assert.Equal(0, chiffreAffaires);
        }

        [Fact(DisplayName ="ÉTANT DONNÉ un nouveau serveur " +
                           "QUAND il prend une commande " +
                           "ALORS son chiffre d'affaires est le montant de celle-ci")]
        public void Ajout_CA_Commande()
        {
            var serveur = ServeurBuilder.Default;
            
            const decimal montant = 15.28m;
            var commande = new Commande(montant);

            serveur.PrendreCommande(commande);
            
            Assert.Equal(montant, serveur.ChiffreAffaires);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un serveur ayant déjà pris une commande " +
                            "QUAND il prend une nouvelle commande " +
                            "ALORS son chiffre d'affaires est la somme des deux commandes")]
        public void Seconde_Commande()
        {
            // ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var serveur = ServeurBuilder.Default;

            const decimal montantPremiereCommande = 15.28m;
            var premiereCommande = new Commande(montantPremiereCommande);

            serveur.PrendreCommande(premiereCommande);

            // QUAND il prend une nouvelle commande
            const decimal montantNouvelleCommande = 78.87m;
            var nouvelleCommande = new Commande(montantNouvelleCommande);
            serveur.PrendreCommande(nouvelleCommande);

            // ALORS son chiffre d'affaires est la somme des deux commandes
            var somme = montantNouvelleCommande + montantPremiereCommande;
            Assert.Equal(somme, serveur.ChiffreAffaires);
        }
    }
}
