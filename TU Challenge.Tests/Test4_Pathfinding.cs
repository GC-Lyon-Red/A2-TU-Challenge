using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Tests
{
    /// <summary>
    /// La c'est la classe, c'est bonus pour ceux qui veulent se casser un peu les dents. 
    /// Il n'est pas obligatoire pour aujourd'hui. Pour l'aspect théorique on fait comme les grands
    /// et on lit des blogs de vulga mathématique
    /// https://www.redblobgames.com/pathfinding/a-star/introduction.html
    /// Ces TU ne représentent que le premier algo : Breadth First Search
    /// Pour rendre les tests visible, tu dois passer le "#if false" à "#if true" ligne 17
    /// </summary>
#if false
    public class Test4_Pathfinding
    {
#region
        const string _map1 = "_____\n" +
                             "__X__\n" +
                             "_____";

        const string _map2 = "_____\n" +
                             "__X__\n" +
                             "__X__\n" +
                             "__X__\n" +
                             "__X__";

        const string _map3 = "__X__\n" +
                             "__X__\n" +
                             "__X__\n" +
                             "__X__\n" +
                             "__X__";
#endregion

        [Test]
        public void TestConstructMap1()
        {

            var p = new Pathfinding(_map1);

            Assert.IsTrue(p.Grid.GetLength(0) == 3);
            Assert.IsTrue(p.Grid.GetLength(1) == 5);

            Assert.IsTrue(p.Grid[0, 0] == '_');
            Assert.IsTrue(p.Grid[1, 2] == 'X');
            Assert.IsTrue(p.Grid[2, 4] == '_');
        }

        [Test]
        public void TestConstructMap2()
        {
            var p = new Pathfinding(_map2);

            Assert.IsTrue(p.Grid.GetLength(0) == 5);
            Assert.IsTrue(p.Grid.GetLength(1) == 5);

            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(p.Grid[0, i] == '_');
            }

            for (int i = 1; i < 5; i++)
            {
                Assert.IsTrue(p.Grid[i, 2] == 'X');
            }
        }

        [Test]
        public void TestConstructMap3()
        {
            var p = new Pathfinding(_map3);

            Assert.IsTrue(p.Grid.GetLength(0) == 5);
            Assert.IsTrue(p.Grid.GetLength(1) == 5);

            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(p.Grid[i, 2] == 'X');
            }
        }

        [Test]
        [TestCase(-1, 0, true)]
        [TestCase(0, 0, false)]
        [TestCase(2, 2, false)]
        [TestCase(0, -1, true)]
        [TestCase(3, -1, true)]
        [TestCase(2, 3, false)]
        [TestCase(3, 5, true)]
        public void IsOutOfBound(int x, int y, bool expected)
        {
            var p = new Pathfinding(_map1);
            var result = p.IsOutOfBound(new Vector2(x, y));

            Assert.IsTrue(result == expected);
        }



        [Test]
        [TestCase(1, 2, 8)]
        [TestCase(1, 3, 7)]
        [TestCase(0, 0, 3)]
        [TestCase(1, 0, 5)]
        [TestCase(2, 4, 3)]
        public void GetNeighboors(int x, int y, int countExpected)
        {
            Pathfinding p = new Pathfinding(_map1);
            var result = p.GetNeighboors(new Vector2(x, y));
            Assert.IsTrue(result.Count == countExpected);
        }

        [Test]
        [TestCase(1, 2, 7)]
        [TestCase(1, 3, 5)]
        [TestCase(0, 0, 2)]
        [TestCase(1, 0, 5)]
        [TestCase(2, 4, 3)]
        public void GetNeighboorsExclude(int x, int y, int countExpected)
        {
            var exclude = new List<Vector2>()
            {
                new Vector2(1,0),
                new Vector2(1,2),
                new Vector2(2,2),
                new Vector2(0,4),
            };

            Pathfinding p = new Pathfinding(_map1);
            var result = p.GetNeighboors(new Vector2(x, y), exclude);

            Assert.IsTrue(result.Count == countExpected);
        }

        [Test]
        [TestCase(0, 0, 2, 4, 1, true)]
        [TestCase(0, 0, 2, 4, 2, true)]
        [TestCase(4, 0, 2, 4, 2, true)]
        [TestCase(0, 0, 2, 4, 3, false)]
        public void BreadthFirstSearch(int startX, int startY, int destX, int destY, int mapIndex, bool pathFound)
        {
            Vector2 start = new Vector2(startX, startY);
            Vector2 destination = new Vector2(destX, destY);
            string map = "";
            switch (mapIndex)
            {
                case 1: map = _map1; break;
                case 2: map = _map2; break;
                case 3: map = _map3; break;
                default: break;
            }

            Pathfinding p = new Pathfinding(map);
            var path = p.BreadthFirstSearch(start, destination);

            bool isComplete = path.IsComplete(start, destination);
            Assert.IsTrue(isComplete == pathFound);

            if(isComplete)
            {
                foreach(var el in path.CompletePath)
                {
                    Assert.IsTrue(p.GetCoord(el) == '_');
                }
            }
        }

    }
#endif
}
