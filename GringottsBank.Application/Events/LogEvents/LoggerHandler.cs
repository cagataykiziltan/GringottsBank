using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GringottsBank.Application.TransactionEvents
{
    class LoggerHandler : INotificationHandler<LogEvent>
    {
        private readonly ILogger<LoggerHandler> _logger;

        public LoggerHandler(ILogger<LoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(LogEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New customer has been created at ");

            return Task.CompletedTask;
        }


    }
}
