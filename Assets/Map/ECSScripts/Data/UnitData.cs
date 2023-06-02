using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ECSTemplates;

namespace Map
{
    [CreateAssetMenu]
    public class UnitData : ScriptableObject
    {
        public GameObject Prefab;
        //[HideInInspector] public List<Mesh> Mesh;
          
        public void Init()
        {
            //Mesh = new List<Mesh>();
            //var foundedMesh = Resources.LoadAll<Mesh>("Units");
            //foreach (var mesh in foundedMesh)
            //{ 
            //    Mesh.Add(mesh);
            //}
        }
    }
}