// Copyright (c) Russlan Akiev. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityBase.Twilio
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using ServiceBase.Notification.Sms;
    using ServiceBase.Notification.Twilio;
    using ServiceBase.Plugins;

    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public void Execute(IServiceCollection services)
        {
            IServiceProvider serviceProvider = services
                .BuildServiceProvider();

            IConfiguration configuration = serviceProvider
                .GetService<IConfiguration>();

            services.AddScoped<ISmsService, DefaultSmsService>();

            services.AddSingleton(configuration
                .GetSection("Sms").Get<DefaultSmsServiceOptions>());

            services.AddScoped<ISmsSender, TwilioSmsSender>();

            services.AddSingleton(configuration
                .GetSection("Sms:Twilio").Get<TwilioOptions>());
        }
    }
}
