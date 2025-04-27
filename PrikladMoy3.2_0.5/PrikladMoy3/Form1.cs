using System;
using System.Windows.Forms;
using static PrikladMoy3.FileDataSource;

namespace PrikladMoy3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private ListBox listBox1;
        private static IDataSource dataSource = new MemoryDataSource();

        internal static IDataSource DataSource { get => dataSource; set => dataSource = value; }

        public void InitializeComponent()
        {
            listBox2 = new ListBox();
            Добавить = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            buttonAccept = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            RedactAll = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(12, 12);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(447, 169);
            listBox2.TabIndex = 0;
            // 
            // Добавить
            // 
            Добавить.Location = new Point(27, 224);
            Добавить.Name = "Добавить";
            Добавить.Size = new Size(75, 23);
            Добавить.TabIndex = 1;
            Добавить.Text = "Добавить";
            Добавить.UseVisualStyleBackColor = true;
            Добавить.Click += Add_Click;
            // 
            // button2
            // 
            button2.Location = new Point(118, 224);
            button2.Name = "button2";
            button2.Size = new Size(96, 23);
            button2.TabIndex = 2;
            button2.Text = "Редактировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OneThingRedact_Click;
            // 
            // button3
            // 
            button3.Location = new Point(384, 224);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Delete_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 272);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(291, 23);
            textBox1.TabIndex = 4;
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(324, 271);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(135, 23);
            buttonAccept.TabIndex = 5;
            buttonAccept.Text = "Отправить запрос";
            buttonAccept.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 254);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 6;
            label1.Text = " ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 189);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 7;
            label2.Text = " ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 12);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 8;
            label3.Text = "Описание:";
            // 
            // RedactAll
            // 
            RedactAll.Location = new Point(220, 224);
            RedactAll.Name = "RedactAll";
            RedactAll.Size = new Size(142, 23);
            RedactAll.TabIndex = 9;
            RedactAll.Text = "Редактировать всё";
            RedactAll.UseVisualStyleBackColor = true;
            RedactAll.Click += RedactAll_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ScrollBar;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(241, 246);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 10;
            comboBox1.Visible = false;
            // 
            // Form1
            // 
            ClientSize = new Size(800, 316);
            Controls.Add(comboBox1);
            Controls.Add(RedactAll);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonAccept);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Добавить);
            Controls.Add(listBox2);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private ListBox listBox2;
        private Button Добавить;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Button buttonAccept;


        private void Add_Click(object sender, EventArgs e)
        {
            // Пошаговый процесс добавления записи

            Step = 0;
            label1.Text = "Введите учётную запись сотрудника:";
            label2.Text = "Запись в процессе заполнения...";
            buttonAccept.Click += ProcessInput;
        }

        private int Step = 0;
        private EmployeeRecord record = new EmployeeRecord();

        private void ProcessInput(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            textBox1.Clear(); // Очистка текстового поля для следующего ввода

            switch (Step)
            {
                case 0:
                    // Сохраняем учётную запись
                    record.Account = input;
                    label1.Text = "Введите имя сотрудника:";
                    Step++;
                    break;
                case 1:
                    // Сохраняем имя
                    record.Name = input;
                    label1.Text = "Введите дату устройства сотрудника (ДД-ММ-ГГГГ):";
                    Step++;
                    break;
                case 2:
                    // Проверяем и сохраняем дату устройства
                    if (!DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime startDate))
                    {
                        label1.Text = "Ошибка: неверный формат даты. Попробуйте снова (ДД-ММ-ГГГГ):";
                    }
                    else
                    {
                        record.DateStart = startDate;
                        label1.Text = "Сотрудник уволен? (да/нет):";
                        Step++;
                    }
                    break;
                case 3:
                    // Проверяем статус увольнения
                    if (input.ToLower() == "да")
                    {
                        label1.Text = "Введите дату увольнения (ДД-ММ-ГГГГ):";
                        Step++;
                    }
                    else if (input.ToLower() == "нет")
                    {
                        record.DateEnd = null;
                        label1.Text = "Введите описание учёта:";
                        Step = 5;
                    }
                    else
                    {
                        label1.Text = "Ошибка: введите 'да' или 'нет'. Попробуйте снова:";
                    }
                    break;
                case 4:
                    // Сохраняем дату увольнения
                    if (!DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime endDate))
                    {
                        label1.Text = "Ошибка: неверный формат даты. Попробуйте снова (ДД-ММ-ГГГГ):";
                    }
                    else
                    {
                        record.DateEnd = endDate;
                        label1.Text = "Введите описание учёта:";
                        Step++;
                    }
                    break;
                case 5:
                    // Сохраняем описание
                    record.Description = string.IsNullOrEmpty(input) ? "Не заполнено" : input;

                    // Сохраняем запись в источник данных
                    var savedRecord = DataSource.Save(record);
                    listBox2.Items.Add(FormatRecordForDisplay(savedRecord));
                    label2.Text = "Запись успешно добавлена!";
                    label1.Text = " ";
                    Step = 0;

                    // Убираем обработчик
                    buttonAccept.Click -= ProcessInput;

                    break;
            }
        }

        private void RedactAll_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли запись в ListBox
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите запись для редактирования.", "Ошибка");
                return;
            }

            // Получаем выбранную запись
            string selectedItem = listBox2.SelectedItem.ToString();
            int id = ExtractIDFromListBoxItem(selectedItem); // Метод извлечения ID из строки
            var record = DataSource.Get(id);

            if (record == null)
            {
                MessageBox.Show("Запись с таким ID не найдена.", "Ошибка");
                return;
            }

            // Редактируем поля записи
            string newAccount = Prompt($"Текущий учёт: {record.Account}\nВведите новый учёт (или оставьте пустым):");
            if (!string.IsNullOrEmpty(newAccount)) record.Account = newAccount;

            string newName = Prompt($"Текущее имя: {record.Name}\nВведите новое имя (или оставьте пустым):");
            if (!string.IsNullOrEmpty(newName)) record.Name = newName;

            string newDescription = Prompt($"Текущее описание: {record.Description}\nВведите новое описание (или оставьте пустым):");
            if (!string.IsNullOrEmpty(newDescription)) record.Description = newDescription;

            string newStartDate = Prompt($"Текущая дата устройства: {record.DateStart:dd-MM-yyyy}\nВведите новую дату устройства (ДД-ММ-ГГГГ или оставьте пустым):");
            if (!string.IsNullOrEmpty(newStartDate) && DateTime.TryParseExact(newStartDate, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime startDate))
            {
                record.DateStart = startDate;
            }

            string isFired = Prompt($"Сотрудник уволен? (да/нет, оставьте пустым для сохранения текущего):");
            if (isFired == "да")
            {
                string endDate = Prompt($"Текущая дата увольнения: {(record.DateEnd.HasValue ? record.DateEnd.Value.ToString("dd-MM-yyyy") : "нет")}\nВведите новую дату увольнения (ДД-ММ-ГГГГ):");
                if (!string.IsNullOrEmpty(endDate) && DateTime.TryParseExact(endDate, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    record.DateEnd = parsedEndDate;
                }
                else
                {
                    MessageBox.Show("Ошибка: неверный формат даты увольнения.", "Ошибка");
                }
            }
            else if (isFired == "нет")
            {
                record.DateEnd = null;
            }
            DataSource.Save(record);

            // Обновляем запись в ListBox
            int selectedIndex = listBox2.SelectedIndex;
            listBox2.Items[selectedIndex] = FormatRecordForDisplay(record);

            MessageBox.Show("Запись успешно обновлена.", "Успех");
        }

        private string Prompt(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Редактирование");
        }

        private int ExtractIDFromListBoxItem(string item)
        {
            // Извлечение ID из строки
            string idPart = item.Split(',')[0]; // "ID: 1"
            return int.Parse(idPart.Replace("ID: ", "").Trim());
        }

        private string FormatRecordForDisplay(MainRecord record)
        {
            return $"ID: {record.ID}, Имя: {record.Name}, Учёт: {record.Account}";
        }




        private Label label1;


        private Label label2;

        private string listBox2_SelectedIndexChanged(EmployeeRecord record)
        {
            return $"ID: {record.ID}, Имя: {record.Name}, Учётная запись: {record.Account}";
        }

        private Label label3;
        private Button RedactAll;

        private void OneThingRedact_Click(object sender, EventArgs e)
        {
            label1.Text = "Что вы хотите отредактировать";
            label2.Visible = false;
            textBox1.Visible = false;
            buttonAccept.Visible = false;
            buttonAccept.Text = "Сохранить";
            comboBox1.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Учёт сотрудника");
            comboBox1.Items.Add("Имя сотрудника");
            comboBox1.Items.Add("Дата устройства");
            comboBox1.Items.Add("Статус увольнения");
            comboBox1.Items.Add("Дата увольнения");
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Получаем выбранный элемент

                if (listBox2.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите запись для редактирования.", "Ошибка");
                    return;
                }
                string selectedItem = comboBox1.SelectedItem.ToString();
                // В зависимости от выбора отображаем нужные элементы управления для ввода новых данных
                switch (selectedItem)
                {
                    case "Учёт сотрудника":
                        label2.Text = "Введите новый учёт сотрудника:";
                        textBox1.Visible = true;
                        break;

                    case "Имя сотрудника":
                        label2.Text = "Введите новое имя сотрудника:";
                        textBox1.Visible = true;
                        break;

                    case "Дата устройства":
                        label2.Text = "Введите новую дату устройства (ДД-ММ-ГГГГ):";
                        textBox1.Visible = true;
                        break;

                    case "Статус увольнения":
                        label2.Text = "Введите новый статус (Уволен/Не уволен):";
                        textBox1.Visible = true;
                        break;

                    case "Дата увольнения":
                        label2.Text = "Введите новую дату увольнения (ДД-ММ-ГГГГ):";
                        textBox1.Visible = true;
                        break;

                    default:
                        label2.Text = "Выберите опцию для редактирования";
                        break;
                }

                label2.Visible = true;
                buttonAccept.Visible = true;
            }

            buttonAccept.Click += buttonSave_Click;

            void buttonSave_Click(object sender, EventArgs e)
            {
                string selectedItem = comboBox1.SelectedItem?.ToString();
                string inputValue = textBox1.Text;

                switch (selectedItem)
                {
                    case "Учёт сотрудника":
                        MessageBox.Show($"Учёт сотрудника изменён на: {inputValue}");
                        break;

                    case "Имя сотрудника":
                        MessageBox.Show($"Имя сотрудника изменено на: {inputValue}");
                        break;

                    case "Дата устройства":
                        if (IsValidDate(inputValue))
                        {
                            MessageBox.Show($"Дата устройства изменена на: {inputValue}");
                        }
                        else
                        {
                            MessageBox.Show("Некорректный формат даты. Используйте ДД-ММ-ГГГГ.", "Ошибка");
                        }
                        break;

                    case "Статус увольнения":
                        MessageBox.Show($"Статус увольнения изменён на: {inputValue}");
                        break;

                    case "Дата увольнения":
                        if (IsValidDate(inputValue))
                        {
                            MessageBox.Show($"Дата увольнения изменена на: {inputValue}");
                        }
                        else
                        {
                            MessageBox.Show("Некорректный формат даты. Используйте ДД-ММ-ГГГГ.", "Ошибка");
                        }
                        break;

                    default:
                        MessageBox.Show("Выберите корректный пункт для редактирования");
                        break;
                }

                // Скрываем элементы после сохранения
                label2.Visible = false;
                textBox1.Visible = false;
                buttonAccept.Visible = false;
            }

            // Метод для проверки корректности формата даты
            bool IsValidDate(string dateString)
            {
                return DateTime.TryParseExact(
                    dateString,
                    "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out _);
            }
        }


        private ComboBox comboBox1;
            private void Delete_Click(object sender, EventArgs e)
            {
                if (listBox2.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите запись для редактирования.", "Ошибка");
                    return;
                }

                string selectedItem = listBox2.SelectedItem.ToString();
                int id = ExtractIDFromListBoxItem(selectedItem); // Метод извлечения ID из строки

                // Удаляем запись из источника данных
                if (DataSource.Delete(id))
                {
                    // Удаляем запись из ListBox
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    MessageBox.Show("Запись успешно удалена.", "Успех");
                }
                else
                {
                    MessageBox.Show("Запись с таким ID не найдена.", "Ошибка");
                }
            }
        }



    }



        //private static void ViewRecords()
        //{
        //    var records = DataSource.GetAll();
        //    if (records.Count == 0)
        //    {
        //        Console.WriteLine("Записей нет.");
        //        return;
        //    }

//    Console.WriteLine("Список записей:");
//    foreach (var record in records)
//    {
//        Console.WriteLine($"ID: {record.ID}, Учёт: {record.Account}, Имя: {record.Name}, Дата устройства: {record.DateStart:dd-MM-yyyy}, Дата увольнения: {(record.DateEnd.HasValue ? record.DateEnd.Value.ToString("dd-MM-yyyy") : "Не уволен")}, Описание: {record.Description}");
//    }
//}



//public static void DeleteRecord()
//{
//    Console.WriteLine("Введите ID записи для удаления:");
//    if (int.TryParse(Console.ReadLine(), out int id))
//    {
//        if (DataSource.Delete(id))
//        {
//            Console.WriteLine("Запись успешно удалена.");
//        }
//        else
//        {
//            Console.WriteLine("Запись с таким ID не найдена.");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Ошибка: неверный формат ID.");
//    }
//}