namespace Taschenrechner
{
    public delegate void ZuruecksetzenEventHandler();

    class Program
    {
        static void Main(string[] args)
        {
            RechnerModel model = new RechnerModel();
            ConsoleView view = new ConsoleView(model);
            AnwendungsController controller = new AnwendungsController(model, view);
         
            view.Zuruecksetzen += controller.View_Zuruecksetzen;

            controller.Ausfuehren();
        }       
    }
}
