namespace Core.CrossCuttingConcerns.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message)
        {

        }
    }
}
