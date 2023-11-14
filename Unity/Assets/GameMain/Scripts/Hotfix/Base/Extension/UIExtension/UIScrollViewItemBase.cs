using System;
using Hotfix;
using UnityEngine;

namespace Hotfix.UI 
{
    public partial class UIScrollViewItemBase : MonoBehaviour
    {
        public int m_ItemIndex;
        public virtual void OnInit(object userData){}

        public virtual void SetItemData(int itemIndex, object itemData)
        {
            m_ItemIndex = itemIndex;
        }
    }
}