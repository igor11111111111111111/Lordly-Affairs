namespace Map
{
    public struct Hair : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Hair(int id)
        {
            _id = id;
        }
    }
}

