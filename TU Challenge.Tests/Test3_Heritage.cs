using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TU_Challenge.Heritage;

namespace TU_Challenge.Tests
{
    /// <summary>
    /// Exercice 3 : on attaque l'héritage avec virtual/override, évènements et protected
    /// Pour rendre les tests visible, tu dois passer le "#if false" à "#if true" ligne 14
    /// </summary>
#if false
    public class Test3_Heritage
    {
        [Test]
        public void ChatEstUnAnimalEtPossedeUnNom()
        {
            Chat c = new Chat("Matou");

            Assert.IsTrue(c is Animal);
            Assert.That(c.Name, Is.EqualTo("Matou"));
        }

        [Test]
        public void ChatFaitMiaou()
        {
            Chat c = new Chat("Garfield");

            Assert.That(c.Crier(), Is.EqualTo("Miaou (j'ai faim)"));
        }

        bool _flag;
        public void DetectDie()
        {
            _flag = true;
        }

        [Test]
        public void ChatPeutMourrir() // Pour rappel aucun animal n'a été maltraité durant le test unitaire
        {
            Chat c = new Chat("Chapin");

            // Arrange
            _flag = false;
            c.OnDie += DetectDie;

            // Act
            c.Die();

            // Assert
            Assert.IsTrue(_flag);
            c.OnDie -= DetectDie;
        }

        [Test]
        public void ChatPattes()
        {
            Chat c = new Chat("Nougat");

            Assert.That(c.Pattes, Is.EqualTo(4));

        }

        [Test]
        public void ChatBoiteux()
        {
            ChatQuiBoite c = new ChatQuiBoite("Boite");
            Chat c2 = new Chat("Pas Boite");

            Assert.IsTrue(c is Chat);
            Assert.IsTrue(c is Animal);
            Assert.That(c.Pattes, Is.EqualTo(3));

            Assert.IsTrue(c2 is Chat);
            Assert.IsTrue(c2 is Animal);
            Assert.That(c2.Pattes, Is.EqualTo(4));
        }

        [Test]
        public void CreerAnimalerie()
        {
            Animalerie a = new Animalerie();
            Chat c = new Chat("Ganache");

            a.AddAnimal(c);

            Assert.IsTrue(a.Contains(c));
        }

        [Test]
        public void CreerAnimalerieAvecChatEtChien()
        {
            Animalerie a = new Animalerie();
            Chat chat = new Chat("Praline");
            Chien chien = new Chien("Rufus");

            a.AddAnimal(chat);
            a.AddAnimal(chien);

            Assert.IsTrue(a.Contains(chat));
            Assert.IsTrue(a.Contains(chien));
        }

        [Test]
        public void CreerAnimalerieEtLesFaireCrier()
        {
            Animalerie a = new Animalerie();
            Chat chat = new Chat("Praline");
            Chien chien = new Chien("Rufus");

            a.AddAnimal(chat);
            a.AddAnimal(chien);

            Assert.That(a.GetAnimal(0).Crier(), Is.EqualTo("Miaou (j'ai faim)"));
            Assert.That(a.GetAnimal(1).Crier(), Is.EqualTo("Ouaf (j'ai faim)"));
        }

        [Test]
        public void CreerAnimalerieEtLesFaireCrierPuisNourrir()
        {
            Animalerie a = new Animalerie();
            Chat chat = new Chat("Praline");
            Chien chien = new Chien("Rufus");

            a.AddAnimal(chat);
            a.AddAnimal(chien);

            Assert.That(a.GetAnimal(0).Crier(), Is.EqualTo("Miaou (j'ai faim)"));
            Assert.That(a.GetAnimal(1).Crier(), Is.EqualTo("Ouaf (j'ai faim)"));
            a.FeedAll();

            Assert.That(a.GetAnimal(0).Crier(), Is.EqualTo("Miaou (c'est bon laisse moi tranquille humain)"));
            Assert.That(a.GetAnimal(1).Crier(), Is.EqualTo("Ouaf (viens on joue ?)"));
        }


        bool _zooEvent;
        void DetectAddAnimal(Animal addedAnimal)
        {
            _zooEvent = true;
        }
        [Test]
        public void CreerZooEtRecevoirEvent()
        {
            Animalerie a = new Animalerie();
            Chat chat = new Chat("Reglisse");
            _zooEvent = false;

            a.OnAddAnimal += DetectAddAnimal;
            a.AddAnimal(chat);

            Assert.IsTrue(_zooEvent);
        }

        [Test]
        public void LesAnimauxPeuventInteragirDansLanimalerie()
        {
            Animalerie a = new Animalerie();
            Poisson p = new Poisson("Bubulle");
            Chat chat = new Chat("Radis");

            Assert.That(chat.Crier(), Is.EqualTo("Miaou (j'ai faim)"));
            a.AddAnimal(p);

            Assert.That(p.IsAlive, Is.EqualTo(true));

            a.AddAnimal(chat);

            Assert.That(p.IsAlive, Is.EqualTo(false));  //Oups
            Assert.That(chat.Crier(), Is.EqualTo("Miaou (Le poisson etait bon)"));
        }

        [Test]
        public void LesAnimauxPeuventSinscrireACetEvent()
        {
            Animalerie a = new Animalerie();
            Poisson p = new Poisson("Bubulle");
            Chat chat = new Chat("Radis");

            Assert.That(p.IsAlive, Is.EqualTo(true));
            Assert.That(chat.Crier(), Is.EqualTo("Miaou (j'ai faim)"));

            a.AddAnimal(chat);

            a.AddAnimal(p);

            Assert.That(p.IsAlive, Is.EqualTo(false));  //Oups
            Assert.That(chat.Crier(), Is.EqualTo("Miaou (Le poisson etait bon)"));
        }

        [Test]
        public void MaisChatBoiteuxNeMangePasLePoisson()
        {
            Animalerie a = new Animalerie();
            Poisson p = new Poisson("Bubulle");
            ChatQuiBoite chat = new ChatQuiBoite("PasDePat(trouille)");

            Assert.That(chat.Crier(), Is.EqualTo("Miaou (j'ai faim)"));
            a.AddAnimal(p);

            Assert.That(p.IsAlive, Is.EqualTo(true));

            a.AddAnimal(chat);

            Assert.That(p.IsAlive, Is.EqualTo(true));
            Assert.That(chat.Crier(), Is.EqualTo("Miaou (j'ai faim)"));
        }

        [Test]
        public void Poisson()
        {
            Poisson p = new Poisson("Nemo");

            Assert.That(p.Pattes, Is.EqualTo(0));
        }

        [Test]
        public void PoissonRajouteUnSuffixASonNom()
        {
            Poisson p = new Poisson("Nemo");

            Assert.That(p.Name, Is.EqualTo("Nemo le poisson"));
        }
    }
#endif
}
