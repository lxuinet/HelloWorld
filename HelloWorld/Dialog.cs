using LX;

namespace HelloWorld
{
    internal class Dialog : Control
    {
        public Label Message;
        public Dialog(Control owner)
        {
            // Создаем полупрозрачную форму на всё окно
            this.Padding = 16;
            this.Alignment = Alignment.Fill;
            this.Color = Color.Background.Alpha(100);

            // Создаем форму диалога
            var body = new Control();
            body.AutoSize = true;
            body.Color = Color.Surface;
            body.Shape = CornerShape.Oval;
            body.BottomRightShape = CornerShape.Rectangle;
            body.Radius = 16;
            body.Layout = new HorizontalList();
            body.AddTo(this, Alignment.BottomRight);

            var back = new PictureBox();
            // Задаем прозрачность изображения
            back.Transparency = 64;
            // Загружаем изображение из ресурсов
            back.Image = Image.LoadFromResource("*.MyResources.palm.png");
            // Задаем начальную позицию для заполнения
            back.ImageAlignment = Alignment.TopLeft;
            // Растягиваем весь элемент управления по родительскому элементу
            // и отключаем зависимость от Layout родительского элемента
            back.Alignment = Alignment.NotLayouted | Alignment.Fill;
            // Устанавливаем заливку
            back.Tile = ImageTile.Vertical | ImageTile.Horizontal;
            back.AddTo(body);

            // Добавляем надпись
            Message = new Label();
            Message.Font = Font.H1;
            Message.TextPadding = 32;
            Message.Color = Color.Surface;
            Message.AddTo(body, Alignment.LeftCenter);

            // Добавляем кнопку закрытия диалога
            var closeButton = new RoundedButton();
            closeButton.Image = Image.LoadFromFont("Icons.ttf", 18, (ushort)(0xEB33));
            closeButton.AddTo(body, Alignment.TopLeft);
            closeButton.OnClick += delegate
            {
                Close();
            };

            // Добавляем счетчик времени
            var counter = new Label();
            counter.AddTo(body, Alignment.TopLeft | Alignment.NotLayouted);

            // Действия при отображении диалога
            this.OnShow += delegate
            {
    // Отключаем вызывающий элемент
    owner.Enabled = false;

    // Подписываемся на горячие клавиши
    this.StartHotKey(Key.Escape).Press += Dialog_ExitPress;
    // Подписываемся на горячие клавиши (для Android)
    this.StartHotKey(Key.BrowserBack).Press += Dialog_ExitPress;

    // Создаем таймер
    this.StartTimer().Tick += (object sender, Timer e) =>
                {
                    var total = System.TimeSpan.FromMilliseconds(5000);
                    counter.Text = "closing at: " + total.Subtract(e.TotalElapsed).ToString("ss\\.ff");
                    if (e.TotalElapsed > total)
                    {
            // останавливаем таймер
            e.Stop();
            // закрываем диалог
            Close();
                    }
                };
            };

            // Действия при скрытии диалога
            this.OnHide += delegate
            {
    // Отписываемся от горячих клавиш
    this.StopHotKeys();

    // Останавливаем все таймеры
    this.StopTimers();

    // Включаем вызывающий элемент
    owner.Enabled = true;
            };

        }

        private bool Dialog_ExitPress(object sender, HotKey e)
        {
            // Закрываем диалог
            Close();
            // Сообщаем, что мы обработали данную комбинацию клавиш
            return true;
        }

        public void Close()
        {
            // Удаляем диалог из корневого элемента управления
            this.Remove();
        }

        public static Dialog Show(Control owner, string message)
        {
            // Создаем диалог
            var dialog = new Dialog(owner);
            // Изменяем текст сообщения
            dialog.Message.Text = message;
            // Добавляем диалог в корневой элемент управления
            dialog.AddToRoot();
            return dialog;
        }
    }
}
