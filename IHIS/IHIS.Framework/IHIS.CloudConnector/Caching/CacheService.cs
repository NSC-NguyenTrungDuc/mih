using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Iesi.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments;
using IHIS.CloudConnector.Contracts.Results;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System.Runtime.Serialization;
using IHIS.Framework;

namespace IHIS.CloudConnector.Caching
{
    public class CacheService : ICacheService
    {
        private const string CACHE_GLOBAL_KEYS = "CACHE_GLOBAL_KEYS";
        private SynchronizedSet<string> _keys;
        private CacheManager _cacheManager;
        private static readonly CacheService _instance = new CacheService();

        public static ICacheService Instance
        {
            get { return _instance; }
        }

        private CacheService()
        {
            try
            {
                //MED-10082 Only remove default cache when change revesion
                //string appDomain = "";
                //if (AppDomain.CurrentDomain != null && !AppDomain.CurrentDomain.FriendlyName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                //{
                //    appDomain = AppDomain.CurrentDomain.FriendlyName;
                //}

                //Logs.StartWriteLog();
                //Logs.WriteLog("[APP DOMAIN]: " + appDomain);
                //Logs.EndWriteLog();

                //if (!string.IsNullOrEmpty(appDomain))
                //{
                //    // Domain partition
                //    _cacheManager = CacheFactory.GetCacheManager(appDomain);
                //}
                //else
                //{
                //    // Default partition
                //    _cacheManager = CacheFactory.GetCacheManager();
                //}

                _cacheManager = CacheFactory.GetCacheManager();
                if (!_cacheManager.Contains(CACHE_GLOBAL_KEYS))
                {
                    _cacheManager.Add(CACHE_GLOBAL_KEYS, new SynchronizedSet<string>(new HashedSet<string>()));
                }
                _keys = (SynchronizedSet<string>)_cacheManager.GetData(CACHE_GLOBAL_KEYS);
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("Init CacheService error. Message: " + ex.Message);
                Logs.WriteLog("At: " + ex.StackTrace);
                Logs.EndWriteLog();
            }
        }

        public TResult Get<TResult>(string key)
        {
            return (TResult)_cacheManager.GetData(key);
        }

        public TResult Get<TArg, TResult>(TArg arg)
            where TResult : IContractResult
            where TArg : class, IContractArgs
        {
            return Get((Function<TArg, TResult>)null, arg);
        }

        public TResult Get<TArg, TResult>(TArg arg, Func<TResult> cacheIfEmpty)
            where TArg : class, IContractArgs
            where TResult : IContractResult
        {
            return Get<TArg, TResult>(TimeSpan.MaxValue, (Function<TArg, TResult>) null, arg, cacheIfEmpty);
        }

        public TResult Get<TArg, TResult>(Function<TArg, TResult> acquire, TArg arg)
            where TResult : IContractResult
            where TArg : class, IContractArgs
        {
            return Get(TimeSpan.MaxValue, acquire, arg);
        }

        public TResult Get<TArg, TResult>(TimeSpan cacheTime, Function<TArg, TResult> acquire, TArg arg)
            where TResult : IContractResult
            where TArg : class, IContractArgs
        {
            return Get<TArg, TResult>(cacheTime, acquire, arg, null);
        }

        public TResult Get<TArg, TResult>(TimeSpan cacheTime, Function<TArg, TResult> acquire, TArg arg, Func<TResult> cacheIfEmpty)
            where TResult : IContractResult
            where TArg : class, IContractArgs
        {
            string requestKey = string.Format("{0}-{1}", UserInfo.HospCode, arg.GetType().Name);
            Dictionary<TArg, TResult> dictionary = _cacheManager.Contains(requestKey) ? (Dictionary<TArg, TResult>)_cacheManager.GetData(requestKey) : new Dictionary<TArg, TResult>();
            if (dictionary.ContainsKey(arg))
            {
                return (TResult)dictionary[arg];
            }
            TResult result = acquire != null ? acquire(arg) : CloudService.Instance.Submit<TResult, TArg>(arg);
            if (result.ExecutionStatus == ExecutionStatus.Success && (cacheIfEmpty == null || cacheIfEmpty(result)))
            {
                dictionary.Add(arg, result);
                Set(requestKey, dictionary, cacheTime);
            }
            return result;
        }

        public object Get(string key, object defaultValue)
        {
            object result = defaultValue;
            if (_cacheManager.Contains(key))
            {
                result = _cacheManager.GetData(key);
            }
            return result;
        }

        public void Set(string key, object data, TimeSpan cacheTime)
        {
            try
            {
                if (data == null)
                    return;

                ICacheItemExpiration itemExpiration = new NeverExpired();
                if (!cacheTime.Equals(TimeSpan.MaxValue))
                {
                    itemExpiration = new AbsoluteTime(cacheTime);
                }
                _cacheManager.Add(key, data, CacheItemPriority.Normal, null, itemExpiration);
                if (!_keys.Contains(key))
                {
                    _keys.Add(key);
                    _cacheManager.Add(CACHE_GLOBAL_KEYS, _keys, CacheItemPriority.NotRemovable, null, new NeverExpired());
                }
            }
            catch (Exception ex)
            {
                Logs.ErrWriteLog(string.Format("Message: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }

        public bool IsSet(string key)
        {
            return _cacheManager.Contains(key);
        }

        public void Remove(string key)
        {
            try
            {
                _keys.Remove(key);
                _cacheManager.Add(CACHE_GLOBAL_KEYS, _keys, CacheItemPriority.NotRemovable, null, new NeverExpired());
                _cacheManager.Remove(key);
            }
            catch (Exception ex)
            {
                Logs.ErrWriteLog(string.Format("Message: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }

        public void RemoveByPattern(string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            IList<String> keysToRemove = new List<String>();

            foreach (string item in _keys)
                if (regex.IsMatch(item))
                    keysToRemove.Add(item);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            _cacheManager.Flush();
        }
    }
}