namespace Map
{
    public struct Torso : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Torso(int id)
        {
            _id = id;
        }
    }
}

