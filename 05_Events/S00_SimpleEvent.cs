using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEvent
{
	public delegate void Notify(string message);
	// class  Publisher
	public class Process
	{
		public event Notify ProcessCompleted;
		public void StartProcess()
		{
			// some code here
			bool sucsess = true; // change it to false and run again
			if (sucsess) OnProcessCompleted("Process Completed.");
			else OnProcessCompleted("Something went wrong");
		}
		protected virtual void OnProcessCompleted(string message)
		{
			ProcessCompleted?.Invoke(message); // raise an event
		}
	}

	// class  Subscriber
	public class Program
	{
		static void Main()
		{
			Process reading = new Process();
			//register with an event
			reading.ProcessCompleted += ProcessEventHandler;
			reading.StartProcess();
		}
		// event handler
		static void ProcessEventHandler(string message)
		{
			Console.WriteLine(message);
		}
	}

}
