﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This interface is implemented by factories of rule configurations
    /// </summary>
    public interface IRuleConfigurationFactory
    {
        /// <summary>
        /// Gets the configuration for the specified rule type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The configuration</returns>
        IRuleConfiguration Get(Type type);
    }
}
