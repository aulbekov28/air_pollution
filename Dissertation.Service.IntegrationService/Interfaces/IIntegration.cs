namespace Dissertation.Service.IntegrationService
{
    public interface IIntegration
    {
        void StartCycle();
        void StopCycle();
        void MainCycle(object sender, System.Timers.ElapsedEventArgs e);
    }
}