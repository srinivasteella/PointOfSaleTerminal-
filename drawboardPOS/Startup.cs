using System;
using System.Collections.Generic;
using System.Text;
using drawboardPOS.Services;
using Microsoft.Extensions.DependencyInjection;

namespace drawboardPOS
{
    class Startup
    {
        internal static IService Init()
        {
            var ServiceProvider = new ServiceCollection()
                                 .AddTransient<IScanService, ScanService>()
                                 .AddTransient<IPriceService, PriceService>()
                                 .AddTransient<ITotalCalculatorService, TotalCalculatorService>()
                                 .AddTransient<ICalculationService, CalculationService>()
                                 .AddTransient<IService, Service>()
                                 .BuildServiceProvider().GetService<IService>();
            return ServiceProvider;
        }
    }
}
