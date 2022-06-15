using LX;

namespace HelloWorld
{
    internal class GalleryForm : Control
    {
        public GalleryForm()
        {
            // Добавляем форму на все окно
            this.AddToRoot(Alignment.Fill);
            // Устнавливаем отступы
            this.SetPadding(16, 64, 16, 16);
          
            // Делаем форму галереей
            this.Layout = new VerticalGallery() 
            { 
                Spacing = 8, 
                HorizontalAlignment = InlineAlignment.Center 
            };

            // Создаем панель управления
            var skinPanel = new Control();
            skinPanel.Height = 48;
            skinPanel.Color = Color.Secondary;
            skinPanel.Shadow = ShadowStyle.Bottom2;
            skinPanel.Layout = new HorizontalList();
            // Добавляем панель в форму,с выравниванием по верхнему краю
            skinPanel.AddTo(this, Alignment.TopFill | Alignment.NotLayouted);

            // Добавляем надписи
            skinPanel.Add("Change theme: ", Alignment.LeftCenter);
            skinPanel.Add("Dark", Alignment.LeftCenter);

            // Создаем переключатель темы
            var skinChanger = new CheckBox();
            skinChanger.View = CheckBoxView.Toggle;
            skinChanger.ContentColor = Color.Primary;
            skinChanger.ContentStyle = ColorStyle.Normal | ColorStyle.Hovered | ColorStyle.Downed;
            skinChanger.AddTo(skinPanel, Alignment.LeftCenter);

            // Добавляем событие переключателя
            skinChanger.OnCheckedChanged += delegate
            {
                Window.Skin = skinChanger.Checked ? (Skin)new WhiteSkin() : new BlackSkin();

            };
            skinChanger.Checked = true;

            //Добавляем надпись
            skinPanel.Add("Light", Alignment.LeftCenter);

            // Заполняем галерею
            int index = 0;
            while (true)
            {
                // Загружаем изображение размером 48 пикселей
                var source = Image.LoadIcon(48, index++);
                if (source != null)
                {
                    var pictireBox = new PictureBox();
                    pictireBox.Image = source;
                    pictireBox.UserMouse = UserMode.On;
                    pictireBox.Style = ColorStyle.Normal | ColorStyle.Hovered | ColorStyle.Downed;
                    pictireBox.Color = Color.Background;
                    pictireBox.Shape = CornerShape.Oval;
                    pictireBox.Radius = 8;
                    pictireBox.AutoSize = true;
                    pictireBox.ImagePadding = 16;
                    pictireBox.ImageColor = Color.Content;
                    pictireBox.ImageAlignment = Alignment.Center;
                    pictireBox.AddTo(this);

                    // На событие Click включаем или отключаем таймер поворота
                    pictireBox.OnClick += delegate
                    {
                        var timer = pictireBox.GetTimer("RotateTimer");
                        if (timer != null)
                        {
                            timer.Stop();
                        }
                        else
                        {
                            timer = pictireBox.StartTimer("RotateTimer");
                            timer.Tick += delegate
                            {
                                pictireBox.Rotation += timer.ElapsedMilliseconds * 360 / 1000;
                            };
                        }
                    };
                }
                else
                {
                    break;
                }
            }
        }
    }
}
