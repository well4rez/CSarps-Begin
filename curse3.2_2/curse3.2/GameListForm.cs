using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curse3._2
{
    public partial class GameListForm : Form
    {
        private readonly GameRepository _gameRepository;
        public GameListForm(GameRepository gameRepository)
        {
            InitializeComponent();
            _gameRepository = gameRepository;
            LoadGames();
        }
        public void LoadGames()
        {
            var games = _gameRepository.GetAll();

            dataGridViewGame.DataSource = null;
            dataGridViewGame.DataSource = games;

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void dataGridViewGame_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewGame.Rows[e.RowIndex].Selected = true;
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewGame.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewGame.SelectedRows[0];
                var gameId = selectedRow.Cells["Id"].Value;
                if (gameId != null && int.TryParse(gameId.ToString(), out int id))
                {
                    try
                    {
                        _gameRepository.Delete(id);
                        LoadGames();
                        MessageBox.Show("Игра успешно удалена.");
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка!", "Ошибка!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private int GetGameId()
        {
            if (dataGridViewGame.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewGame.SelectedRows[0];
                var gameId = selectedRow.Cells["Id"].Value;
                return (int)gameId;
            }
            return -1;
        }
            private void addBtn_Click(object sender, EventArgs e)
        {
            AddGameForm form = new AddGameForm(_gameRepository, LoadGames);
            form.Show();
            
        }
        

        private void rBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewGame.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewGame.SelectedRows[0];
                var gameId = selectedRow.Cells["Id"].Value;
                if (gameId != null && int.TryParse(gameId.ToString(), out int id))
                {
                    try
                    {
                        RedGameForm form = new RedGameForm(_gameRepository, GetGameId(), LoadGames);
                        form.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка!", "Ошибка!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}