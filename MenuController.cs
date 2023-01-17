using MongoDB.Bson;
using MongoDB.Driver;

namespace Labb_MongoDB
{
    internal class MenuController : IMenuOperations
    {
        private readonly IStringIO io;
        private readonly ICRUDOperationsDAO CRUD;
        private readonly IErrorMessages errorMessages;

        public MenuController(IStringIO io, ICRUDOperationsDAO CRUD, IErrorMessages errorMessage)
        {
            this.io = io;
            this.CRUD = CRUD;
            this.errorMessages = errorMessage;
        }

        public void DisplayMenu()
        {
            io.PrintString("= = = = = = = = = = = = = = = = =\n" +
                           "====   SUPERGAMES WEBSHOP    ====\n" +
                           "= = = = = = = = = = = = = = = = =");
            while (true)
            {
                io.PrintString("\n= MENY =\n1. Sortiment\n2. Sök\n3. Lägg till\n4. Uppdatera\n5. Radera\n6. Avsluta");
                int input = io.ParseInput(io.GetString());
                io.PrintString("");

                switch (input)
                {
                    case 1:
                        MenuGetAll();
                        break;
                    case 2:
                        MenuGetOne();
                        break;
                    case 3:
                        MenuCreate();
                        break;
                    case 4:
                        MenuUpdate();
                        break;
                    case 5:
                        MenuDelete();
                        break;
                    case 6:
                        io.Exit();
                        break;
                    default:
                        errorMessages.WrongInput();
                        break;
                }
            }
        }

        public void MenuCreate()
        {
            io.PrintString("= LÄGG TILL =\n");

            io.PrintPrompt("Namn");
            string name = io.GetString();
            io.PrintPrompt("Typ");
            string type = io.GetString();
            io.PrintPrompt("Pris");
            int price = io.ParseInput(io.GetString());
            io.PrintPrompt("Antal");
            int quantity = io.ParseInput(io.GetString());
            io.PrintPrompt("Beskrivning");
            string description = io.GetString();
            ProductODM newProduct = new ProductODM(name, type, price, quantity, description);
            CRUD.Create(newProduct);
            io.PrintString("Produkt tillagd.");
        }

        public void MenuDelete()
        {
            io.PrintString("= RADERA =\n");
            io.PrintPrompt("ID på post att radera");
            string id = io.GetString();
            try
            {
                var result = CRUD.GetOne(id);
            }
            catch
            {
                errorMessages.NoPostsFound();
                return;
            }

            CRUD.Delete(ObjectId.Parse(id));
            io.PrintString("Post borttagen.");
        }

        public void MenuGetAll()
        {
            io.PrintString("= SORTIMENT =");
            var products = CRUD.GetAll();
            if (products.Count == 0)
            {
                errorMessages.NoPostsFound();
            }
            else
            {
                foreach (var product in products)
                {
                    io.PrintString($"ID: {product.Id}\nName: {product.Name}\nPrice: {product.Price}\nQuantity: {product.Quantity}\nDescription: {product.Description}\n");
                }
            }
        }

        public void MenuGetOne()
        {
            io.PrintString("= SÖK =\n");
            io.PrintPrompt("Sökord");

            var result = CRUD.GetOne(io.GetString());

            if (result.Count == 0)
            {
                errorMessages.NoPostsFound();
            }
            else
            {
                io.PrintString("Följande poster hittades:");
                foreach (var res in result)
                {
                    io.PrintString($"Name: {res.Name}\nPrice: {res.Price}\nQuantity: {res.Quantity}\nDescription: {res.Description}\n");
                }
            }
        }

        public void MenuUpdate()
        {
            io.PrintString("= UPPDATERA =\n");
            io.PrintPrompt("ID på post du vill uppdatera");
            string id = io.GetString();

            try
            {               
                var test = ObjectId.Parse(id);
            }
            catch
            {
                errorMessages.NoPostsFound();
                return;
            }

            var objectId = ObjectId.Parse(id);

            io.PrintPrompt("Namn");
            string name = io.GetString();
            io.PrintPrompt("Typ");
            string type = io.GetString();
            io.PrintPrompt("Pris");
            int price = io.ParseInput(io.GetString());
            io.PrintPrompt("Antal");
            int quantity = io.ParseInput(io.GetString());
            io.PrintPrompt("Beskrivning");
            string description = io.GetString();
            ProductODM updatedProduct = new ProductODM(name, type, price, quantity, description);
            CRUD.Update(objectId, updatedProduct);
            io.PrintString("Posten uppdaterades.");
        }
    }
}


