using System;
using System.Threading;
using System.Diagnostics;

namespace IHIS.Framework
{
	/// <summary>
	/// Define the delegate for the notification 
	/// </summary>
	internal delegate void NotifierEvent(object sender, EventArgs args);

	/// <summary>
	/// UDT used to raise notification events every X milliseconds
	/// </summary>
	internal sealed class EventNotifier
	{
		#region Members
		private object sync = new object();

		/// <summary>
		/// pause the notifier flag
		/// </summary>
		private volatile bool pause = false;

		/// <summary>
		///the period to wait until a new event is being raised 
		/// </summary>
		private int notifyingPeriod = 150;

		/// <summary>
		/// THe worker thread 
		/// </summary>
		private Thread thread = null;

		/// <summary>
		/// a wait handle used in starting the worker thread
		/// </summary>
		private ManualResetEvent threadStart = new ManualResetEvent(false);
		private  ManualResetEvent threadStop = new ManualResetEvent(false);

		/// <summary>
		/// The delegate to be called whenever the notification is ready
		/// </summary>
		private event NotifierEvent NotifyEvent = null;
		#endregion

		#region 생성자
		public EventNotifier(int notifyingPeriod, NotifierEvent handlerNotifier)
		{
			this.notifyingPeriod = notifyingPeriod;
			if (null == handlerNotifier)
			{
				throw new ArgumentException("Must provide a handler for the notifier event");
			}
			this.NotifyEvent += handlerNotifier;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get/Set time in milliseconds for raising the notification
		/// </summary>
		public int NotifyPeriod
		{
			get { return notifyingPeriod;}
			set { notifyingPeriod = value;}
		}

		/// <summary>
		/// Get/Set whether to pause the notifier
		/// </summary>
		public bool Pause
		{
			get
			{
				lock (sync)
				{
					return pause;
				}
			}
			set
			{
				lock (sync)
				{
					pause = value;
				}
			}
		}
		#endregion

		#region Public
		/// <summary>
		/// Start the notification process.
		/// </summary>
		internal void Start()
		{
			//create the working thread
			threadStart.Reset();
			threadStop.Reset();
			Pause = false;
            
			thread = new Thread(new ThreadStart(ProcessingMethod));
			thread.IsBackground = true;
			thread.Start();
			//wait until the thread has actually started
			threadStart.WaitOne();
		}

		/// <summary>
		/// Stops the notifier raising the events
		/// </summary>
		/// <param name="joining"></param>
		internal void Stop( )
		{
			if (null != thread)
			{
				lock (this)
				{
                    
					Pause = true;
					threadStop.Set();
					thread = null;
				}
			}
		}

		#endregion

		#region Private
        
		/// <summary>
		/// The method run by the background thread
		/// </summary>
		private void ProcessingMethod()
		{
			threadStart.Set();

			while (!threadStop.WaitOne(0, true))
			{
				try
				{
					Thread.Sleep(notifyingPeriod);

					if (!Pause)
					{
						NotifyEvent(this, EventArgs.Empty);
					}
				}
				catch (Exception e)
				{
					Debug.WriteLine("ProcessingMethod Error=" + e.Message);
				}
			}
			//threadStart.Set();
		}
		#endregion
        
		#region IDisposable Members 
		/// <summary>
		/// Disposing the object
		/// </summary>
		~EventNotifier()
		{
			if (null != thread)
			{
				lock (this)
				{
					Pause = true;
					threadStop.Set();
				}
			}
		}
		#endregion
	}
}
