using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#salffev

namespace yılan oyunu
{
    public partial class MainForm : Form
    {
        private const int CellSize = 16;
        private const int GameWidth = 25;
        private const int GameHeight = 25;
        private const int InitialSnakeLength = 3;
        private const int SnakeSpeed = 100;

        private readonly Random _random = new Random();
        private readonly Timer _timer = new Timer();
        private readonly List<Point> _snake = new List<Point>();
        private Point _food;
        private Point _direction = new Point(1, 0);
        private int _score;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartNewGame();

            _timer.Interval = SnakeSpeed;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void StartNewGame()
        {
            _snake.Clear();
            _snake.Add(new Point(GameWidth / 2, GameHeight / 2));

            for (int i = 1; i < InitialSnakeLength; i++)
            {
                _snake.Add(new Point(_snake.Last().X - 1, _snake.Last().Y));
            }

            _direction = new Point(1, 0);
            _food = GetRandomEmptyCell();
            _score = 0;
        }

        private Point GetRandomEmptyCell()
        {
            var emptyCells = new List<Point>();

            for (int y = 0; y < GameHeight; y++)
            {
                for (int x = 0; x < GameWidth; x++)
                {
                    var cell = new Point(x, y);

                    if (!_snake.Contains(cell))
                    {
                        emptyCells.Add(cell);
                    }
                }
            }

            return emptyCells[_random.Next(emptyCells.Count)];
        }

        private void DrawSnake(Graphics g)
        {
            for (int i = 0; i < _snake.Count; i++)
            {
                var cell = _snake[i];
                var brush = new SolidBrush(i == 0 ? Color.Black : Color.Gray);
                g.FillRectangle(brush, cell.X * CellSize, cell.Y * CellSize, CellSize, CellSize);
            }
        }

        private void DrawFood(Graphics g)
        {
            var brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, _food.X * CellSize, _food.Y * CellSize, CellSize, CellSize);
        }

        private void DrawScore(Graphics g)
        {
            var font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
            var brush = new SolidBrush(Color.Black);
            var scoreText = $"Score: {_score}";
            g.DrawString(scoreText, font, brush, 5, 5);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawSnake(e.Graphics);
            DrawFood(e.Graphics);
            DrawScore(e.Graphics);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var newHead = new Point(_snake.First().X + _direction.X, _snake.First().Y + _direction.Y);

            if (_snake.Contains(newHead) || newHead.X < 0 || newHead.X >= GameWidth || newHead.Y < 0 || newHead.Y >= GameHeight)
            {
                _timer.Stop();
                MessageBox.Show($"Game over")
