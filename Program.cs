namespace Labb_MongoDB;

internal class Program
{
    static void Main(string[] args)
    {
        IStringIO io = new ConsoleIO();
        ICRUDOperationsDAO CRUDOperationsDAO = new MongoDAO("", "product");
        ErrorMessages errorMessages = new ErrorMessages();

        MenuController controller = new MenuController(io, CRUDOperationsDAO, errorMessages);

        controller.DisplayMenu();
    }
}