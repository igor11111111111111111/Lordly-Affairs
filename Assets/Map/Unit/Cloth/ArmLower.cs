namespace Map
{
    public struct ArmLower : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public ArmLower(int id)
        {
            _id = id;
        }
    }
}

