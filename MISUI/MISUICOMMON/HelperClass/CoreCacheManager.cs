// ***********************************************************************
// Assembly         : Core.EnterpriseLibrary
// Author           : Ujjwal Mishra
// Created          : 09-23-2012
//
// Last Modified By : Ujjwal Mishra
// Last Modified On : 10-10-2012
// ***********************************************************************
// <copyright file="CoreCacheManager.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using MISUICOMMON.HelperClass;

namespace MISUICOMMON.HelperClass
{
    /// <summary>
    /// Class CoreCacheManager
    /// </summary>

    public class CoreCacheManager : EnterPriseCacheManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreCacheManager" /> class.
        /// </summary>
        public CoreCacheManager(){}
       
        /// <summary>
        /// Adds the item to cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public virtual void AddItemToCache(string key, string value)
        {
            try
            {
                var manager = GetCacheManager();
                if (manager != null) manager.Add(key, value);
            }
            catch (Exception ex)
            {
                //ex.Throw<CoreCacheManager>(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return GetCacheManager().Count;
            }
        }

        /// <summary>
        /// Adds the item to cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public virtual void AddItemToCache(string key, object value)
        {
            try
            {
                var manager = GetCacheManager();
                if (manager != null) manager.Add(key, value);
            }
            catch (Exception ex)
            {
               // ex.Throw<CoreCacheManager>(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// Gets the item from cache.
        /// </summary>
        /// <param name="name">The key of object in cache.</param>
        /// <returns>System.Object.</returns>
        public virtual object GetItemFromCache(string name)
        {
         object cacheString=null;
        try
        {
            var manager = GetCacheManager();
            cacheString = manager.GetData(name);
            
        }
        catch (Exception ex)
        {
            //ex.Throw<CoreCacheManager>(MethodBase.GetCurrentMethod().Name, ex);
        }
        return cacheString;
        }

        public virtual void DeleteFromCache(string name)
        {
            var manager = GetCacheManager();
            manager.Remove(name);
            
        }
        public bool  ContainsInCache(string name)
        {
            var manager = GetCacheManager();
            return manager.Contains(name);

        }
    }
}
