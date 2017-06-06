using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01__Mutext
	{
	class Program
		{
		static Mutex mutex;
		static void Main(string[] args)
			{
			try
				{
				mutex = Mutex.OpenExisting("MY_MUTEXT");
				}
			catch(Exception e)
				{
				Console.WriteLine(e.Message);				
				}
			if(mutex != null)
				{
				Console.WriteLine("Вже чогось працює");
				Console.ReadKey();
				return;
				}

			// Мютекс запкскає гарантовано один екземпляр
			using(var mutex = new Mutex(true, "MY_MUTEXT"))
				{
				Console.WriteLine("mutex працює");
				Console.ReadKey();
				}

			}
		}
	}
