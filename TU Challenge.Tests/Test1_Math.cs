using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    /// <summary>
    /// Echauffement avec des fonctions mathématiques
    /// Interdiction d'utiliser Mathf ou Math évidemment
    /// </summary>

    public class Test1_Math
    {
        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(10, 20, 30)]
        [TestCase(-10, 20, 10)]
        [TestCase(10, -20, -10)]
        [TestCase(0, -20, -20)]
        [TestCase(-20, 0, -20)]
        public void Addition(int a, int b, int expected)
        {
            int result = MyMathImplementation.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, false)]
        [TestCase(12, false)]
        [TestCase(17, false)]
        [TestCase(18, true)]
        [TestCase(40, true)]
        [TestCase(140, true)]
        public void IsMajeur(int age, bool expected)
        {
            bool result = MyMathImplementation.IsMajeur(age);
            Assert.IsTrue(result == expected);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(150)]
        public void BreakIsMajeur(int age)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MyMathImplementation.IsMajeur(age);
            });
        }


        [Test]
        [TestCase(0, true)]
        [TestCase(2, true)]
        [TestCase(10, true)]
        [TestCase(-2, true)]
        [TestCase(1, false)]
        [TestCase(11, false)]
        public void IsEven(int a, bool expected)
        {
            bool result = MyMathImplementation.IsEven(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 2, true)]
        [TestCase(20, 2, true)]
        [TestCase(3, 2, false)]
        [TestCase(4, 2, true)]
        [TestCase(40, 4, true)]
        [TestCase(123, 3, true)]
        public void IsDivisible(int a, int b, bool expected)
        {
            bool result = MyMathImplementation.IsDivisible(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        [TestCase(6, false)]
        [TestCase(7, true)]
        [TestCase(8, false)]
        [TestCase(9, false)]
        [TestCase(10, false)]
        [TestCase(11, true)]
        [TestCase(12, false)]
        [TestCase(13, true)]
        [TestCase(22091, true)]
        [TestCase(22092, false)]
        public void IsPremier(int a, bool expected)
        {
            bool result = MyMathImplementation.IsPrimary(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 1)]
        [TestCase(20, 8)]
        [TestCase(120, 30)]
        public void GetListPremierList(int a, int countExpected)
        {
            List<int> result = MyMathImplementation.GetAllPrimary(a);

            Assert.That(result.Count, Is.EqualTo(countExpected));
            foreach (var el in result)
            {
                Assert.IsTrue(MyMathImplementation.IsPrimary(el));
            }
        }

        [Test]
        [TestCase(2, 4)]
        [TestCase(8, 64)]
        [TestCase(10, 100)]
        [TestCase(15, 225)]
        public void Power2(int a, int expected)
        {
            int result = MyMathImplementation.Power2(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 2, 4)]
        [TestCase(20, 3, 8000)]
        [TestCase(12, 4, 20736)]
        [TestCase(3, 8, 6561)]
        public void Power(int a, int b, int expected)
        {
            int result = MyMathImplementation.Power(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        [TestCase(0, 1, 1)]
        [TestCase(0, 10, 1)]
        [TestCase(20, 10, -1)]
        [TestCase(-20, 10, 1)]
        [TestCase(10, 0, -1)]
        [TestCase(20, 20, 0)]
        public void IsInOrder(int a, int b, int expected)
        {
            int result = MyMathImplementation.IsInOrder(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestIsInOrder()
        {
            // Test
            bool result = MyMathImplementation.IsListInOrder(
                new List<int>() { 12, 0, -1, 123, 45, 90, -123 });
            Assert.IsFalse(result);

            // Test
            result = MyMathImplementation.IsListInOrder(
                new List<int>() { 0, 12 });
            Assert.IsTrue(result);

            // Test
            result = MyMathImplementation.IsListInOrder(
                new List<int>() { 12, 12 });
            Assert.IsTrue(result);

            // Test
            result = MyMathImplementation.IsListInOrder(
                new List<int>() { 12 });
            Assert.IsTrue(result);

            // Test
            result = MyMathImplementation.IsListInOrder(
                new List<int>() { -123, -1, 0, 12, 45, 90, 123});
            Assert.IsTrue(result);
        }

        // Votre premier algorithme de tri à implémenter.
        // N'hésitez pas à me demander de l'aide sur la partie théorie.
        // Interdiction d'appeller Sort sur la liste.
        [Test]
        public void Sort()
        {
            var toSort = new List<int>() { 12, 0, -1, 123, 45, 90, -123 };

            List<int> result = MyMathImplementation.Sort(toSort);

            for (int i = 0; i < result.Count-1; i++)
            {
                Assert.IsTrue(result[i] < result[i + 1]);
            }

        }

        /// <summary>
        /// Test pas obligatoire mais essayez un peu quand même. N'hésitez pas à me demander de l'aide
        /// </summary>
        [Test]
        public void GenericSort()
        {
            var toSort = new List<int>() { 12, 0, -1, 123, 45, 90, -123 };

            List<int> result = MyMathImplementation.GenericSort(toSort, MyMathImplementation.IsInOrder);

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i] < result[i + 1]);
            }
        }
        /// <summary>
        /// Test pas obligatoire mais essayez un peu quand même. N'hésitez pas à me demander de l'aide
        /// </summary>
        [Test]
        public void GenericSortDesc()
        {
            var toSort = new List<int>() { 12, 0, -1, 123, 45, 90, -123 };

            List<int> result = MyMathImplementation.GenericSort(toSort, MyMathImplementation.IsInOrderDesc);

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i] > result[i + 1]);
            }
        }

    }
}
