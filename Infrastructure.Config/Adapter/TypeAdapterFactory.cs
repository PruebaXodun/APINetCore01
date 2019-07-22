using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Config.Adapter
{
    public static class TypeAdapterFactory
    {
        static ITypeAdapterFactory currentTypeAdapterFactory = null;

        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            currentTypeAdapterFactory = adapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return currentTypeAdapterFactory.Create();
        }
    }
}
