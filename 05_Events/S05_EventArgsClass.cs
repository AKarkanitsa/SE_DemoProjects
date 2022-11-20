using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingDataToSubscriber
{
    // Custom EventArgs Class
    public class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }

	// class  Publisher
	public class Process
	{
		// declaring an event using built-in EventHandler
		// No need to declare custom delegate
		public event EventHandler<ProcessEventArgs> ProcessCompleted;
		public void StartProcess()
		{
			var eventData = new ProcessEventArgs();
			// some code here
			eventData.IsSuccessful = false; // change it to false and run again
			eventData.CompletionTime = DateTime.Now;
			OnProcessCompleted(eventData);
		}
		protected virtual void OnProcessCompleted(ProcessEventArgs e)
		{
			ProcessCompleted?.Invoke(this, e); // raise an event
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
		static void ProcessEventHandler(object sender, ProcessEventArgs e)
		{
			Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "failed"));
			Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongTimeString());
		}
	}
}
