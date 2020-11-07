namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            RechnerModel model = new RechnerModel();
            ConsoleView view = new ConsoleView();
            AnwendungsController controller = new AnwendungsController(model, view);            

            controller.Ausfuehren();
        }       
    }
}
