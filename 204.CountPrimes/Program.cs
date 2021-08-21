using System;
using System.Linq;

namespace _204.CountPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Change the values as you wish. Rule: number parameter has to be > 1 and count needs to be LESS than number
            int number = 10;

            // A prime number is a natural number that has exactly two distinct natural number divisors: the number 1 and itself
            var result = CountPrimesLessThanParameter(number);

            Console.WriteLine("Total of Primes Numbers: " + result.ToString());
            Console.ReadKey();
        }

        static int CountPrimesLessThanParameter(int number)
        {
            if (number < 3)
                return 0;

            return PrimeNumbersCount(number);
        }

        static private int PrimeNumbersCount(int number)
        {
            bool[] isPrime = new bool[number];
            //Set all items as true from 2 onwards
            for (int i = 2; i < number; i++)
            {
                isPrime[i] = true;
            }

            //Used i * i to avoid use square (Math.sqrt), to improve perfomance
            for (int i = 2; i * i < number; i++)
            {
                if (!isPrime[i])
                    continue;

                for (int j = i * i; j < number; j+= i)
                {
                    isPrime[j] = false;
                }
            }

            //Return only the prime numbers that has been not flagged as false
            return isPrime.Where(i => i == true).Count();
        }
    }
}
