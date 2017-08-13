using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS.ServiceDesk.BusinessObjects.EF
{
    //public class Configuration: DbConfiguration
    //{
    //    public Configuration()
    //    {
    //        var useRedis = false;
    //        bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["UseRedisCache"], out useRedis);
    //        if (!useRedis) return;

    //        var cache = new EFCache.Redis.RedisCache(System.Configuration.ConfigurationManager.AppSettings["RedisConnectionString"]);

    //        var transactionHandler = new CacheTransactionHandler(cache);
    //        AddInterceptor(transactionHandler);

    //        Loaded += (sender, args) => args.ReplaceService<DbProviderServices>((s,_) => new CachingProviderServices(s,transactionHandler, new RedisCachingPolicy() ));
    //    }
    //}
}
