namespace StartVS
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var exitCode = AppBuilder.BuildApp().RunAsync(args.SafeToImmutableArray()).Result.Result;

            return exitCode;
        }
    }
}