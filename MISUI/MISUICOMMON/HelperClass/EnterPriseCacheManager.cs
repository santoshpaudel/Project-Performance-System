// ***********************************************************************
// Assembly         : 
// Author           : Ujjwal Mishra
// Created          : 10-08-2012
//
// Last Modified By : Ujjwal Mishra
// Last Modified On : 10-08-2012
// ***********************************************************************
// <copyright file="CryptoHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace MISUICOMMON.HelperClass
{
    public class EnterPriseCacheManager
    {
        public  CacheManager GetCacheManager()
        {
            CacheManager objCacheManager = null;
            try
            {
                objCacheManager = (CacheManager)CacheFactory.GetCacheManager();

            }
            catch (Exception ex)
            {
                //ex.Throw<CacheManagerAbstract>(MethodBase.GetCurrentMethod().Name, ex);
            }
            return objCacheManager;
        }

        /// <summary>
        /// Gets the cache manager from config file according to the Name provided
        /// </summary>
        /// <param name="name">cache manager</param>
        /// <returns></returns>
        public CacheManager GetCacheManager(string name)
        {
            CacheManager objCacheManager = null;
            try
            {
                objCacheManager = (CacheManager)CacheFactory.GetCacheManager(name);
            }
            catch (Exception ex)
            {
                
            }
            return objCacheManager;
        }
    }
}
