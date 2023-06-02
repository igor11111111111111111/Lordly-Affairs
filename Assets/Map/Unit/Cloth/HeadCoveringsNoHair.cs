namespace Map
{
    public struct HeadCoveringsNoHair : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public HeadCoveringsNoHair(int id)
        {
            _id = id;
        }
    }
}

