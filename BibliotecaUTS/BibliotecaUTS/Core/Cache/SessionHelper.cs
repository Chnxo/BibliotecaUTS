using System;
using System.Web;
using System.Web.SessionState;

namespace SS.Caching
{
    public class SessionHelper : ICacheHelper
    {
        private readonly HttpSessionState _session;

        public TimeSpan DefaultExpiration { get { return TimeSpan.MaxValue; } }

        public SessionHelper() :
            this(HttpContext.Current)
        {
        }

        public SessionHelper(HttpSessionState session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            _session = session;
        }

        public SessionHelper(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (context.Session == null)
            {
                //TODO: Check why session is null.
            }
            _session = context.Session;
        }

        public void Add<T>(string key, T o)
        {
            if (Exists(key))
            {
                _session[key] = o;
            }
            else
            {
                _session.Add(key, o);
            }
        }

        public void Add<T>(string key, T o, TimeSpan expiration)
        {
            // Expiration not supported.
            Add(key, o);
        }

        public void Remove(string key)
        {
            _session.Remove(key);
        }

        public void Clear()
        {
            _session.Clear();
            _session.Abandon();
        }

        public bool Exists(string key)
        {
            return _session != null && _session[key] != null;
        }

        public bool Get<T>(string key, out T value)
        {
            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }

                value = (T)_session[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }

        public T Get<T>(string key, Func<T> factory)
        {
            return Get(key, factory, DefaultExpiration);
        }

        public T Get<T>(string key, Func<T> factory, TimeSpan expiration)
        {
            T value;
            if (!Get(key, out value))
            {
                value = factory();
                Add(key, value, expiration);
            }
            return value;
        }
    }
}