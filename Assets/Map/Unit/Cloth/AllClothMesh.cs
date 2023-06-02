using System.Linq;
using UnityEngine;

namespace Map
{
    public class AllClothMesh
    {
        public Mesh[] Chr_ArmLowerLeft_Male;
        public Mesh[] Chr_ArmLowerRight_Male;
        public Mesh[] Chr_ArmUpperLeft_Male;
        public Mesh[] Chr_ArmUpperRight_Male;
        public Mesh[] Chr_Eyebrow_Male;
        public Mesh[] Chr_FacialHair_Male;
        public Mesh[] Chr_HandLeft_Male;
        public Mesh[] Chr_HandRight_Male;
        public Mesh[] Chr_Head_Male;
        public Mesh[] Chr_Head_No_Elements_Male;
        public Mesh[] Chr_Hips_Male;
        public Mesh[] Chr_LegLeft_Male;
        public Mesh[] Chr_LegRight_Male;
        public Mesh[] Chr_Torso_Male;
        public Mesh[] Chr_HeadCoverings_Base_Hair;
        public Mesh[] Chr_HeadCoverings_No_Hair;
        public Mesh[] Chr_Hair;

        public AllClothMesh()
        {
            var male = Resources.LoadAll<Mesh>("Male");

            Chr_ArmLowerLeft_Male = male.Where(m => m.name.Contains("Chr_ArmLowerLeft_Male_")).ToArray();
            Chr_ArmLowerRight_Male = male.Where(m => m.name.Contains("Chr_ArmLowerRight_Male_")).ToArray();
            Chr_ArmUpperLeft_Male = male.Where(m => m.name.Contains("Chr_ArmUpperLeft_Male_")).ToArray();
            Chr_ArmUpperRight_Male = male.Where(m => m.name.Contains("Chr_ArmUpperRight_Male_")).ToArray();
            Chr_Eyebrow_Male = male.Where(m => m.name.Contains
              ("Chr_Eyebrow_Male_")).ToArray();
            Chr_FacialHair_Male = male.Where(m => m.name.Contains
              ("Chr_FacialHair_Male_")).ToArray();
            Chr_HandLeft_Male = male.Where(m => m.name.Contains("Chr_HandLeft_Male_")).ToArray();
            Chr_HandRight_Male = male.Where(m => m.name.Contains("Chr_HandRight_Male_")).ToArray();
            Chr_Head_Male = male.Where(m => m.name.Contains
              ("Chr_Head_Male_")).ToArray();
            Chr_Head_No_Elements_Male = male.Where(m => m.name.Contains
              ("Chr_Head_No_Elements_Male_")).ToArray();
            Chr_Hips_Male = male.Where(m => m.name.Contains
              ("Chr_Hips_Male_")).ToArray();
            Chr_LegLeft_Male = male.Where(m => m.name.Contains
              ("Chr_LegLeft_Male_")).ToArray();
            Chr_LegRight_Male = male.Where(m => m.name.Contains
              ("Chr_LegRight_Male_")).ToArray();
            Chr_Torso_Male = male.Where(m => m.name.Contains
              ("Chr_Torso_Male_")).ToArray();

            var allGender = Resources.LoadAll<Mesh>("AllGender");
            Chr_HeadCoverings_Base_Hair = allGender.Where(m => m.name.Contains
              ("Chr_HeadCoverings_Base_Hair_")).ToArray();
            Chr_HeadCoverings_No_Hair = allGender.Where(m => m.name.Contains
              ("Chr_HeadCoverings_No_Hair_")).ToArray();
            Chr_Hair = allGender.Where(m => m.name.Contains
              ("Chr_Hair_")).ToArray();
        }
    }
}

