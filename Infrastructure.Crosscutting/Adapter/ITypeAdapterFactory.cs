using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Crosscutting.Adapter
{
    public interface ITypeAdapterFactory
    {
        /// <summary>
        /// Create a type adater
        /// </summary>
        /// <returns>The created ITypeAdapter</returns>
        ITypeAdapter Create();
    }
}
