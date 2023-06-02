namespace Map
{
    public struct Head : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Head(int id)
        {
            _id = id;
        }
    }
}

