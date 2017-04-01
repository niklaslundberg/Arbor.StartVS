using System;
using System.Collections.Immutable;
using JetBrains.Annotations;

namespace StartVS
{
    public class VSConfiguration
    {
        public VSConfiguration([NotNull] string visualStudioExePath, ImmutableArray<EnvironmentVariable> environmentVariables)
        {
            if (string.IsNullOrWhiteSpace(visualStudioExePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(visualStudioExePath));

            VisualStudioExePath = visualStudioExePath;
            EnvironmentVariables = environmentVariables;
        }

        [NotNull]
        public string VisualStudioExePath { get; }

        public ImmutableArray<EnvironmentVariable> EnvironmentVariables { get; }

    }
}