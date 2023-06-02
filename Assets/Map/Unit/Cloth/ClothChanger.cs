using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class ClothChanger : MonoBehaviour
    {
        [SerializeField] public SkinnedMeshRenderer Chr_ArmLowerLeft_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_ArmLowerRight_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_ArmUpperLeft_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_ArmUpperRight_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_Eyebrow_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_FacialHair_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_HandLeft_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_HandRight_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_Head_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_Head_No_Elements_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_Hips_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_LegLeft_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_LegRight_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_Torso_Male;
        [SerializeField] public SkinnedMeshRenderer Chr_HeadCoverings_Base_Hair;
        [SerializeField] public SkinnedMeshRenderer Chr_HeadCoverings_No_Hair;
        [SerializeField] public SkinnedMeshRenderer Chr_Hair;

        private AllClothMesh _allClothMesh;
        private System.Random _random;
        private List<ICloth> _unitCloth;

        public void Set(List<ICloth> unitCloth, AllClothMesh allClothMesh)
        {
            _unitCloth = unitCloth;
            _allClothMesh = allClothMesh;
            _random = new System.Random();
            
            SetArm();
            SetHand();
            SetLeg();
            SetHips();
            SetTorso();
            int idHeadNoElements = SetHeadNoElements();
            int idHeadCoveringsBase = SetHeadCoveringsBase();
            int idHeadCoveringsNoHair = SetHeadCoveringsNoHair();
            SetHair(idHeadNoElements, idHeadCoveringsBase, idHeadCoveringsNoHair);
        }

        public int Set<T>(ref int id)
        {
            if (typeof(T).Equals(typeof(Head)))
            {
                if (id == _allClothMesh.Chr_Head_Male.Length)
                    id = 1;

                if (id == 0)
                    id = _allClothMesh.Chr_Head_Male.Length - 1;
                Chr_Head_Male.sharedMesh = _allClothMesh.Chr_Head_Male[id];
            }
            else if(typeof(T).Equals(typeof(FacialHair)))
            {
                if (id == _allClothMesh.Chr_FacialHair_Male.Length)
                    id = 0;

                if (id == -1)
                    id = _allClothMesh.Chr_FacialHair_Male.Length - 1;
                Chr_FacialHair_Male.sharedMesh = _allClothMesh.Chr_FacialHair_Male[id];
            }
            else if (typeof(T).Equals(typeof(Eyebrow)))
            {
                if (id == _allClothMesh.Chr_Eyebrow_Male.Length)
                    id = 0;

                if (id == -1)
                    id = _allClothMesh.Chr_Eyebrow_Male.Length - 1;
                Chr_Eyebrow_Male.sharedMesh = _allClothMesh.Chr_Eyebrow_Male[id];
            }
            else if(typeof(T).Equals(typeof(Hair)))
            {
                if (id == _allClothMesh.Chr_Hair.Length)
                    id = 0;

                if (id == -1)
                    id = _allClothMesh.Chr_Hair.Length - 1;
                Chr_Hair.sharedMesh = _allClothMesh.Chr_Hair[id];
            }

            
            return id;
        }

        private void SetHead(List<ICloth> unitCloth)
        {
            var Head = unitCloth.Where(c => c is Head).ToArray();
            Chr_Head_Male.sharedMesh = _allClothMesh.Chr_Head_Male[GetId(Head)];
        }

        private void Eyebrow(List<ICloth> unitCloth)
        {
            var Eyebrow = unitCloth.Where(c => c is Eyebrow).ToArray();
            int id = GetId(Eyebrow);
            Chr_Eyebrow_Male.sharedMesh = _allClothMesh.Chr_Eyebrow_Male[id];
        }

        private void FacialHair(List<ICloth> unitCloth)
        {
            var FacialHair = unitCloth.Where(c => c is FacialHair).ToArray();
            int id = GetId(FacialHair);
            Chr_FacialHair_Male.sharedMesh = _allClothMesh.Chr_FacialHair_Male[id];
        }

        private void SetHair(int idHeadNoElements, int idHeadCoveringsBase, int idHeadCoveringsNoHair)
        {
            if (idHeadNoElements == 0 &&
                idHeadCoveringsBase == 0 &&
                idHeadCoveringsNoHair == 0)
            {
                var hairs = _unitCloth.Where(c => c is Hand).ToArray();
                if (hairs.Length == 0)
                    SetRandomHair();
                else
                    SetHair();
            }
            else
            {
                Chr_Hair.sharedMesh = _allClothMesh.Chr_Hair[0];
            }
        }

        private void SetHair()
        {
            var Hair = _unitCloth.Where(c => c is Hair).ToArray();
            Chr_Hair.sharedMesh =
                _allClothMesh.Chr_Hair[GetId(Hair)];
        }

        private int SetHeadCoveringsNoHair()
        {
            var HeadCoveringsNoHair = _unitCloth.Where(c => c is HeadCoveringsNoHair).ToArray();
            int idHeadCoveringsNoHair = GetId(HeadCoveringsNoHair);
            Chr_HeadCoverings_No_Hair.sharedMesh =
                    _allClothMesh.Chr_HeadCoverings_No_Hair[idHeadCoveringsNoHair];

            return idHeadCoveringsNoHair;
        }

        private int SetHeadCoveringsBase()
        {
            var HeadCoveringsBase = _unitCloth.Where(c => c is HeadCoveringsBase).ToArray();
            int idHeadCoveringsBase = GetId(HeadCoveringsBase);
            Chr_HeadCoverings_Base_Hair.sharedMesh =
                    _allClothMesh.Chr_HeadCoverings_Base_Hair[idHeadCoveringsBase];

            return idHeadCoveringsBase;
        }

        private void SetTorso()
        {
            var Torso = _unitCloth.Where(c => c is Torso).ToArray();
            Chr_Torso_Male.sharedMesh =
                _allClothMesh.Chr_Torso_Male[GetId(Torso)];
        }

        private void SetHips()
        {
            var Hips = _unitCloth.Where(c => c is Hips).ToArray();
            Chr_Hips_Male.sharedMesh =
                _allClothMesh.Chr_Hips_Male[GetId(Hips)];
        }

        private int SetHeadNoElements()
        {
            var Head_No_Elements = _unitCloth.Where(c => c is HeadNoElements).ToArray();
            int idHeadNoElements = GetId(Head_No_Elements);
            Chr_Head_No_Elements_Male.sharedMesh =
                    _allClothMesh.Chr_Head_No_Elements_Male[idHeadNoElements];

            if (idHeadNoElements == 0)
            {
                //SetHead(unitCloth);
                //Eyebrow(unitCloth);
                //FacialHair(unitCloth);
                SetRandomHead();
                SetRandomEyebrow();
                SetRandomFacialHair();
            }
            else
            {
                Chr_Head_Male.sharedMesh = _allClothMesh.Chr_Head_Male[0];
                Chr_Eyebrow_Male.sharedMesh = _allClothMesh.Chr_Eyebrow_Male[0];
                Chr_FacialHair_Male.sharedMesh = _allClothMesh.Chr_FacialHair_Male[0];
            }

            return idHeadNoElements;
        }

        private void SetLeg()
        {
            int id;

            var Leg = _unitCloth.Where(c => c is Leg).ToArray();
            id = GetId(Leg);
            Chr_LegLeft_Male.sharedMesh =
                _allClothMesh.Chr_LegLeft_Male[id];
            Chr_LegRight_Male.sharedMesh =
                _allClothMesh.Chr_LegRight_Male[id];
        }

        private void SetHand()
        {
            int id;

            var Hand = _unitCloth.Where(c => c is Hand).ToArray();
            id = GetId(Hand);
            Chr_HandLeft_Male.sharedMesh =
                _allClothMesh.Chr_HandLeft_Male[id];
            Chr_HandRight_Male.sharedMesh =
                _allClothMesh.Chr_HandRight_Male[id];
        }

        private void SetArm()
        {
            int id;

            var armLover = _unitCloth.Where(c => c is ArmLower).ToArray();
            id = GetId(armLover);
            Chr_ArmLowerLeft_Male.sharedMesh =
                _allClothMesh.Chr_ArmLowerLeft_Male[id];
            Chr_ArmLowerRight_Male.sharedMesh =
                _allClothMesh.Chr_ArmLowerRight_Male[id];

            var armUpper = _unitCloth.Where(c => c is ArmUpper).ToArray();
            id = GetId(armUpper);
            Chr_ArmUpperLeft_Male.sharedMesh =
                _allClothMesh.Chr_ArmUpperLeft_Male[id];
            Chr_ArmUpperRight_Male.sharedMesh =
                _allClothMesh.Chr_ArmUpperRight_Male[id];
        }

        private void SetRandomHead()
        {
            Chr_Head_Male.sharedMesh = GetRandMeshExcludeZero(_allClothMesh.Chr_Head_Male);
        }

        private void SetRandomEyebrow()
        {
            Chr_Eyebrow_Male.sharedMesh = GetRandMesh(_allClothMesh.Chr_Eyebrow_Male);
        }

        private void SetRandomHair()
        {
            Chr_Hair.sharedMesh = GetRandMesh(_allClothMesh.Chr_Hair);
        }

        private void SetRandomFacialHair()
        {
            Chr_FacialHair_Male.sharedMesh = GetRandMesh(_allClothMesh.Chr_FacialHair_Male);
        }

        private int GetId(ICloth[] cloth)
        {
            if (cloth.Length == 0)
                return 0;
            return cloth[_random.Next(cloth.Length)].Id;
        }

        private Mesh GetRandMesh(Mesh[] mesh)
        {
            return mesh[_random.Next(mesh.Length - 1)];
        }

        private Mesh GetRandMeshExcludeZero(Mesh[] mesh)
        {
            return mesh[_random.Next(1, mesh.Length - 1)];
        }
    }
}

