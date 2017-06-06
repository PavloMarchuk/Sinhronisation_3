using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Counter_mutext
	{
	class MutextCounter
		{
		int count;
		Mutex  m=  new Mutex(false, "MY_MUTEXT");

		public int Count
			{
			get { return count; }
			}

		public void UpdateFields()
			{

			for(int i = 0; i < 1000000; ++i)
				{
				//lock(obj)
				m.WaitOne();
				++count;
				m.ReleaseMutex();
				}
			}
		}
	}
