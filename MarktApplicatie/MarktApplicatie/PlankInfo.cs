namespace MarktApplicatie
{
    internal class PlankInfo
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return string.Format("Plank Data:\n\tWidth:{0},Height:{1},X:{2},Y:{3}", Width, Height, X, Y);
        }
    }
}