using LX;

namespace HelloWorld
{
    internal class RoundedButton : PictureBox
    {
        public RoundedButton()
        {
            // Устанавливаем размер 
            this.Size = 32;
            // Делаем все края скругленными
            this.Shape = CornerShape.Oval;
            // Устанавливаем радиус скругления
            this.Radius = 16;
            // Разрешаем все стили поведения
            this.Style = ColorStyle.All;
            // Разрешаем использовать мышь на этом элементе
            this.UserMouse = UserMode.On;
            // Размещаем изображение по центру элемента
            this.ImageAlignment = Alignment.Center;
            // Указываем автоцвет для монохромных изображений
            this.ImageColor = Color.Content;
        }
    }
}
