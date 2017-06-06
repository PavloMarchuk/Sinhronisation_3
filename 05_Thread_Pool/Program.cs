using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Thread_Pool
	{
	class Program
		{
		static void Main(string[] args)
			{
			Console.OutputEncoding = new UTF8Encoding();
			int nWorkerThreads;
			int nCompletionThread;
			ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionThread);

			Console.WriteLine($"Максимальна кількість потоків ={nWorkerThreads} \tпотоків ввода-вивода = {nCompletionThread}");

			for(int i = 0; i < 5; i++)
				{
				ThreadPool.QueueUserWorkItem(JobForItem, i);
				Thread.Sleep(1000);
				}
			}

		static void JobForItem(object state)
			{

			Console.WriteLine($"=======================Thread number {state}");
			for(int i = 0; i < 3; i++)
				{
				Console.WriteLine($"Цикл {i}, всередині потоку {Thread.CurrentThread.ManagedThreadId}");
				Thread.Sleep(50);
				}
			}
		}
	}
