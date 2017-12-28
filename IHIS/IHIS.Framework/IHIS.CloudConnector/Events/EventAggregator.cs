using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Events
{
    class EventAggregator : IEventAggregator
    {
        private static readonly IEventAggregator instance = new EventAggregator();
        public static IEventAggregator Instance { get { return instance; } }

        private readonly Dictionary<Type, List<object>> _subscriptions = new Dictionary<Type, List<object>>();

        private EventAggregator()
        {
        }

        public void Publish<T>(T message) where T : IApplicationEvent
        {
            List<object> subscribers;
            if (_subscriptions.TryGetValue(typeof(T), out subscribers))
            {
                // To Array creates a copy in case someone unsubscribes in their own handler
                foreach (object subscriber in subscribers.ToArray())
                {
                    ((Action<T>)subscriber)(message);
                }
            }
            
        }

        public void Subscribe<T>(Action<T> action) where T : IApplicationEvent
        {
            List<object> subscribers;
            if(!_subscriptions.ContainsKey(typeof(T))) _subscriptions.Add(typeof(T), new List<object>());
            _subscriptions.TryGetValue(typeof(T), out subscribers);
            if (subscribers != null)
                lock (subscribers)
                {
                    subscribers.Add(action);
                }
        }

        public void Unsubscribe<T>(Action<T> action) where T : IApplicationEvent
        {
            List<object> subscribers;
            if (_subscriptions.TryGetValue(typeof(T), out subscribers))
            {
                lock (subscribers)
                {
                    subscribers.Remove(action);
                }
            }
        }

        public void Dispose()
        {
            _subscriptions.Clear();
        }
    }
}