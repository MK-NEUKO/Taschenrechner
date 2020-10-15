namespace Taschenrechner
{
    public delegate void BeendenEventHandler();
    public delegate void ZuruecksetzenEventHandler();

    class Program
    {
        static void Main(string[] args)
        {
            RechnerModel model = new RechnerModel();
            ConsoleView view = new ConsoleView(model);
            AnwendungsController controller = new AnwendungsController(model, view);

            view.Beenden += controller.View_Beenden;
            view.Zuruecksetzen += controller.View_Zuruecksetzen;

            controller.Ausfuehren();
        }       
    }
}
