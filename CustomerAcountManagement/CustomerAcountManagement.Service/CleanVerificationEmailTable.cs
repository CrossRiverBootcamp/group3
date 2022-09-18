using Microsoft.Extensions.Hosting;

namespace CustomerAcountManagement.Service;

public class CleanVerificationEmailTable : IHostedService
{
    private readonly IEmailVerificationService _emailVerificationService;
    private  Timer _timer;
    public CleanVerificationEmailTable(IEmailVerificationService emailVerificationService)
    {
        _emailVerificationService = emailVerificationService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
       
        _timer = new Timer(
               RemoveExpiringVerifications,
               null,
               TimeSpan.Zero,
               TimeSpan.FromMinutes(1)
           );

        return Task.CompletedTask;
    }

    /// Call the Stop async method if required from within the app.
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    private void RemoveExpiringVerifications(object state)
    {
        _emailVerificationService.CleanEmailVerificationTable();
    }
}

