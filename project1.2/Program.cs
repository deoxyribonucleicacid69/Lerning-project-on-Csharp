using Library69;



class Programm
{
    static void Main()
    {
        List<Visitor> visitors = new List<Visitor>();
        string inputFilePath = String.Empty;
        string outputFilePath = String.Empty;
        Menu menu = new Menu();
        int index = 0;
        menu.LaunchingMainMenu(index, FieldMenu.MainMenu,ref visitors, ref inputFilePath);
        
    }
}