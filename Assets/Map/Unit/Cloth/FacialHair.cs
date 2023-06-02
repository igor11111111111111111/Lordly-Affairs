namespace Map
{
    public struct FacialHair : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public FacialHair(int id)
        {
            _id = id;
        }
    }
}

