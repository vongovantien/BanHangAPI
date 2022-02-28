
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppicationBlazor.Services
{
    public interface ITaskApiClient
    {
        Task<IAsyncResult> getAll();
    }
}
