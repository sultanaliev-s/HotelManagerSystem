using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HotelManagerSystem.BL.DbLogger
{
    [ProviderAlias("Database")]
    public class DbLoggerProvider : ILoggerProvider
    {
        public readonly DbLoggerOptions Options;
        private readonly IServiceScopeFactory _scopeFactory;
        public DbLoggerProvider(IOptions<DbLoggerOptions> _options, IServiceScopeFactory scopeFactory)
        {
            Options = _options.Value; // Stores all the options.  
            _scopeFactory = scopeFactory;
        }

        /// <summary>  
        /// Creates a new instance of the db logger.  
        /// </summary>  
        /// <param name="categoryName"></param>  
        /// <returns></returns>  
        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(this, _scopeFactory);
        }

        public void Dispose()
        {
        }
    }
}
