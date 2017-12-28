using System;
using IHIS.CloudConnector.Contracts.Arguments;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.CloudConnector.Caching
{
    public delegate TResult Function<TArg, TResult>(TArg arg)
        where TResult : IContractResult
        where TArg : class, IContractArgs;

    public delegate bool Func<TResult>(TResult result);

    /// <summary>
    /// Cache manager interface
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TResult">Type of Result</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        TResult Get<TResult>(string key);

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TArg">Type of Arg</typeparam>
        /// <typeparam name="TResult">Type of Result</typeparam>
        /// <param name="arg">The arg</param>
        /// <returns>The value associated with the specified key.</returns>
        TResult Get<TArg, TResult>(TArg arg)
            where TResult : IContractResult
            where TArg : class, IContractArgs;

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TArg">Type of Arg</typeparam>
        /// <typeparam name="TResult">Type of Result</typeparam>
        /// <param name="arg">The arg</param>
        /// <param name="cacheIfEmpty">Cache data even null or empty if true, otherwise ignore</param>
        /// <returns>The value associated with the specified key.</returns>
        TResult Get<TArg, TResult>(TArg arg, Func<TResult> cacheIfEmpty)
            where TResult : IContractResult
            where TArg : class, IContractArgs;

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TArg">Type of Arg</typeparam>
        /// <typeparam name="TResult">Type of Result</typeparam>
        /// <param name="acquire">The function which will be invoked if there is no data found in the cache.</param>
        /// <param name="arg">The arg</param>
        /// <returns>The value associated with the specified key.</returns>
        TResult Get<TArg, TResult>(Function<TArg, TResult> acquire, TArg arg)
            where TResult : IContractResult
            where TArg : class, IContractArgs;


        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TResult">Type of Result</typeparam>
        /// <typeparam name="TArg">Type of Arg</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="cacheTime">Cache time</param>
        /// <param name="acquire">The function which will be invoked if there is no data found in the cache</param>
        /// <param name="arg">The arg</param>
        /// <returns>The value associated with the specified key.</returns>
        TResult Get<TArg, TResult>(TimeSpan cacheTime, Function<TArg, TResult> acquire, TArg arg)
            where TResult : IContractResult
            where TArg : class, IContractArgs;

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        object Get(string key, object defaultValue);

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        void Set(string key, object data, TimeSpan cacheTime);

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        bool IsSet(string key);

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        void Remove(string key);

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// Clear all cache data
        /// </summary>
        void Clear();
    }
}