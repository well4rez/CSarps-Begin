using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curse3._2
{
    public partial class RedGameForm : Form
    {
        private readonly GameRepository _gameRepository;
        private readonly int _gameId;
        private Action _loadgames;
        public RedGameForm(GameRepository gameRepository, int gameId, Action loadgames)
        {

            InitializeComponent();

            _loadgames = loadgames;
            _gameRepository = gameRepository;
            _gameId = gameId;

            var game = gameRepository.Get(_gameId);
            textBox1.Text = game.GameName;

        }
        
        private void redbut_Click(object sender, EventArgs e)
        {
            try
            {
                Game game = new()
                {
                    Id = _gameId,
                    GameName = textBox1.Text,
                    PlayerCount = Convert.ToInt32(numericUpDown1.Value),
                    IsMultiplayer = checkBox1.Checked
                };
                _gameRepository.Update(game);
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

