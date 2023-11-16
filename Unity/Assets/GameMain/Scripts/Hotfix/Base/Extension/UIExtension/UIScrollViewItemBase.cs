using UnityEngine;

public partial class UIScrollViewItemBase : MonoBehaviour
{
    public int m_ItemIndex;
    public virtual void OnInit(object userData) { }

    public virtual void SetItemData(int itemIndex, object itemData)
    {
        m_ItemIndex = itemIndex;
    }
}
