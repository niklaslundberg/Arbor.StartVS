using System;
using Arbor.KVConfiguration.Urns;
using JetBrains.Annotations;

namespace StartVS
{
    [Urn(ConfigurationKeys.EnvironmentVariable)]
    public class EnvironmentVariable
    {
        public EnvironmentVariable([NotNull] string key, [NotNull] string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }

        public override string ToString()
        {
            return $"{nameof(Key)}: {Key}, {nameof(Value)}: {Value}";
        }
    }
}