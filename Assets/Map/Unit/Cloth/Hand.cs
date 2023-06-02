namespace Map
{
    public struct Hand : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Hand(int id)
        {
            _id = id;
        }
    }
}

