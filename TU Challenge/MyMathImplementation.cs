using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TU_Challenge;


namespace TU_Challenge
{
    public class MyMathImplementation
    {

        public int Add(int a, int b)
        {
            return a + b;
        }
        public bool IsMajeur(int age)
        {

            if (age is < 0 or >= 150) throw new ArgumentException("Age must be real");
            return age >= 18;
        }
        public bool IsEven(int a)
        {
            return a % 2 == 0;
        }
        public bool IsDivisible(int a, int b)
        {
            return a % b == 0;
        }
        public bool IsPrimary(int a)
        {
            int returnValue = 0;

            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0) returnValue++;
            }
            return returnValue == 2;
        }
        public List<int> GetAllPrimary(int a)
        {
            List<int> returnValue = new List<int>();
            int isPrimary = 0;
            for (int i = 1; i <= a; i++)
            {
                isPrimary = 0;
                for (int j = 1; j <= a; j++)
                {
                    if (i % j == 0) isPrimary++;
                }
                if (isPrimary == 2) returnValue.Add(i);
            }
            return returnValue;
        }
        public int Power2(int a)
        {
            return a * a;
        }
        public int Power(int a, int b)
        {
            int returnValue = a;

            for (int i = 1; i < b; i++)
            {
                returnValue = returnValue * a;
            }
            return returnValue;
        }
        public int IsInOrder(int a, int b)
        {
            if (a < b) return 1;
            else if (a > b) return -1;
            else return 0;
        }
        public bool IsListInOrder(List<int> list)
        {
            bool returnValue = true;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (IsInOrder(list[i], list[i + 1]) is 1 or 0)
                {
                    returnValue = true;

                }
                else returnValue = false;
            }
            return returnValue;

        }
        public List<int> Sort(List<int> list)
        {
            List<int> returnValue = new List<int>();
            int temp;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (IsInOrder(list[i], list[i + 1]) is 1 or 0)
                {
                    temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                }
            }
            return returnValue;
        }

    }


}
