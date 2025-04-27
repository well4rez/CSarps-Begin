using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curse3._2
{
    public partial class AddGameForm : Form
    {
        private readonly GameRepository _gameRepository;
        private Action _loadgames;
        public AddGameForm(GameRepository gameRepository, Action loadgames)
        {
            InitializeComponent();
            _gameRepository = gameRepository;
            _loadgames = loadgames;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Название не должно быть пустым.", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                Game game = new()
                {
                    GameName = textBox1.Text,
                    PlayerCount = Convert.ToInt32(numericUpDown1.Value),
                    IsMultiplayer = checkBox1.Checked
                };
                _gameRepository.Add(game);
                _loadgames.Invoke();
                this.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка!", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}
