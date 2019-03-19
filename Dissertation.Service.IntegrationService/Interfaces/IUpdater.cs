using System.Collections.Generic;

namespace Dissertation.Service.IntegrationService
{
    public interface IUpdater<T>
    {
        void Execute();
        IEnumerable<T> GetData();
        void WriteData(IEnumerable<T> obtainedData);
    }
}