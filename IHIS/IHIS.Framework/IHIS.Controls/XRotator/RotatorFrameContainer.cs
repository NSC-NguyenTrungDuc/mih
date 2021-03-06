using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace IHIS.Framework
{
	/// <summary>
	/// Defines the object displaying the rotator frames and their animation
	/// It has two references of a RotatorFrame object.Uses a buffering approach. the visible frame displays the current RotatorItemData data
	/// where as the second one holds the next collection element data. Once animation is done..they are swapped
	/// </summary>
	internal class RotatorFrameContainer : Panel
	{
		#region Delegates
		private delegate void NotificationEventCallback();
		private delegate void FrameTextAnimationFinishedCallback();
		#endregion

		#region Members

		/// <summary>
		/// Flag telling if the container is animating the two frames
		/// </summary>
		private bool animating = false;
		//<TEST>
		public bool Animating
		{
			get { return animating;}
		}

		/// <summary>
		/// The index of the current RotatorFrameItem being showed on the screen.
		/// </summary>
		private int currentIndex = -1;

		/// <summary>
		/// backup for the control width;used in resizing setting the frames postion
		/// </summary>
		private int backupWidth = 0;

		/// <summary>
		/// backup for the control height; used in resizing setting the frames postion
		/// </summary>
		private int backupHeight = 0;

		/// <summary>
		/// Size in pixels used to move the frames during their animation
		/// </summary>
		private int animationStep = 10;

		/// <summary>
		/// Defines the axis on which the two frames are being moved
		/// </summary>
		private XRotatorAxisMode axisMode = XRotatorAxisMode.YAxis;

		/// <summary>
		/// Collection of the Rotator Item data
		/// </summary>
		private XRotatorItemCollection items = null;

		/// <summary>
		/// Instance of a changing collection details
		/// </summary>
		private CollectionChangeArgs queuedChange = null;

		/// <summary>
		/// The first out of the two frames used
		/// </summary>
		private RotatorFrame firstFrame = null;

		/// <summary>
		/// Second rotator frame used
		/// </summary>
		private RotatorFrame secondFrame = null;

		/// <summary>
		/// Instance of the template holding the context for displaying the frames
		/// </summary>
		private RotatorFrameTemplate template = null;

		/// <summary>
		/// Notifier for the frame movement animation
		/// </summary>
		private EventNotifier frameAnimationNotifier = null;

		/// <summary>
		/// The callback for the notification event (thread safe access for the control)
		/// </summary>
		private NotificationEventCallback notificationHandler = null;

		/// <summary>
		/// the callback for the main text animation finished event 
		/// </summary>
		//private FrameTextAnimationFinishedCallback textAnimationFinishedHandler = null;

		#endregion

		#region ctor

		/// <summary>
		/// Implicit constructor
		/// </summary>
		protected RotatorFrameContainer()
		{
			this.SetStyle(  ControlStyles.AllPaintingInWmPaint |ControlStyles.UserPaint | ControlStyles.DoubleBuffer,true);
			UpdateStyles();

			this.BackColor = Color.Transparent;
			this.frameAnimationNotifier = new EventNotifier(150, new NotifierEvent(this.OnNotifierEvent));
			this.template = new RotatorFrameTemplate();

			this.notificationHandler = new NotificationEventCallback(this.HandleNotification);
		}

		/// <summary>
		/// explicit constructor
		/// </summary>
		/// <param name="collection">instance of the collection of rotatoritemdata objects</param>
		internal RotatorFrameContainer(XRotatorItemCollection collection)
			: this()
		{
			this.items = collection;
			//initilize the two frames
			InitializeComponents();
			InitializeData();
		}

		/// <summary>
		/// explicit constructor
		/// </summary>
		/// <param name="collection">instance of the collection of rotatoritemdata objects</param>
		/// <param name="template">the template used for the two frames</param>
		internal RotatorFrameContainer(XRotatorItemCollection collection, RotatorFrameTemplate template) : this()
		{
			this.items = collection;
			this.items.CollectionChanged += new RotatorItemCollectionChanged(OnItemsCollectionChanged);
			this.template = template;

			//initilize the two frames
			InitializeComponents();
			//link first frame with the first element in the data collction if necessary
			InitializeData();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Set/Get the delay in milliseconds for moving the frames
		/// </summary>
		internal int AnimationDelay
		{
			get
			{
				return this.frameAnimationNotifier.NotifyPeriod;
			}
			set
			{
				this.frameAnimationNotifier.NotifyPeriod = value;
			}
		}

		/// <summary>
		/// Get/Set the template used for the frames
		/// </summary>
		internal RotatorFrameTemplate Template
		{
			get
			{
				return this.template;
			}
			set
			{
				this.template = value;
				this.firstFrame.FrameTemplate = this.template;
				this.secondFrame.FrameTemplate = this.template;
			}
		}

		/// <summary>
		/// Set/Get the size in pixels used in moving the frames
		/// </summary>
		internal int AnimationStep
		{
			get
			{
				return this.animationStep;
			}
			set
			{
				this.animationStep = value;
			}
		}

		/// <summary>
		/// Get/Set the animation mode. it can be either X or Y axis
		/// </summary>
		internal XRotatorAxisMode AnimationMode
		{
			get
			{
				return this.axisMode;
			}
			set
			{
				if (animating)
				{
					throw new InvalidOperationException("Can't change animation mode while it is being rolling");
				}
				this.axisMode = value;
			}
		}
		#endregion

		#region Private

		private void StopEventNotifier()
		{
			frameAnimationNotifier.Stop();
		}

		/// <summary>
		/// Handles changes made to the collection of rotatoritemdata
		/// </summary>
		private void HandleItemsCollectionChanged()
		{
			//is there a change to the collection
			if (queuedChange != null)
			{
				switch (queuedChange.ChangeType)
				{
					case ChangeType.ItemAdded:
						if (queuedChange.Count == 1)
						{
							InitializeData();
							firstFrame.EnableTextAnimation = true;
						}
						break;

					case ChangeType.ItemsRemoved:
						firstFrame.Data = null;
						firstFrame.ResetText();
						firstFrame.EnableTextAnimation = false;
						firstFrame.Visible = false;


						secondFrame.Data = null;
						secondFrame.ResetText();
						secondFrame.EnableTextAnimation = false;
						secondFrame.Visible = false;

						SetFramesPosition();
						break;

					case ChangeType.ItemUpdate:
						if (currentIndex == queuedChange.Index)
						{
							firstFrame.Data = items[currentIndex];
						}
						break;

					case ChangeType.ItemRemoved:
						if (queuedChange.Count == 0)
						{
							firstFrame.Data = null;
							firstFrame.ResetText();
							firstFrame.EnableTextAnimation = false;
							firstFrame.Visible = false;


							secondFrame.Data = null;
							secondFrame.ResetText();
							secondFrame.EnableTextAnimation = false;
							secondFrame.Visible = false;

							SetFramesPosition();
						}
						else
						{
							if (currentIndex == queuedChange.Index)
							{
								BufferNextData(currentIndex);
								SwapRotatorFrames();
								BufferNextData(currentIndex + 1);
							}
						}
						break;
				}
				queuedChange = null;
			}
		}

		/// <summary>
		/// Tell the notifier to stop raising events
		/// </summary>
		internal void StopFrameAnimation()
		{
			//animation is stopped
			animating = false;
			//stop the background thread raising the notification events
			StopEventNotifier();
			//is there a change to the collection!?
			if (null == queuedChange)
			{
				//swap frames
				SwapRotatorFrames();
				//set the frames location
				SetFramesPosition();
				//repaint first frame 
				firstFrame.Refresh();
			}
			else 
			{
				//there is a change to the collection
				HandleItemsCollectionChanged();
			}
		}

		/// <summary>
		/// Swaps the two frames. first frames becomes second one and the second one becomes the first one
		/// </summary>
		private void SwapRotatorFrames()
		{
			//swap the references 
            
			RotatorFrame temp = this.firstFrame;
			firstFrame = secondFrame;
			secondFrame = temp;
			secondFrame.EnableTextAnimation = false;
			firstFrame.EnableTextAnimation = true;
			firstFrame.ResetAnimation();
		}

		/// <summary>
		/// Initializes the frames
		/// </summary>
		private void InitializeComponents()
		{ 
			this.SuspendLayout();
			firstFrame = new RotatorFrame(template);
			firstFrame.TabIndex = 0;
			firstFrame.Visible = false;
			firstFrame.Location = new Point(0, 0);
			//set the event handler for the text animation finished
			firstFrame.AnimationFinished += new RotatorFrameTextAnimationFinished(OnFrameAnimationFinished);
			this.Controls.Add(firstFrame);

			secondFrame = new RotatorFrame(template);
			secondFrame.TabIndex = 1;
			secondFrame.Visible = false;
			secondFrame.Location = new Point(0, 0);
			//set the event handler for the text animation finished
			secondFrame.AnimationFinished += new RotatorFrameTextAnimationFinished(OnFrameAnimationFinished);
            
			//secondFrame.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.Controls.Add(secondFrame);
			this.ResumeLayout(false);
		}

		/// <summary>
		/// Links the first item in the collection to the first frame
		/// </summary>
		private void InitializeData()
		{
			if (items != null && items.Count > 0)
			{
				currentIndex = 0;
				firstFrame.Data = items[0];
				firstFrame.Visible = true;

				/*if (items.Count > 1)
				{
					secondFrame.Data = items[1];
					secondFrame.Visible = true;
				}
				else
				{
					secondFrame.Data = items[0];
					secondFrame.Visible = true;
				}*/
			}
			else
			{
				currentIndex = -1;
			}
		}

		/// <summary>
		/// Links the second frame to the next element in the collection. if the index exceeds the collection count
		/// first element of the collection is being chosen
		/// </summary>
		/// <param name="index">the index within the collection</param>
		private void BufferNextData(int index)
		{
			//has the collection items being intialized?
			if (items != null)
			{
				//is there any item in the collection
				if (items.Count > 0)
				{
					if (index >= items.Count)
					{
						currentIndex = 0;
					}
					else
					{
						currentIndex = index;
					}
					secondFrame.Data = items[currentIndex];
					secondFrame.Visible = true;
				}
				else
				{
					//hide the frames, there is no point in showing any
					currentIndex = -1;
					firstFrame.Visible = false;
					secondFrame.Visible = false;
				}
			}
		}

		/// <summary>
		/// Set the frames location within the container
		/// </summary>
		private void SetFramesPosition()
		{
			if (axisMode == XRotatorAxisMode.YAxis)
			{
				int halfHeight = this.Height / 2;
				int quarterHeight = this.Height / 4;
				int temp = this.Height / 8;
				temp = temp - (Height - 8 * temp);
				firstFrame.Top = temp;// -backupTemp;

				if (animationStep >= 0)
				{
					secondFrame.Top = Height + temp;
				}
				else
				{
					secondFrame.Top = -(Height + temp);
					//fix roundings
					//secondFrame.Top = secondFrame.Top + (Height - 4 * quarterHeight);
				}

				//<IHIS> Size 변경
				//firstFrame.Size = new Size(this.Width, 3 * (quarterHeight - (Height - 4 * quarterHeight)));
				firstFrame.Size = new Size(this.Width, this.Height - 2*temp);
				secondFrame.Size = new Size(this.Width, this.Height - 2*temp);

			}
			else
			{
				int halfWidth = this.Width / 2;
				int quarterWidth = this.Width / 4;
				int quarterHeight = this.Height / 4;
				int halfHeight = this.Height / 2;
				int temp = this.Height / 8;
				temp = temp - (Height - 8 * temp);
				
				firstFrame.Top = firstFrame.Top - backupHeight / 8 + temp;
				secondFrame.Top = firstFrame.Top;
                

				firstFrame.Left = 0;
                
				if (animationStep >= 0)
				{
					secondFrame.Left = firstFrame.Left + Width + quarterWidth;
					//have to correct the roundings 
					secondFrame.Left = secondFrame.Left - (Width - secondFrame.Left);
				}
				else
				{
					secondFrame.Left = firstFrame.Left - Width - quarterWidth;
					//have to correct the roundings 
					secondFrame.Left = secondFrame.Left + (Width + secondFrame.Left);
				}
				//<IHIS> Size 변경
				firstFrame.Size = new Size(this.Width, this.Height - 2*temp);
				secondFrame.Size = new Size(this.Width, this.Height - 2*temp);

			}
		}

		#endregion

		#region Override

		protected override void Dispose(bool disposing)
		{
			StopEventNotifier();
			firstFrame.Dispose();
			secondFrame.Dispose();

			base.Dispose(disposing);
		}
		/// <summary>
		/// Overrides the resize event handler; the two frames have to be repositioned
		/// </summary>
		/// <param name="eventargs"></param>
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);

			//suppress layout events
			this.SuspendLayout();

			SetFramesPosition();

			this.ResumeLayout(false);
			//save width and height
			this.backupHeight = this.Height;
			this.backupWidth = this.Width;
		}
		#endregion

		#region Events
		/// <summary>
		/// Event raised whenever a frame text animation has ended
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnFrameAnimationFinished(object sender, EventArgs args)
		{
			if (!DesignMode)
			{
				BufferNextData(currentIndex + 1);
				//start moving the frames
				this.frameAnimationNotifier.Start();
				animating = true;
			}
		}

		/// <summary>
		/// Event raised by the notifier object whenever the frames needs moving
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnNotifierEvent(object sender, EventArgs args)
		{
			//make the control thread save. invoke a handler 
			this.Invoke(this.notificationHandler);
		}

		/// <summary>
		/// Handle for the event of changing the collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnItemsCollectionChanged(object sender, CollectionChangeArgs args)
		{
			//if animating store the change 
			if (animating)
			{
				if (null == queuedChange)
				{
					queuedChange = args;
				}
			}
			else
			{
				//if not animationg do the updates
				queuedChange = args;
				HandleItemsCollectionChanged();
			}
		}
		#endregion

		#region Callbacks

		/*
		internal void StartFrameAnimation()
		{ 
			OnFrameAnimationFinished(this, EventArgs.Empty);
		}
		*/

		/// <summary>
		/// Method called by the delegate to reposition the frames
		/// </summary>
		private void HandleNotification()
		{
			//move frames
			this.SuspendLayout();

			if (axisMode == XRotatorAxisMode.YAxis)
			{
				int landMark = Height / 8;
				landMark = landMark - (Height - 8 * landMark);
				if ((animationStep >= 0 && (secondFrame.Top  <= landMark))
					|| (animationStep < 0 && (secondFrame.Top >= landMark)))
				{

					StopFrameAnimation();
				}
				else
				{
					if (animationStep >= 0)
					{
						if (secondFrame.Top - animationStep <= landMark)
						{
							firstFrame.Top = landMark - Height;
							secondFrame.Top = landMark;
						}
						else
						{
							firstFrame.Top -= (int)animationStep;
							secondFrame.Top -= (int)animationStep;
						}
					}
					else
					{
						if (secondFrame.Top - animationStep >= landMark)
						{
							firstFrame.Top = landMark - Height;
							secondFrame.Top = landMark;
						}
						else
						{
							firstFrame.Top -= (int)animationStep;
							secondFrame.Top -= (int)animationStep;
						}
					}
				}
			}
			else
			{
				int landMark = Width / 4;
				landMark = landMark - (Width - 4 * landMark);
				if ((animationStep >= 0 && (secondFrame.Left - animationStep < 0))
					|| (animationStep < 0 && (secondFrame.Left - animationStep > 0)))
				{
					StopFrameAnimation();
				}
				else
				{
					firstFrame.Left -= (int)animationStep;
					secondFrame.Left -= (int)animationStep;
				}
			}
			this.ResumeLayout(false);
		}
		#endregion
	}
}
