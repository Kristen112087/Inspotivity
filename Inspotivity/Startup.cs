﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inspotivity.Startup))]
namespace Inspotivity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
