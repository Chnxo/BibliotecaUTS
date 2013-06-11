using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SS.Caching
{
    public interface ICacheHelper
    {
        //TimeSpan DefaultExpiration { get; }

        /// <summary>
        /// Adds the specified o.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o">The o.</param>
        /// <param name="key">The key.</param>
        /// <remarks></remarks>
        void Add<T>(string key, T o);

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="key">The key.</param>
        /// <param name="expiration">The expiration.</param>
        /// <remarks></remarks>
        void Add<T>(string key, T item, TimeSpan expiration);

        /// <summary>
        /// Removes the item with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <remarks></remarks>
        void Remove(string key);

        /// <summary>
        /// Existses the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool Exists(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool Get<T>(string key, out T value);

        T Get<T>(string key, Func<T> factory);

        T Get<T>(string key, Func<T> factory, TimeSpan expiration);

        /// <summary>
        /// Clears the cache.
        /// </summary>
        void Clear();
    }
}