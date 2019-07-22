using AutoMapper;
using Infrastructure.Crosscutting.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Crosscutting.AutoMapper
{
    public class AutomapperTypeAdapterFactory
         : ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            var profiles = Assembly.Load("Application").GetTypes().Where(t => t.BaseType == typeof(Profile));

            //scan all assemblies finding Automapper Profile
            //var profiles = AppDomain.CurrentDomain
            //                        .GetAssemblies()
            //                        .SelectMany(a => a.GetTypes())
            //                        .Where(t => t.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                }
            });
        }

        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}
