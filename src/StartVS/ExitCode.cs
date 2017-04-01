namespace StartVS
{
    public struct ExitCode
    {
        public int Result { get; }

        public static ExitCode Success = new ExitCode(0);
        public static ExitCode Failure = new ExitCode(1);

        public ExitCode(int result)
        {
            Result = result;
        }

        public bool IsSuccess => Result == 0;
    }
}