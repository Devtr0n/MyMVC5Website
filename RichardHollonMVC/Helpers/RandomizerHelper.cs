using System;

namespace RichardHollonMVC.Helpers
{
    public class RandomizerHelper
    {
        static Random _random = new Random();

        public static T[] Shuffle<T>(T[] array)
        {
            var random = _random;
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i);
                // Swap elements
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }

            return array;
        }

    }
}