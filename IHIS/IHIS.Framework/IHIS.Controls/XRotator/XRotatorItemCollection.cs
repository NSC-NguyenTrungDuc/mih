using System;
using System.Collections;


namespace IHIS.Framework
{
	#region enum
    /// <summary>
    /// Defines to delegate used to notify the collection has changed adding,removing or updating item.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    internal delegate void RotatorItemCollectionChanged(object sender, CollectionChangeArgs args);

    /// <summary>
    /// Collection change enumeration
    /// </summary>
    internal enum ChangeType { Empty = 0, ItemAdded = 1, ItemRemoved = 2, ItemsRemoved = 3, ItemUpdate =4 };
	#endregion

	#region CollectionChangeArgs
    /// <summary>
    /// Defines the object that holds the information regarding a collection change
    /// </summary>
    internal class CollectionChangeArgs : EventArgs
    {       
        #region Fields
        private int index = -1;
        private int count = 0;
        private ChangeType changeType = ChangeType.Empty;
        #endregion

		#region Contructor
        internal CollectionChangeArgs(int index, int count,ChangeType changeType)
        {
            this.index = index;
            this.count = count;
            this.changeType = changeType;
        }
        #endregion

        #region Properties
        internal int Index
        {
            get { return index; }
            set { index = value; }
        }
        internal int Count
        {
            get { return count; }
            set { count = value; }
        }
        internal ChangeType ChangeType
        {
            get { return changeType; }
            set { changeType = value; }
        }
        #endregion
    }
	#endregion

    /// <summary>
    /// Defines the collection of XRotatorItems
    /// </summary>
    public class XRotatorItemCollection :  System.Collections.CollectionBase
    {
        #region Members

        /// <summary>
        /// dummy object used for synchronizing the
        /// </summary>
        private object syncRoot = new object();

        /// <summary>
        /// the delegate to be called whenever the collection has changed
        /// </summary>
        internal event RotatorItemCollectionChanged CollectionChanged = null;

        #endregion

        #region New SyncImplementation

        public new  int Count
        {
            get
            {
                lock (this.syncRoot)
                {
                    return base.Count;
                }
            }
        }

        public void Add(XRotatorItem item)
        {
            lock (this.syncRoot)
            {
                List.Add(item);
                if (null != CollectionChanged)
                {
                    CollectionChanged(this, new CollectionChangeArgs(base.Count - 1, base.Count, ChangeType.ItemAdded));
                }
            }
        }

        public XRotatorItem this[int index]
        {
            get
            {
                lock (syncRoot)
                {
					if (index > Count - 1 || index < 0)
						return null;
                    return (XRotatorItem) List[index];
                }
            }
			/*
            set
            {
                lock (syncRoot)
                {
                    this[index] = value;
                }
                if (null != CollectionChanged)
                {
                    CollectionChanged(this, new CollectionChangeArgs(base.Count - 1, base.Count, ChangeType.ItemUpdate));
                }
            }
			*/
        }

        public void AddRange(XRotatorItem[] items)
        {
            lock (this.syncRoot)
            {
				List.Clear();
				foreach (XRotatorItem item in items)
				{
					Add(item);
				}
            }
        }
        public new void Clear()
        {
            lock (this.syncRoot)
            {
                List.Clear();
                if (null != CollectionChanged)
                {
                    CollectionChanged(this, new CollectionChangeArgs(-1, 0, ChangeType.ItemsRemoved));
                }
            }
        }

        public bool Contains(XRotatorItem item)
        {
            lock (this.syncRoot)
            {
                return List.Contains(item);
            }
        }

        private void Remove(XRotatorItem item)
        {
            lock (this.syncRoot)
            {
                List.Remove(item);
                
            }
        }
        #endregion

    }
}
