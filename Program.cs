using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ADS103_BankiBalazs_A00134575_A1_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedlist1 = new LinkedList(); // instantiating-creating new object linkedlist1 from linkedlist class
            LinkedList linkedlist2 = new LinkedList(); // instantiating-creating new object linkedlist2 from linkedlist class
            Random random = new Random();               // instantiating random numbers from Random class

            Stopwatch stopwatch = new Stopwatch();  // instantiating stopwatch from stopwatch class

            stopwatch.Start();                      // starting stopwatch method to measure time taken for adding
            Thread.Sleep(10000);                     // suspending the current thread for 10000 millisecond
            for (int i = 0; i < 50000; i++)         // 50000 random numbers at the beginning of linkedlist1 with for loop to iterate 50000 times
            {                                           // each time generating random numbers with the random.Next method inside the AddFisrt method
                linkedlist1.AddFirst(random.Next());        // calling the AddFirst method with random method inside to add random numbers to linkedlist1 object
            }
            stopwatch.Stop();                       // stopping stopwatch method to finish measuring time taken to add 50000 random numbers to linkedlist1
            TimeSpan ts1 = stopwatch.Elapsed;       // Get the elapsed time as a TimeSpan value, assigning ts1 the elapsed time
            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",  // Format the TimeSpan value as string 
            ts1.Hours, ts1.Minutes, ts1.Seconds,
            ts1.Milliseconds / 10);
            stopwatch.Reset();                       // resetting stopwatch

            stopwatch.Start();                      // starting stopwatch method to measure time taken for adding
            Thread.Sleep(10000);                    // suspending the current thread for 10000 millisecond
            for (int i = 0; i < 50000; i++)         // 50000 random numbers at the end of linkedlist2 object with for loop to iterate 50000 times
            {
                linkedlist2.AddEnd(random.Next());  // each time generating random numbers with the random.Next method inside the AddEnd method
            }                                           // calling the AddEnd method with random method inside to add random numbers to linkedlist2 object
            stopwatch.Stop();                        // stopping stopwatch method to finish measuring time taken to add 50000 random numbers
                                                        // to the end of linkedlist2
            TimeSpan ts2 = stopwatch.Elapsed;                                   // Get the elapsed time as a TimeSpan value
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",  // Format the TimeSpan value as string
            ts2.Hours, ts2.Minutes, ts2.Seconds,
            ts2.Milliseconds / 10);

            if (ts1 < ts2)  // if statement to determine the time taken to add numbers to the list with the two different method
            {
                Console.WriteLine($"Adding numbers at the front of the list took {elapsedTime1} time which is less than at the end of the list {elapsedTime2}");
            }
            else 
            {
                Console.WriteLine($"Adding numbers at the end of the list took {elapsedTime2} time which is less than at the fron of the list {elapsedTime1}");

            }

            stopwatch.Reset();                          // resetting stopwatch
            stopwatch.Start();                          // starting stopwatch
            Thread.Sleep(10000);                        // suspending the current thread for 10000 millisecond
            linkedlist1.RemoveFront();                  // calling RemoveFront method on object linkedlist1
            stopwatch.Stop();                           // stopping stopwatch
            TimeSpan ts3 = stopwatch.Elapsed;           // Get the elapsed time as a TimeSpan value
            string elapsedTime3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts3.Hours, ts3.Minutes, ts3.Seconds,ts3.Milliseconds / 10);// Format the TimeSpan value as string
            stopwatch.Reset();                          // resetting stopwatch
            stopwatch.Start();                          // starting stopwatch
            Thread.Sleep(10000);                        // suspending the current thread for 10000 millisecond
            linkedlist2.RemoveEnd();                    // calling RemoveEnd method on object linkedlist2
            stopwatch.Stop();                           // stopping stopwatch
            TimeSpan ts4 = stopwatch.Elapsed;                                   // Get the elapsed time as a TimeSpan value
            string elapsedTime4 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts4.Hours, ts4.Minutes, ts4.Seconds,
            ts4.Milliseconds / 10);
            
            if (ts3 < ts4)  // if statement to determine the time taken to remove numbers from the list with the two different method
            {
                Console.WriteLine($"Removing numbers at the front of the list took {elapsedTime3} time which is less than at the end of the list {elapsedTime4}");
            }
            else
            {
                Console.WriteLine($"Removing numbers at the end of the list took {elapsedTime4} time which is less than at the front of the list {elapsedTime3}");

            }

        }
    }
    public class Node       // creating node class
    {
        public int data;    // creating data field of the class 
        public Node next;   // creating pointer of node class

        public Node(int _data) // Node class constructor, which takes integer _data parameters
        {
            data = _data;   // declaring the data property of Node 
            next = null; // declaring the next property of Node, no next node yet
        }
    }
    public class LinkedList                  // creating Linkedlist class
    {
        Node head = null;                   // assignig linkedlist class properties
        public int length;

        public LinkedList()              // class constructor
        {
            head = null;                 // assigning the value for properties of Linkedlist
        }

        public void AddFirst(int data)         // creating addfirst method of the linkedlist class
        {
            Node node = new Node(data);  // creating new node
            if (head == null)            // checking if the head is null
            {
                head = node;             // if the head is null than head points to the new node
                return;                    // there is no need for more action therefore we return from this function
            }
            node.next = head;            // head is pointing to the new node
            head = node;                  // head becomes the new node
        }
        public void AddEnd(int data)        // creating addlast method of the linkedlist class
        {
            Node node = new Node(data);      // creating new node

            if (head == null)                // checking if the head is null
            {
                head = node;                 // if the head is null than head becomes the new node
                return;                      // if the above condition is met there is no need for more action therefore we return from this function
            }
            Node current = head;            // if there is only one node in the linkedlist then we add node to the list
            while (current.next != null)    // if the next node has value
            {
                current = current.next;     // then the node is added and pointing to the next node
            }
            current.next = node;            // the node is pointing to the next node
        }

        public void RemoveFront()           // creating remove first class of the linkedlist class
        {
            if (head == null)                               // checking if the list is empty then displaying the message
            { Console.WriteLine("Linkedlist is empty"); }

            while (head != null)                // if the head has value then
            {
                Node toRemove = head;           // assigning temporary variable to the head
                head = head.next;               // moving the pointer to the next node
                toRemove = null;                // cancelling the node to be removed
                return;                         // returning from the function when all nodes removed
            }
        }
        public void RemoveEnd()                             // creating remove from the end class of the linkedlist class
        {
            Node current = head;                            // assigning temporary variable to the head
            Node nextNode = current.next;                   // assigning temporary variable to the next node
            if (head == null)                               // checking if the list is empty
            {
                Console.WriteLine("Linkedlist is empty");
                return;                                      // if the list is empty we return from the function               
            }
            else                                            // otherwise
            {
                while (current.next != null)                // while the node is pointing to the next node
                {
                    if (nextNode.next == null)              // if the pointer is pointing to null
                    {
                        current.next = null;                // then the last node can be removed
                    }
                    current = nextNode;                     // the node before the last node becomes the last node
                    nextNode = nextNode.next;               // the last node pointer is created
                }
                current = null;                             // removing the head
                return;                                     // returning from the function
            }
        }
    }
}
