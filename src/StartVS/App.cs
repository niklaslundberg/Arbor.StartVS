using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace StartVS
{
    public sealed class App
    {
        private readonly VSConfiguration _configuration;

        public App([NotNull] VSConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            _configuration = configuration;
        }

        public async Task<ExitCode> RunAsync(ImmutableArray<string> args)
        {
            try
            {
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = _configuration.VisualStudioExePath,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                foreach (EnvironmentVariable environmentVariable in _configuration.EnvironmentVariables)
                {
                    if (start.EnvironmentVariables.ContainsKey(environmentVariable.Key))
                    {
                        start.EnvironmentVariables.Remove(environmentVariable.Key);
                    }

                    start.EnvironmentVariables.Add(environmentVariable.Key, environmentVariable.Value);
                }

                Process process = Process.Start(start);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return ExitCode.Failure;
            }

            return ExitCode.Success;
        }
    }
}