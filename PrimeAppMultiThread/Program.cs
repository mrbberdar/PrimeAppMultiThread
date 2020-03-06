using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;



namespace PrimeAPPMultiThread
{
    class Program
    {
        public static ConcurrentBag<long> data = new ConcurrentBag<long>(); //holds the prime numbers

        public static void addPrime(long start, long x)  //prime number generator
        {
            int inc = 0;
            for (long i = start; i <= x; i++)
            {
                if (i == 2)
                {
                    data.Add(i);
                }
                else
                {

                    for (int j = 2; j <= i - 1; j++)
                    {
                        if (i % j != 0)
                        {
                            inc++;
                        }
                    }
                    if (inc == i - 2)
                    {
                        data.Add(i);
                    }
                    inc = 0;
                }
            }
        }

        public static void readData(ConcurrentBag<long> l)  //reads the  prime numbers
        {
            var array = data.ToArray();
            Array.Sort(array);
            
            foreach (long v in array)
            {
                Console.Write(v + " ");
            }
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start(); //starting stopwatch
            
            Console.WriteLine("Please add, up to what number do you want to see the prime numbers!");

            long value = Convert.ToInt64(Console.ReadLine());
            // splitting work to 10 pieces
            long value1 = value/10;
            long value2 = value1 * 2;
            long value3 = value1 * 3;
            long value4 = value1 * 4;
            long value5 = (value1 * 5);
            long value6 = (value1 * 6);
            long value7 = (value1 * 7);
            long value8 = (value1 * 8);
            long value9 = (value1 * 9);
            long value10 = (value1 * 10) + (value % 10);



            // creating 10 threads
            Thread thread1 = new Thread(() => addPrime(2, value1));    
            Thread thread2 = new Thread(() => addPrime(value1 + 1, value2)); 
            Thread thread3 = new Thread(() => addPrime(value2 + 1, value3));
            Thread thread4 = new Thread(() => addPrime(value3 + 1, value4));
            Thread thread5 = new Thread(() => addPrime(value4 + 1, value5));
            Thread thread6 = new Thread(() => addPrime(value5 + 1, value6));
            Thread thread7 = new Thread(() => addPrime(value6 + 1, value7));
            Thread thread8 = new Thread(() => addPrime(value7 + 1, value8));
            Thread thread9 = new Thread(() => addPrime(value8 + 1, value9));
            Thread thread10 = new Thread(() => addPrime(value9 + 1, value10));
            //starting threads
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();
            thread9.Start();
            thread10.Start();
            //waiting for threads to finish
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();
            thread6.Join();
            thread7.Join();
            thread8.Join();
            thread9.Join();
            thread10.Join();


            
            readData(data);
            stopwatch.Stop(); //finishing stopwatch to measure time (About 40 seconds faster than single thread)


            Console.WriteLine("\n\nTime Elapsed: " + stopwatch.Elapsed);
        }


    }

}

