using LX;

namespace HelloWorld.Desktop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем форму при старте приложение
            //App.OnRun += () => new MainForm();
            //App.OnRun += () => new GalleryForm();
            App.OnRun += () => new TestForm();
            // Запускаем приложение
            App.Run();
        }
    }
}
