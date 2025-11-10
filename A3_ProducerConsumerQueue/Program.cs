using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 3: Producer-Consumer");
        Console.WriteLine("==========================================\n");

        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        List<Producer> producers = new List<Producer>();

        for (int i = 1; i <= 5; i++)
        {
            Producer producer = new Producer(i, queue);
            producers.Add(producer);
        }
    
        Console.WriteLine("Producer und Consumer gestartet...\n");

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen
        while (queue.Count <= 50)
        {
            Console.WriteLine("Aktuelle Größe: " + queue.Count);
            Thread.Sleep(1000);
        }

        Console.WriteLine("finale Größe: " + queue.Count);

        foreach(var prod in producers)
        {
            prod.Stop();
        }



        // TODO


        // Alle Producer stoppen


        // Consumer stoppen


    }
}
