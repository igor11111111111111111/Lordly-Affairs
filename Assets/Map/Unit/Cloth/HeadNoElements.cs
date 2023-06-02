namespace Map
{
    public struct HeadNoElements : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public HeadNoElements(int id)
        {
            _id = id;
        }
    }
}

