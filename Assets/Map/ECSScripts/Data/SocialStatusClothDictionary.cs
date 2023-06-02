using UnityEngine;
using System;
using ECSTemplates;
using System.Collections.Generic;

namespace Map
{
    [Serializable] 
    public class SocialStatusClothDictionary
    {
        public SocialStatus SocialStatus;
        public List<ICloth> Cloth;

        public SocialStatusClothDictionary(SocialStatus socialStatus, List<ICloth> cloth)
        {
            SocialStatus = socialStatus;
            Cloth = cloth;
        }
    }
}

