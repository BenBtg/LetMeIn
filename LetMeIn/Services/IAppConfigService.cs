using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetMeIn.Services
{
    interface IAppConfigService
    {
        Task<bool> LoadAsync();
        Task<bool> SaveAsync();

        AppConfig AppConfig { get; }

    }

    public class AppConfig
    {
    }
}
