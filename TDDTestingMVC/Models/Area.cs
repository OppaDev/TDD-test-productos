namespace TDDTestingMVC.Models
{
    public class Area
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int AreaOfRectangle()
        {
            return Length * Width;
        }
    }
}
