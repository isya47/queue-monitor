﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MonitorQueue
{
    class Program
    {
        static QueueClass QC = new QueueClass(50);
        static Stopwatch stopWatch = new Stopwatch();
        
        static void Main(string[] args)
        {
            
            //Test1
            /* tid[0] = new Thread(Action.pro);
             tid[0].Start();
             tid[1] = new Thread(Action.cons);
             tid[1].Start();
             Console.ReadLine();
             Console.WriteLine("Main thread done");
             */

            //Test2
            /*QueueClass QC = new QueueClass(100);
            var rand = new Random();
            for (int i = 0; i < 8; i = i + 2)
            {
                tid[i] = new Thread(new ParameterizedThreadStart(QC.Enqueue));
                tid[i].Start(rand.Next(0, 100));
                tid[i + 1] = new Thread(new ThreadStart(QC.Dequeue));
                tid[i + 1].Start();
            }

            while (true)
            {
                QC.Enqueue(rand.Next(0,100));
                
            }*/

            //Test3
            
            int N = 5;
            int M = 4;
            Thread[] threadEnqueue = new Thread[N];
            Thread[] threadDequeue = new Thread[M];
            
            stopWatch.Start();
            
            for (var i = 0; i < N; i++)
            {
                threadEnqueue[i] = new Thread(new ThreadStart(AddElement));
                threadEnqueue[i].Start();
            }

            for (var j = 0; j < M; j++)
            {
                threadDequeue[j] = new Thread(new ThreadStart(RemoveElement));
                threadDequeue[j].Start();
                
            }
        }

        public static void AddElement()
        {
            var rand = new Random();
            
            while (true)
            {
                
                QC.Enqueue(rand.Next(0, 50));
                var timeTaken = stopWatch.ElapsedMilliseconds;
                if (timeTaken >= 10000){break;}
            }
        }

        public static void RemoveElement()
        {
            while (true)
            {
                QC.Dequeue();
                var timeTaken = stopWatch.ElapsedMilliseconds;
                if (timeTaken >= 10000){break;}
            }
        }
    }
}