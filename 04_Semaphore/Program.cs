using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Semaphore
	{
	class Program
		{
		private static Semaphore pool;
		private static void Work(object number)
			{
			pool.WaitOne();
			Console.WriteLine($"Поток {number} зайняв слот симафора");

			Thread.Sleep(1000);
			Console.WriteLine($"\t\t\tПоток {number} ЗВІЛЬНИВ слот симафора");
			pool.Release();
			}

		static void Main(string[] args)
			{
			Console.OutputEncoding = new UTF8Encoding();
			pool = new Semaphore(2, 4, "My_Sem");

			for(int i = 0; i < 8; i++)
				{
				Thread thread = new Thread(Work);
				thread.Start(thread.ManagedThreadId);
				
				}
				Thread.Sleep(2000);
				pool.Release(2);
				
			}
		}
	}
