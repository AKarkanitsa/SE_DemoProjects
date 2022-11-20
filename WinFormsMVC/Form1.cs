namespace WinFormsMVC
{
	class GameForm : Form
	{
		GameModel game;
		TableLayoutPanel table;

		public GameForm(GameModel game)
		{
			this.game = game;
			table = new TableLayoutPanel();
			for (int i = 0; i < game.Size; i++)
			{
				table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / game.Size));
				table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / game.Size));
			}
			for (int column = 0; column < game.Size; column++)
				for (int row = 0; row < game.Size; row++)
				{
					var iRow = row;
					var iColumn = column;
					var button = new Button();
					button.Dock = DockStyle.Fill;
					button.Click += (sender, args) => game.Flip(iRow, iColumn);
					table.Controls.Add(button, iColumn, iRow);
				}
			table.Dock = DockStyle.Fill;
			Controls.Add(table);
			game.StateChanged += (row, column, state) => ((Button)table.GetControlFromPosition(column, row)).BackColor = state ? Color.Black : Color.White;
			game.Start();
		}
	}

}