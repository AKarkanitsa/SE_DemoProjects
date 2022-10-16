using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDelegate
{
	// class  Publisher
	public class Process
	{
		// declaring an event using built-in EventHandler
		// No need to declare custom delegate
		public event EventHandler<bool> ProcessCompleted;
		public void StartProcess()	
		{
			// some code here
			bool success = true; // change it to false and run again
			OnProcessCompleted(success);
		}
		protected virtual void OnProcessCompleted(bool isSuccessful)
		{
			ProcessCompleted?.Invoke(this, isSuccessful); // raise an event
		}
	}

	// class  Subscriber
	public class Program
	{
		static void MainX()
		{
			Process reading = new Process();
			//register with an event
			reading.ProcessCompleted += ProcessEventHandler;
			reading.StartProcess();
		}
		// event handler
		static void ProcessEventHandler(object sender, bool isSuccessful)
		{
			Console.WriteLine("Process " + (isSuccessful ? "Completed Successfully" : "failed"));
		}
	}
}
