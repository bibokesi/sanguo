using UnityEngine;

namespace Hotfix.Entity
{
    public class UIEntityData : EntityData
    {
        private Vector3 m_Scale;

        public Vector3 Scale
        {
            get => m_Scale;
            set => m_Scale = value;
        }

        public UIEntityData(int entityId, int typeId, string groupName, string assetName) : base(entityId, typeId, groupName, assetName)
        {

        }
    }
}