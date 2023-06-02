namespace Map
{
    public struct Eyebrow : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Eyebrow(int id)
        {
            _id = id;
        }
    }
}

