namespace EPAM_Task_2._2._1
{
    public class GameField
    {
        public int MapWidth { get; set; }
        public int MapHeigth { get; set; }
        public int BorderSize { get; set; }
        public char BorderSign { get; set; }
        public char[,] gameMap { get; set; }

        public GameField(int mapWidth, int mapHeigth, char borderSign, int borderSize)
        {
            this.BorderSize = borderSize;
            this.MapWidth = mapWidth;
            this.MapHeigth = mapHeigth;
            this.BorderSign = borderSign;
            this.gameMap = new char[mapWidth, mapHeigth];
        }
    }
}
