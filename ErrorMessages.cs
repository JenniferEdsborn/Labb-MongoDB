namespace Labb_MongoDB
{
    internal class ErrorMessages : IErrorMessages
    {
        private readonly IStringIO io = new ConsoleIO();

        public void ErrorOccured()
        {
            io.PrintString("An error occurred");
        }

        public void NoPostsFound()
        {
            io.PrintString("No posts found.");
        }

        public void WrongInput()
        {
            io.PrintString("Wrong input.");
        }
    }
}
