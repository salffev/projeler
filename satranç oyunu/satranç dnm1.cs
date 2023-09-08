using System;
# salffev

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Satranç tahtasını oluşturun
            ChessBoard board = new ChessBoard();

            // Tahta üzerinde hareket eden ilk siyah ve beyaz taşları yerleştirin
            board.SetPiece("a8", new Rook(PieceColor.Black));
            board.SetPiece("h8", new Rook(PieceColor.Black));
            board.SetPiece("a1", new Rook(PieceColor.White));
            board.SetPiece("h1", new Rook(PieceColor.White));

            // Oyunu başlatın
            while (!board.IsGameOver())
            {
                Console.Clear();
                Console.WriteLine(board.ToString());

                // Oyuncu hareket yapın
                Console.WriteLine("Lütfen hareket etmek istediğiniz taşın konumunu girin: ");
                string fromPosition = Console.ReadLine();
                Console.WriteLine("Lütfen taşı taşımak istediğiniz konumu girin: ");
                string toPosition = Console.ReadLine();

                // Taşı hareket ettirin ve sonucu kontrol edin
                if (board.MovePiece(fromPosition, toPosition))
                {
                    Console.WriteLine("Taş hareketi başarılı. Sıra rakibe geçiyor...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Taş hareketi geçersiz, lütfen tekrar deneyin...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Oyun bitti. Kazanan: " + board.GetWinner().ToString());
            Console.ReadKey();
        }
    }
}
