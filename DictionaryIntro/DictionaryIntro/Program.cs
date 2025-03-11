using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            List<int> values = new List<int>();

            // Generate 100 random integers between 0 and 29
            for (int i = 0; i < 100; ++i)
                values.Add(rng.Next(30));


            Dictionary<int, int> categoriedValues = new Dictionary<int, int>();

            // Perform a count of the values within the list.  Consider this to be a form 
            // of classification
            foreach(int i in values)
            {
                // If the key does not already exist in the dictionary, add it, and set the
                // instance count of the key value to 1
                if (!categoriedValues.ContainsKey(i))
                    categoriedValues[i] = 1;
                else
                    ++categoriedValues[i];      // otherwise increment the count of the value
                                                // related to the already existing key.
            }

            // Display all items in the Dictionary.  Remember we are dealing with KeyValuePairs
            foreach (KeyValuePair<int, int> kvp in categoriedValues)
                Console.WriteLine($"Key : {kvp.Key} - Count : {kvp.Value}");
            Console.WriteLine();

            // Start over with the Dictionary
            categoriedValues.Clear();

            // Reclassify using slightly different logic.  
            foreach (int i in values)
            {
                //This time, add a key if it is not found, but set the instance count to zero 
                if (!categoriedValues.ContainsKey(i))
                    categoriedValues.Add(i, 0);
                
                // Whether the key was new or not, ALWAYS increment the count of the value
                // related to the key
                ++categoriedValues[i];
            }

            // Display the dictionary values again, but this time iterate over the internal keys collection,
            // and use the index operator to access the corresponding values
            foreach (int i in categoriedValues.Keys)
                Console.WriteLine($"Key : {i} - Count : {categoriedValues[i]}");
            Console.WriteLine();

            // Extension methods, like WHERE still work with the Dictionary, but certain operations are easier
            // with a List.  The following turns the Dictionary into a list, then you may manipulate the 
            // List's contents, and finally convert the List back into a Dictionary.
            List<KeyValuePair<int, int>> temp = categoriedValues.ToList();
            categoriedValues = temp.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            // Iterate and display the result of the sorting operation above
            foreach (KeyValuePair<int, int> kvp in categoriedValues)
                Console.WriteLine($"Key : {kvp.Key} - Count : {kvp.Value}");
            Console.WriteLine();

            // Filtering is something you must be careful about.  By default, the WHERE would be evaluated
            // through a mechanism called deferred execution.  What this means is that each item in the dictionary
            // will be evaluated by the where criteria, and if the item matches, the foreach loop will be run
            // for that item.
            // This is good in situations where you may want to break out of the loop early, or
            // when dealing with large sets of information, there will be a more smooth operation of the code,
            // splitting the operations over time.
            // However, if one of the operations in the loop would change the original collection being
            // iterated, then you will experiece a crash.  In these types of situations, you must use a 
            // mechanism to force the deferred execution to complete up front.  One such way is using ToList().
            // The downside here is that you incur the entire cost of processing up front before the loop is
            // run for the first time.
            // Which way is better will be a design choice, sometimes forced by the need to modify the collection.
            // REMOVE THE .ToList() TO WATCH THE CONSEQUENCES OF MODIFYING THE COLLECTION
            foreach (KeyValuePair<int, int> kvp in categoriedValues.Where(kvp => kvp.Key % 2 == 0).ToList())
            {
                Console.WriteLine($"Key : {kvp.Key} - Count : {kvp.Value}");
                categoriedValues.Remove(kvp.Key);
            }
            Console.WriteLine();

            // Display the remaining items after the removals above.  All keys should be odd numbers.
            foreach (KeyValuePair<int, int> kvp in categoriedValues)
                Console.WriteLine($"Key : {kvp.Key} - Count : {kvp.Value}");
            Console.WriteLine();

            // Start over for a different type of classification
            Dictionary<int, List<int>> storedValues = new Dictionary<int, List<int>>();

            // This time we will store each integer instance when we find the corresponding key.
            // We are still using the original List of values from the beginning as the source, so you
            // should be able to verify that the counts are correct.
            foreach (int value in values)
            {
                // Add the key if not already present
                if (!storedValues.ContainsKey(value))
                    storedValues.Add(value, new List<int>());

                // Always add the current int to the corresponding List that matches
                storedValues[value].Add(value);
            }

            // Display the dictionary
            foreach (KeyValuePair<int, List<int>> kvp in storedValues)
            {
                // Push the Key out first
                Console.Write($"Key : {kvp.Key} - Stored Values :");
                // Iterate the values collection and display all the numbers stored
                foreach (int i in kvp.Value)
                    Console.Write(i + ", ");
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
