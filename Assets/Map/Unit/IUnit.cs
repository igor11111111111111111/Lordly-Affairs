using System.Collections.Generic;

namespace Map
{
    public interface IUnit
    {
        int Price { get; }
        int Salary { get;}
        int Morale { get; set; }

        List<ICloth> AllCloth { get; }
    } 
}