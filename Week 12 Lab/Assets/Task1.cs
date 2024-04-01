using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class task1 : MonoBehaviour
{
    // List of random names
    List<string> randomFirstNames = new List<string> { "Alice", "Bob", "Carol", "David", "Eve", "Frank", "Grace", "Hank", "Ivy", "Jack",
                                                       "Kate", "Liam", "Mia", "Noah", "Olivia", "Peter", "Quinn", "Rose", "Sam", "Tom" };
    List<string> randomLastNames = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };

    // Queue to store players waiting to log in
    Queue<string> loginQueue = new Queue<string>();

    void Start()
    {
        // Initialize the initial login queue with 5 players
        for (int i = 0; i < 5; i++)
        {
            AddRandomPlayerToQueue();
        }

        // Debug log the initial login queue
        Debug.LogFormat("Initial login queue created. There are {0} players in the queue: {1}", loginQueue.Count, string.Join(", ", loginQueue.ToArray()));

        // Start the coroutine to add random players to the queue and log them in
        StartCoroutine(ManagePlayerLogin());
    }

    // Coroutine to manage player login
    IEnumerator ManagePlayerLogin()
    {

        // Add a random player to the queue
        AddRandomPlayerToQueue();

        // Log in a player if the queue is not empty
        if (loginQueue.Count > 0)
        {
            string player = loginQueue.Dequeue();
            Debug.Log(player + " is now inside the game.");
        }

        // Wait for a random amount of time before the next iteration
        yield return new WaitForSeconds(Random.Range(1f, 3f));

    }

    // Method to add a random player to the login queue
    void AddRandomPlayerToQueue()
    {
        string randomName = GetRandomName();
        loginQueue.Enqueue(randomName);
        Debug.Log(randomName + " is trying to login and added to the login queue.");
    }

    // Method to get a random name from the name library
    string GetRandomName()
    {
        string randomFirstName = randomFirstNames[Random.Range(0, randomFirstNames.Count)];
        string randomLastName = randomLastNames[Random.Range(0, randomLastNames.Count)];
        return randomFirstName + " " + randomLastName;
    }
}