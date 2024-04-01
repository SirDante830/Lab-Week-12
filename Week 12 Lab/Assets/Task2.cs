using UnityEngine;
using System.Collections.Generic;

public class Task2 : MonoBehaviour
{
    string names;
    string dupNames;
    void Start()
    {
        //Initialize List
        List<string> randomFirstNames = new List<string> { "Alice", "Bob", "Carol", "David", "Eve", "Frank", "Grace", "Hank", "Ivy", "Jack",
                                                       "Kate", "Liam", "Mia", "Noah", "Olivia", "Peter", "Quinn", "Rose", "Sam", "Tom" };

        //Initialize HashSet for duplicate and unique names
        HashSet<string> duplicateNames = new HashSet<string>();
        HashSet<string> uniqueNames = new HashSet<string>();

        // Create an array to hold the random names
        string[] randomArray = new string[15];

        // Populate the array with random elements from the list
        for (int i = 0; i < randomArray.Length; i++)
        {
            // Generate a random index within the range of the list
            int randomIndex = Random.Range(0, randomFirstNames.Count);

            // Assign the element at the random index to the array
            randomArray[i] = randomFirstNames[randomIndex];
            if (!uniqueNames.Add(randomArray[i]))
            {
                duplicateNames.Add(randomArray[i]);
            }
        }
        foreach (string element in duplicateNames)
        {
            dupNames += element;
            dupNames += ", ";
        }
        // Print the random array elements (you can remove this part if not needed)
        for (int i = 0; i < randomArray.Length; i++)
        {
            names += randomArray[i];
            names += ", ";
        }

        Debug.Log("Created the name array: " + names);
        Debug.Log("Duplicate Names: " + dupNames);
    }
}