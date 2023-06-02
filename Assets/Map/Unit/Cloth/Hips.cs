namespace Map
{
    public struct Hips : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Hips(int id)
        {
            _id = id;
        }
    }
}

