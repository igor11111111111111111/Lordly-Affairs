namespace Map
{
    public struct Leg : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Leg(int id)
        {
            _id = id;
        }
    }
}

