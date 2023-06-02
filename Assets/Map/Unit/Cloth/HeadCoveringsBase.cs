namespace Map
{
    public struct HeadCoveringsBase : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public HeadCoveringsBase(int id)
        {
            _id = id;
        }
    }
}

