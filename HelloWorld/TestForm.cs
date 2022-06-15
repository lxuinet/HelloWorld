using LX;

namespace HelloWorld
{
    public class TestForm : Control
    {
        public TestForm()
        {
            // Добавляем форму на все окно
            this.AddToRoot(Alignment.Fill);
            // Устнавливаем отступы
            this.Padding = 16;
            
            // Создаем левый вертикальный список
            var leftPanel = new Control();
            leftPanel.AutoSize = true;
            leftPanel.Layout = new VerticalList(8);
            leftPanel.AddTo(this, Alignment.TopLeft);

            for (int i = 0; i < 3; i++)
            {
                // Добавляем выпадающий список
                ComboBox test = new ComboBox();
                test.Enabled = i != 2;
                test.Selected = i == 1;
                test.AutoSize = true;
                test.View = ComboBoxView.Button;
                test.AddTo(leftPanel);
                // Добавляем 1000 элементов в выпадающий список
                for (int j = 0; j < 1000; j++)
                {
                    test.Items.Add("Item " + j);
                }
                // Выбираем элемент с индексом 10
                test.SelectedItem = "Item 10";
            }

            for (int i = 0; i < 3; i++)
            {
                // Добавляем редактируемое текстовое поле
                TextBox test = new TextBox();
                test.Text = "some text";
                test.Enabled = i != 2;
                test.Selected = i == 1;
                test.AddTo(leftPanel);
            }


            for (int i = 0; i < 3; i++)
            {
                //Добавляем выпадающий список с автоматической шириной и режимом ComboBoxMode.Extract
                ComboBox test = new ComboBox();
                test.Mode = ComboBoxMode.Extract;
                test.Text = "Select ";
                test.Enabled = i != 2;
                test.Selected = i == 1;
                test.AutoSize = true;
                test.View = ComboBoxView.Button;
                test.Menu.AutoWidth = true;
                test.AddTo(leftPanel);
                
                for (int j = 0; j < 500; j++)
                {
                    // Добавляем элементы выпадающего списка
                    Label text = "Text test long long text" + j * 3;
                    text.Enabled = j != 2;
                    text.UserMouse = UserMode.None;
                    text.AutoWidth = true;
                    text.Add(Image.LoadIcon(j), Alignment.LeftCenter);
                    test.Items.Add(text);

                    if (test.SelectedItem == null)
                    {
                        test.SelectedItem = text;
                    }
                }
            }


            for (int i = 0; i < 3; i++)
            {
                //Добавляем выпадающий список с автоматической шириной и устанавливаем вид в ComboBoxView.TextBox
                ComboBox test = new ComboBox();
                test.Width = 200;
                test.Enabled = i != 2;
                test.Selected = i == 1;
                test.View = ComboBoxView.TextBox;
                test.AddTo(leftPanel);

                for (int j = 0; j < 5; j++)
                {
                    // Добавляем элементы выпадающего списка
                    test.Items.Add("Item " + j);
                }

                test.SelectedItem = "Item 1";
            }

            for (int i = 0; i < 2; i++)
            {
                // Добавляем надпись
                leftPanel.Add("Some text").Enabled = i != 1;
            }

            // Добавляем центральный вертикальный список
            var centerPanel = new Control();
            centerPanel.AutoSize = true;
            centerPanel.Layout = new VerticalList(8);
            centerPanel.AddTo(this, Alignment.TopCenter);

            for (int i = 0; i < 3; i++)
            {
                //Добавляем кнопку
                Button test = new Button();
                test.AutoSize = true;
                test.Text = "Button";
                test.Enabled = i != 2;
                test.Selected = i == 1;
                
                test.AutoWidth = true;
                test.Trimming = false;
                test.AddTo(centerPanel);

                // Добавляем иконку в кнопку
                test.Add(Image.LoadIcon(i), Alignment.RightCenter);

                // Добавляем переключатель в кнопку
                CheckBox checkBox = new CheckBox();
                checkBox.Checked = true;
                checkBox.ContentStyle = ColorStyle.Normal | ColorStyle.Disabled | ColorStyle.Selected;
                checkBox.AddTo(test, Alignment.LeftCenter);
            }

            for (int i = 0; i < 4; i++)
            {
                // Добавляем надпись
                Label label = "Need action";
                label.Enabled = i != 2;
                label.Selected = i == 1;
                label.AddTo(centerPanel);

                // Добавляем переключатель в надпись
                label.Add(i % 2 == 0 ? true : false, Alignment.LeftCenter);

            }

            for (int i = 0; i < 3; i++)
            {
                // Добавляем переключатель CheckBoxView.Radio
                CheckBox test = new CheckBox();
                test.View = CheckBoxView.Radio;
                test.Enabled = i != 2;
                test.Selected = i == 1;
                test.AddTo(centerPanel);
            }

            for (int i = 0; i < 3; i++)
            {
                // Добавляем переключатель CheckBoxView.Toggle
                CheckBox test = new CheckBox();
                test.View = CheckBoxView.Toggle;
                test.Enabled = i != 2;
                test.Selected = i == 1;
                test.AddTo(centerPanel);
            }

            // Добавляем правый вертикальный список
            var rightPanel = new Control();
            rightPanel.AutoSize = true;
            rightPanel.Layout = new VerticalList(8);
            rightPanel.AddTo(this, Alignment.TopRight);

            for (int i = 0; i < 3; i++)
            {
                // Добавляем кнопку с автошириной
                Button test = new Button();
                test.Text = "Button " + i.ToString();
                test.Enabled = i != 2;
                test.Selected = i == 1;
                test.AutoSize = true;
                test.AddTo(rightPanel);
            }

            for (int i = 0; i < 5; i++)
            {
                // Добавляем горизонтальный Slider
                Slider test = new Slider();
                test.Value = 50;
                test.Orientation = SliderOrientation.Horizontal;
                test.Enabled = i != 4;
                test.Selected = i == 0;
                test.AddTo(rightPanel);

            }

            for (int i = 0; i < 6; i++)
            {
                // Добавляем горизонтальный ProgressBar
                ProgressBar test = new ProgressBar();
                test.Value = 50;
                test.Orientation = ProgressBarOrientation.Horizontal;
                test.Enabled = i != 5;
                test.AddTo(rightPanel);
            }
        }
    }
}
