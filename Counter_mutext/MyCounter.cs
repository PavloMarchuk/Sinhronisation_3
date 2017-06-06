using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_mutext
	{
	public class MyCounter
		{
		int count;
		object obj = new object();

		public int Count
			{
			get { return count; }
			}

		public void UpdateFields()
			{
			
				for(int i = 0; i < 1000000; ++i)
				{
				lock (obj)
					++count;					
				}
			}
		}

	}
