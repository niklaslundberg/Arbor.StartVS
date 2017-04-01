using System;
using System.Collections.Immutable;
using Arbor.KVConfiguration.Core;
using Arbor.KVConfiguration.Urns;
using JetBrains.Annotations;

namespace StartVS
{
    public static class VSConfigurationBuilder
    {
        public static VSConfiguration Build([NotNull] IKeyValueConfiguration keyValueConfiguration)
        {
            if (keyValueConfiguration == null) throw new ArgumentNullException(nameof(keyValueConfiguration));

            var visualStudioExePath = keyValueConfiguration[ConfigurationKeys.VisualStudioExePath];

            ImmutableArray<EnvironmentVariable> environmentVariables = keyValueConfiguration.GetInstances<EnvironmentVariable>().ToImmutableArray();

            return new VSConfiguration(visualStudioExePath, environmentVariables);
        }
    }
}