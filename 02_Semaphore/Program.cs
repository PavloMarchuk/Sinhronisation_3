using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_Semaphore
	{
	class Program
		{
		static void Main(string[] args)
			{
			Semaphore s = new Semaphore(3,3, "My_Semaphore");
			Thread[] threads = new Thread[6];

			for(int i = 0; i < threads.Length; i++)
				{
				threads[i] = new Thread(SomeMethod);
				threads[i].Start(s);
				}

			}
		static void SomeMethod(object obj)
			{
			Semaphore s = obj as Semaphore;
			bool stop = false;

			while(!stop)
				{
				if(s.WaitOne(500))
					{
					try
						{
						Console.WriteLine("\t\t\tПоток {0} блокування отримав", Thread.CurrentThread.ManagedThreadId);
						Thread.Sleep(2000);
						}
					finally
						{
						stop = true;
						s.Release();
						Console.WriteLine("Поток {0} блокування зняв", Thread.CurrentThread.ManagedThreadId);
						}
					}
				else
					{
					Console.WriteLine("Таймаут для потока {0}, повтоне чекання",Thread.CurrentThread.ManagedThreadId);
					}
				}
			}
			 
		}
	}
