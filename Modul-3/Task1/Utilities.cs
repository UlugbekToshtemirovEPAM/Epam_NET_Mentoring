using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class Utilities
    {
        /// <summary>
        /// Sorts an array in ascending order using bubble sort.
        /// </summary>
        /// <param name="numbers">Numbers to sort.</param>
        public static void Sort(int[] numbers)
        {
            int temp;

            if (numbers == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = 0; j < numbers.Length - 1 - i; j++)
                    {
                        if (numbers[j] > numbers[j + 1])
                        {
                            temp = numbers[j];
                            numbers[j] = numbers[j + 1];
                            numbers[j + 1] = temp;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Searches for the index of a product in an <paramref name="products"/> 
        /// based on a <paramref name="predicate"/>.
        /// </summary>
        /// <param name="products">Products used for searching.</param>
        /// <param name="predicate">Product predicate.</param>
        /// <returns>If match found then returns index of product in <paramref name="products"/>
        /// otherwise -1.</returns>
        public static int IndexOf(Product[] products, Predicate<Product> predicate)
        {
            if (products == null || predicate == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (predicate(products[i]))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
