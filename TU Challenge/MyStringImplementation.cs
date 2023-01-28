using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        public bool IsNullEmptyOrWhiteSpace(string input)
        {
            if (input is not null || input?.Length is not 0)
            {
                for (int i = 0; i < input?.Length; i++)
                {
                    if (input[i] is not ' ')
                    {
                        return false;
                    }
                }
                return true;
            }
            else { return true; }


        }
        public string MixString(string a, string b)
        {
            if (a is null || b is null || a.Length is 0 || b.Length is 0) throw new ArgumentException("C'est génant");

            string returnValue = "";
            string smallest = "";
            string longest = "";

            if (a.Length < b.Length)
            {
                smallest = a;
                longest = b;
            }
            else
            {
                smallest = b;
                longest = a;
            };

            for (int i = 0; i < smallest.Length; i++)
            {
                returnValue += a[i];
                returnValue += b[i];
            }
            for (int j = smallest.Length; j < longest.Length; j++)
            {
                returnValue += longest[j];
            }
            return returnValue;

        }
        public string ToLowerCase(string a)
        {
            string returnValue = "";
            int myInt;
            for (int i = 0; i < a.Length; i++)
            {
                if ((int)a[i] is >= 65 and <= 90 || (int)a[i] == 201)
                {
                    myInt = a[i] + 32;
                    returnValue += (char)myInt;
                }
                else if (a[i] is ' ')
                    returnValue += ' ';
                else
                {
                    returnValue += a[i];
                }

            }
            return returnValue;
        }
        public string Voyelles(string a)
        {
            string returnValue = "";
            string loweredString = ToLowerCase(a);
            char[] voyelles = new char[6] { 'a', 'e', 'i', 'o', 'u', 'y' };
            List<char> usedVowels = new List<char>();
            for (int i = 0; i < loweredString.Length; i++)
            {
                if (voyelles.Contains(loweredString[i]) && !usedVowels.Contains(loweredString[i]))
                {
                    usedVowels.Add(loweredString[i]);
                    returnValue += loweredString[i];

                }
            }
            return returnValue;
        }
        public string Reverse(string a)
        {
            string returnValue = "";

            for (int i = a.Length - 1; i >= 0; i--)
            {
                returnValue += a[i];
            }
            return returnValue;
        }
        public string BazardString(string a)
        {


            string returnValue = "";
            returnValue += a[0];
            for (int i = 0; i < a.Length - 2; i += 2)
            {

                returnValue += a[i + 2];
            }
            for (int i = 0; i < a.Length - 1; i += 2)
            {

                returnValue += a[i + 1];
            }
            return returnValue;
        }
        public string UnBazardString(string a)
        {
            string returnValue = "";

            returnValue += a[0];
            for (int i = a.Length / 2; i < a.Length - 1; i += 1)
            {
                returnValue += a[i];
                returnValue += a[i - 4];
            }
            returnValue += a[a.Length - 1];
            //not sure that it works if a.Length / 2 is not odd
            return returnValue;
        }
    }
}
