namespace Paco.Entities.FreeBsd
{
    public class FreeBsdCommandResult
    {
        public string Command { get; init; }
        public string Response { get; init; }
        public int Return { get; init; }
        public bool Success => Return == 0;

        public override string ToString()
        {
            return $"Command: {Command}\n" +
                   $"Response: {Response}\n" +
                   $"Return: {Return}\n" +
                   $"Success: {Success}";
        }
    }
}