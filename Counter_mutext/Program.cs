using Counter_mutext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Counter_mutext
	{
	class Program
		{
		static void Main(string[] args)
			{
			//MyCounter
			MyCounter counter = new MyCounter();
			DateTime ds = DateTime.Now;

  			
			Thread[] tread = new Thread[5];

			for(int i = 0; i < 5; i++)
				{				
					tread[i] = new Thread(counter.UpdateFields);				
					tread[i].Start();					
				}

			for(int i = 0; i < 5; i++)
				{
				tread[i].Join();
				}
			Console.WriteLine($"Value {counter.Count}");
			TimeSpan span = DateTime.Now - ds;
			Console.WriteLine( $"{span.Seconds} sek {span.Milliseconds} milisek");
			}
		}
	}
