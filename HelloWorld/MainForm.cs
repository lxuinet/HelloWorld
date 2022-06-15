using LX;

namespace HelloWorld
{
    internal class MainForm : Control
    {
        public MainForm()
        {
            // Добавляем форму в окно с заполнением по всему родительскому элементу
            this.AddToRoot(Alignment.Fill);
            // Устанавливаем отступы
            this.Padding = 16;

            // Добавляем надпись на форму с выравниванием по центру
            this.Add("Hello world", Alignment.Center);

            // Добавляем кнопку
            var button = new Button();
            button.Add("Click me");
            button.AddTo(this, Alignment.TopCenter);
            button.OnClick += delegate 
            { 
                Dialog.Show(this, "Hi world!"); 
            };
        }
    }
}
