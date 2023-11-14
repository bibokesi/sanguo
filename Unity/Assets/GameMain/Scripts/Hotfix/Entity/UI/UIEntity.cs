using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotfix.Entity
{
    /// <summary>
    /// ����UI��ʾ��ʵ��
    /// </summary>
    public class UIEntity : EntityLogicBase
    {
        UIEntityData m_Data;
        public UIEntityData Data { get { return m_Data; } private set { m_Data = value; } }

        public float RotateSpeed = 30;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            Data = (UIEntityData)userData;
            CachedTransform.position = Data.Position;
            CachedTransform.localScale = Data.Scale;

        }
        private void Update()
        {
            CachedTransform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
        }
    }
}