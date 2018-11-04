using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.AzureStorage.Samples.Lib
{
    public interface ICommand
    {
        Task Run(IDictionary<string, object> parameters);
    }
}
