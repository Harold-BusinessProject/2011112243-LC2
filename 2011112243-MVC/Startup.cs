﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2011112243.MVC.Startup))]
namespace _2011112243.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
