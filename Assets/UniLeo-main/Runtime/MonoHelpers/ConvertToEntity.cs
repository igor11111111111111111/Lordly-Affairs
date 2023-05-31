using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
//using NTC.Source.Code.Ecs;

namespace Voody.UniLeo
{
    public enum ConvertMode
    {
        ConvertAndInject,
        ConvertAndDestroy
    }
    public class ConvertToEntity : MonoBehaviour
    {
        public ConvertMode convertMode;

        public void Init()
        {
            var world = WorldHandler.GetWorld();
            if (world != null)
            {
                var entity = world.NewEntity();
                var instantiateComponent = new InstantiateComponent() { gameObject = gameObject };
                entity.Replace(instantiateComponent);
            }
        }
    }
}
