using System.Collections.Generic;
using System.Linq;

namespace Map
{
    public class UnitsDictionary
    {
        //public Dictionary<string, List<IUnit>> Dictionary => _dictionary;
        public Dictionary<string, List<IUnit>> Dictionary = new Dictionary<string, List<IUnit>>();
         
        public void Add(IUnit unit)
        {
            var type = unit.GetType().Name;
            if (!Dictionary.ContainsKey(type))
            {
                Dictionary.Add(type, new List<IUnit>());
            }
            Dictionary[type].Add(unit);
        }

        public bool Remove(string key)
        {
            if (!Dictionary.ContainsKey(key))
                return false;
            Dictionary[key].RemoveAt(Dictionary[key].Count - 1);
            if(Dictionary[key].Count == 0)
            {
                Dictionary.Remove(key);
            }
            return true;
        }

        public List<IUnit> Get<T>() where T: IUnit
        {
            return Dictionary[typeof(T).Name];
        }

        public int Count()
        {
            return Dictionary.Values.Sum(list => list.Count());
        }

        public bool Contain(string key)
        {
            return Dictionary.ContainsKey(key);
        }

        public int AllSalary()
        {
            return Dictionary.Values.Sum(list => list.Sum(i => i.Salary));
        }

        public int AllMorale()
        {
            return Dictionary.Values.Sum(list => list.Sum(i => i.Morale));
        }
    }
}

