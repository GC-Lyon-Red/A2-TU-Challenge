namespace TU_Challenge.Tests
{
    /// <summary>
    /// Exercice 2, cette fois-ci on fait un peu d'algorythme jouant avec des boucles
    /// Pour rendre les tests visible, tu dois passer le "#if false" à "#if true" ligne 7
    /// </summary>
#if false
    public class Test2_Strings
    {
        [Test]
        [TestCase("HelloWorld", false)]
        [TestCase("", true)]
        [TestCase(" ", true)]
        [TestCase("    ", true)]
        [TestCase("    coucou", false)]
        [TestCase(null, true)]
        public void CreateIsNullOrEmpty(string input, bool expected)
        {
            bool result = MyStringImplementation.IsNullEmptyOrWhiteSpace(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("ABCD", "ZYXW", "AZBYCXDW")]
        [TestCase("ZYXW", "ABCD","ZAYBXCWD")]
        [TestCase("ZYXW", "AB","ZAYBXW")]
        [TestCase("AB", "ZYXW", "AZBYXW")]
        public void MixStrings(string a, string b, string expected)
        {
            string result = MyStringImplementation.MixString(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("ABCD", null)]
        [TestCase(null, "ABCD")]
        [TestCase("", "AB")]
        [TestCase("AB", "")]
        public void BreakMixStrings(string a, string b)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                MyStringImplementation.MixString(a, b);
            });
        }

        /// <summary>
        /// Interdiction d'utiliser ToLower de la string.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="expected"></param>
        [Test]
        [TestCase("J'ai pas d'ORIGINALITÉ", "j'ai pas d'originalité")]
        [TestCase("STAR WARS SURCOTÉ", "star wars surcoté")]
        [TestCase("Don't BE mad bro :(", "don't be mad bro :(")]
        public void LowerCase(string a, string expected)
        {
            string result = MyStringImplementation.ToLowerCase(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Hello", "eo")]
        [TestCase("Coucou", "ou")]
        [TestCase("Lorem Ipsum", "oeiu")]
        public void Voyelles(string a, string expected)
        {
            string result = MyStringImplementation.Voyelles(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("IIM", "MII")]
        [TestCase("HelloWorld", "dlroWolleH")]
        public void Reverse(string a, string expected)
        {
            string result = MyStringImplementation.Reverse(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        /// On prend une lettre sur 2, arrivé au bout on prend les lettres sautés
        [TestCase("HelloWorld", "HloolelWrd")]
        public void BazardString(string input, string expected)
        {
            string result = MyStringImplementation.BazardString(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        /// Opération inverse au BazardString
        [TestCase("HloolelWrd", "HelloWorld")]
        public void UnBazardString(string input, string expected)
        {
            string result = MyStringImplementation.UnBazardString(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        /// <summary>
        /// Bonus, non obligatoire pour aujourd'hui, pour comprendre le code de césar : 
        /// https://fr.wikipedia.org/wiki/Chiffrement_par_d%C3%A9calage
        /// https://www.dcode.fr/chiffre-cesar
        /// </summary>
        [TestCase("hello world", 3, "khoor zruog")]
        [TestCase("je suis balaise", 10, "to cesc lkvksco")]
        public void StringToCesarCode(string input, int offset, string expected)
        {
            string result = MyStringImplementation.ToCesarCode(input, offset);
            Assert.That(result, Is.EqualTo(expected));
        }

    }
#endif
}