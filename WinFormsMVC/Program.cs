namespace WinFormsMVC
{
	class GameModel
	{
		bool[,] game;
		public readonly int Size;

		public GameModel(int size)
		{
			Size = size;
			game = new bool[size, size];
		}

		public void Start()
		{
			for (int row = 0; row < Size; row++)
				for (int column = 0; column < Size; column++)
					SetState(row, column, (row + column) % 2 == 0);
		}

		void SetState(int row, int column, bool state)
		{
			game[row, column] = state;
			if (StateChanged != null) StateChanged(row, column, game[row, column]);
		}

		void FlipState(int row, int column)
		{
			SetState(row, column, !game[row, column]);
		}

		public void Flip(int row, int column)
		{
			for (int iRow = 0; iRow < Size; iRow++)
				if (iRow != row) FlipState(iRow, column);
			for (int iColumn = 0; iColumn < Size; iColumn++)
				if (iColumn != column) FlipState(row, iColumn);
			FlipState(row, column);
		}

		public event Action<int, int, bool> StateChanged;
	}
	internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new GameForm(new GameModel(5)));
        }
    }
}