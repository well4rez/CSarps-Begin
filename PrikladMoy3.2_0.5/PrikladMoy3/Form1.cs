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
            �������� = new Button();
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
            // ��������
            // 
            ��������.Location = new Point(27, 224);
            ��������.Name = "��������";
            ��������.Size = new Size(75, 23);
            ��������.TabIndex = 1;
            ��������.Text = "��������";
            ��������.UseVisualStyleBackColor = true;
            ��������.Click += Add_Click;
            // 
            // button2
            // 
            button2.Location = new Point(118, 224);
            button2.Name = "button2";
            button2.Size = new Size(96, 23);
            button2.TabIndex = 2;
            button2.Text = "�������������";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OneThingRedact_Click;
            // 
            // button3
            // 
            button3.Location = new Point(384, 224);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "�������";
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
            buttonAccept.Text = "��������� ������";
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
            label3.Text = "��������:";
            // 
            // RedactAll
            // 
            RedactAll.Location = new Point(220, 224);
            RedactAll.Name = "RedactAll";
            RedactAll.Size = new Size(142, 23);
            RedactAll.TabIndex = 9;
            RedactAll.Text = "������������� ��";
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
            Controls.Add(��������);
            Controls.Add(listBox2);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private ListBox listBox2;
        private Button ��������;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Button buttonAccept;


        private void Add_Click(object sender, EventArgs e)
        {
            // ��������� ������� ���������� ������

            Step = 0;
            label1.Text = "������� ������� ������ ����������:";
            label2.Text = "������ � �������� ����������...";
            buttonAccept.Click += ProcessInput;
        }

        private int Step = 0;
        private EmployeeRecord record = new EmployeeRecord();

        private void ProcessInput(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            textBox1.Clear(); // ������� ���������� ���� ��� ���������� �����

            switch (Step)
            {
                case 0:
                    // ��������� ������� ������
                    record.Account = input;
                    label1.Text = "������� ��� ����������:";
                    Step++;
                    break;
                case 1:
                    // ��������� ���
                    record.Name = input;
                    label1.Text = "������� ���� ���������� ���������� (��-��-����):";
                    Step++;
                    break;
                case 2:
                    // ��������� � ��������� ���� ����������
                    if (!DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime startDate))
                    {
                        label1.Text = "������: �������� ������ ����. ���������� ����� (��-��-����):";
                    }
                    else
                    {
                        record.DateStart = startDate;
                        label1.Text = "��������� ������? (��/���):";
                        Step++;
                    }
                    break;
                case 3:
                    // ��������� ������ ����������
                    if (input.ToLower() == "��")
                    {
                        label1.Text = "������� ���� ���������� (��-��-����):";
                        Step++;
                    }
                    else if (input.ToLower() == "���")
                    {
                        record.DateEnd = null;
                        label1.Text = "������� �������� �����:";
                        Step = 5;
                    }
                    else
                    {
                        label1.Text = "������: ������� '��' ��� '���'. ���������� �����:";
                    }
                    break;
                case 4:
                    // ��������� ���� ����������
                    if (!DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime endDate))
                    {
                        label1.Text = "������: �������� ������ ����. ���������� ����� (��-��-����):";
                    }
                    else
                    {
                        record.DateEnd = endDate;
                        label1.Text = "������� �������� �����:";
                        Step++;
                    }
                    break;
                case 5:
                    // ��������� ��������
                    record.Description = string.IsNullOrEmpty(input) ? "�� ���������" : input;

                    // ��������� ������ � �������� ������
                    var savedRecord = DataSource.Save(record);
                    listBox2.Items.Add(FormatRecordForDisplay(savedRecord));
                    label2.Text = "������ ������� ���������!";
                    label1.Text = " ";
                    Step = 0;

                    // ������� ����������
                    buttonAccept.Click -= ProcessInput;

                    break;
            }
        }

        private void RedactAll_Click(object sender, EventArgs e)
        {
            // ���������, ������� �� ������ � ListBox
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("����������, �������� ������ ��� ��������������.", "������");
                return;
            }

            // �������� ��������� ������
            string selectedItem = listBox2.SelectedItem.ToString();
            int id = ExtractIDFromListBoxItem(selectedItem); // ����� ���������� ID �� ������
            var record = DataSource.Get(id);

            if (record == null)
            {
                MessageBox.Show("������ � ����� ID �� �������.", "������");
                return;
            }

            // ����������� ���� ������
            string newAccount = Prompt($"������� ����: {record.Account}\n������� ����� ���� (��� �������� ������):");
            if (!string.IsNullOrEmpty(newAccount)) record.Account = newAccount;

            string newName = Prompt($"������� ���: {record.Name}\n������� ����� ��� (��� �������� ������):");
            if (!string.IsNullOrEmpty(newName)) record.Name = newName;

            string newDescription = Prompt($"������� ��������: {record.Description}\n������� ����� �������� (��� �������� ������):");
            if (!string.IsNullOrEmpty(newDescription)) record.Description = newDescription;

            string newStartDate = Prompt($"������� ���� ����������: {record.DateStart:dd-MM-yyyy}\n������� ����� ���� ���������� (��-��-���� ��� �������� ������):");
            if (!string.IsNullOrEmpty(newStartDate) && DateTime.TryParseExact(newStartDate, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime startDate))
            {
                record.DateStart = startDate;
            }

            string isFired = Prompt($"��������� ������? (��/���, �������� ������ ��� ���������� ��������):");
            if (isFired == "��")
            {
                string endDate = Prompt($"������� ���� ����������: {(record.DateEnd.HasValue ? record.DateEnd.Value.ToString("dd-MM-yyyy") : "���")}\n������� ����� ���� ���������� (��-��-����):");
                if (!string.IsNullOrEmpty(endDate) && DateTime.TryParseExact(endDate, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedEndDate))
                {
                    record.DateEnd = parsedEndDate;
                }
                else
                {
                    MessageBox.Show("������: �������� ������ ���� ����������.", "������");
                }
            }
            else if (isFired == "���")
            {
                record.DateEnd = null;
            }
            DataSource.Save(record);

            // ��������� ������ � ListBox
            int selectedIndex = listBox2.SelectedIndex;
            listBox2.Items[selectedIndex] = FormatRecordForDisplay(record);

            MessageBox.Show("������ ������� ���������.", "�����");
        }

        private string Prompt(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "��������������");
        }

        private int ExtractIDFromListBoxItem(string item)
        {
            // ���������� ID �� ������
            string idPart = item.Split(',')[0]; // "ID: 1"
            return int.Parse(idPart.Replace("ID: ", "").Trim());
        }

        private string FormatRecordForDisplay(MainRecord record)
        {
            return $"ID: {record.ID}, ���: {record.Name}, ����: {record.Account}";
        }




        private Label label1;


        private Label label2;

        private string listBox2_SelectedIndexChanged(EmployeeRecord record)
        {
            return $"ID: {record.ID}, ���: {record.Name}, ������� ������: {record.Account}";
        }

        private Label label3;
        private Button RedactAll;

        private void OneThingRedact_Click(object sender, EventArgs e)
        {
            label1.Text = "��� �� ������ ���������������";
            label2.Visible = false;
            textBox1.Visible = false;
            buttonAccept.Visible = false;
            buttonAccept.Text = "���������";
            comboBox1.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("���� ����������");
            comboBox1.Items.Add("��� ����������");
            comboBox1.Items.Add("���� ����������");
            comboBox1.Items.Add("������ ����������");
            comboBox1.Items.Add("���� ����������");
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                // �������� ��������� �������

                if (listBox2.SelectedItem == null)
                {
                    MessageBox.Show("����������, �������� ������ ��� ��������������.", "������");
                    return;
                }
                string selectedItem = comboBox1.SelectedItem.ToString();
                // � ����������� �� ������ ���������� ������ �������� ���������� ��� ����� ����� ������
                switch (selectedItem)
                {
                    case "���� ����������":
                        label2.Text = "������� ����� ���� ����������:";
                        textBox1.Visible = true;
                        break;

                    case "��� ����������":
                        label2.Text = "������� ����� ��� ����������:";
                        textBox1.Visible = true;
                        break;

                    case "���� ����������":
                        label2.Text = "������� ����� ���� ���������� (��-��-����):";
                        textBox1.Visible = true;
                        break;

                    case "������ ����������":
                        label2.Text = "������� ����� ������ (������/�� ������):";
                        textBox1.Visible = true;
                        break;

                    case "���� ����������":
                        label2.Text = "������� ����� ���� ���������� (��-��-����):";
                        textBox1.Visible = true;
                        break;

                    default:
                        label2.Text = "�������� ����� ��� ��������������";
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
                    case "���� ����������":
                        MessageBox.Show($"���� ���������� ������ ��: {inputValue}");
                        break;

                    case "��� ����������":
                        MessageBox.Show($"��� ���������� �������� ��: {inputValue}");
                        break;

                    case "���� ����������":
                        if (IsValidDate(inputValue))
                        {
                            MessageBox.Show($"���� ���������� �������� ��: {inputValue}");
                        }
                        else
                        {
                            MessageBox.Show("������������ ������ ����. ����������� ��-��-����.", "������");
                        }
                        break;

                    case "������ ����������":
                        MessageBox.Show($"������ ���������� ������ ��: {inputValue}");
                        break;

                    case "���� ����������":
                        if (IsValidDate(inputValue))
                        {
                            MessageBox.Show($"���� ���������� �������� ��: {inputValue}");
                        }
                        else
                        {
                            MessageBox.Show("������������ ������ ����. ����������� ��-��-����.", "������");
                        }
                        break;

                    default:
                        MessageBox.Show("�������� ���������� ����� ��� ��������������");
                        break;
                }

                // �������� �������� ����� ����������
                label2.Visible = false;
                textBox1.Visible = false;
                buttonAccept.Visible = false;
            }

            // ����� ��� �������� ������������ ������� ����
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
                    MessageBox.Show("����������, �������� ������ ��� ��������������.", "������");
                    return;
                }

                string selectedItem = listBox2.SelectedItem.ToString();
                int id = ExtractIDFromListBoxItem(selectedItem); // ����� ���������� ID �� ������

                // ������� ������ �� ��������� ������
                if (DataSource.Delete(id))
                {
                    // ������� ������ �� ListBox
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    MessageBox.Show("������ ������� �������.", "�����");
                }
                else
                {
                    MessageBox.Show("������ � ����� ID �� �������.", "������");
                }
            }
        }



    }



        //private static void ViewRecords()
        //{
        //    var records = DataSource.GetAll();
        //    if (records.Count == 0)
        //    {
        //        Console.WriteLine("������� ���.");
        //        return;
        //    }

//    Console.WriteLine("������ �������:");
//    foreach (var record in records)
//    {
//        Console.WriteLine($"ID: {record.ID}, ����: {record.Account}, ���: {record.Name}, ���� ����������: {record.DateStart:dd-MM-yyyy}, ���� ����������: {(record.DateEnd.HasValue ? record.DateEnd.Value.ToString("dd-MM-yyyy") : "�� ������")}, ��������: {record.Description}");
//    }
//}



//public static void DeleteRecord()
//{
//    Console.WriteLine("������� ID ������ ��� ��������:");
//    if (int.TryParse(Console.ReadLine(), out int id))
//    {
//        if (DataSource.Delete(id))
//        {
//            Console.WriteLine("������ ������� �������.");
//        }
//        else
//        {
//            Console.WriteLine("������ � ����� ID �� �������.");
//        }
//    }
//    else
//    {
//        Console.WriteLine("������: �������� ������ ID.");
//    }
//}