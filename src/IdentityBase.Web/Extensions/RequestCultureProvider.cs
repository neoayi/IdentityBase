// Copyright (c) Russlan Akiev. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityBase
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using IdentityBase.Configuration;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Primitives;

    public class RequestCultureProvider : IRequestCultureProvider
    {
        public Task<ProviderCultureResult>
            DetermineProviderCultureResult(HttpContext httpContext)
        {
            IdentityBaseContext idbContext =
                httpContext.RequestServices
                    .GetService<IdentityBaseContext>();

            ApplicationOptions appOptions =
                httpContext.RequestServices
                    .GetService<ApplicationOptions>();

            if (idbContext.IsValid)
            {
                string culture = httpContext.Request.Query["culture"];

                if (String.IsNullOrWhiteSpace(culture) &&
                    idbContext.AuthorizationRequest != null)
                {
                    culture = idbContext
                        .AuthorizationRequest
                        .Parameters?
                        .GetValues("culture")?
                        .FirstOrDefault();
                }

                // TODO: Get all client supported cultures

                if (String.IsNullOrWhiteSpace(culture))
                {
                    // TODO: Replace by client overrides for application options
                    culture = idbContext.ClientProperties.Culture ??
                        appOptions.DefaultCulture;
                }
                else
                {
                    return Task.FromResult(
                        new ProviderCultureResult(new StringSegment(culture)));
                }
            }

            return Task.FromResult<ProviderCultureResult>(null);
        }
    }
}
