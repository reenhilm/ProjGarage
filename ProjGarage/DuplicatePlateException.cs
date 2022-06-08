namespace ProjGarage
{
    internal class DuplicatePlateException : Exception
    {
        public DuplicatePlateException()
        {
        }

        public DuplicatePlateException(string message)
            : base(message)
        {
        }

        public DuplicatePlateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
