using Hotfix;
using SuperScrollView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotfix.UI
{
    public partial class UIDemoGridListForm : UIFixBaseForm
    {
        List<UIDemoGridItemData> m_DataList = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            GetBindComponents(gameObject);

            /*--------------------Auto generate start button listener.Do not modify!--------------------*/
            m_Button_Back.onClick.AddListener(Button_BackEvent);
            /*--------------------Auto generate end button listener.Do not modify!----------------------*/

            //获取数据, 设置ListView
            m_DataList = new List<UIDemoGridItemData>();
            m_LoopGridView_ListView.InitGridView(m_DataList.Count, OnGetItemByIndex);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            UIDemoGridItemData data1 = new UIDemoGridItemData("SelectModeImage01", "", "aaa", 1);
            m_DataList.Add(data1);

            UIDemoGridItemData data2 = new UIDemoGridItemData("SelectModeImage02", "", "bbb", 2);
            m_DataList.Add(data2);

            UIDemoGridItemData data3 = new UIDemoGridItemData("SelectModeImage03", "", "ccc", 3);
            m_DataList.Add(data3);

            UIDemoGridItemData data4 = new UIDemoGridItemData("SelectModeImage01", "", "ddd", 4);
            m_DataList.Add(data4);

            UIDemoGridItemData data5 = new UIDemoGridItemData("SelectModeImage02", "", "eee", 5);
            m_DataList.Add(data5);

            UIDemoGridItemData data6 = new UIDemoGridItemData("SelectModeImage03", "", "fff", 6);
            m_DataList.Add(data6);

            UIDemoGridItemData data7 = new UIDemoGridItemData("SelectModeImage01", "", "ggg", 7);
            m_DataList.Add(data7);

            UIDemoGridItemData data8 = new UIDemoGridItemData("SelectModeImage02", "", "hhh", 8);
            m_DataList.Add(data8);

            UIDemoGridItemData data9 = new UIDemoGridItemData("SelectModeImage03", "", "iii", 9);
            m_DataList.Add(data9);

            UIDemoGridItemData data10 = new UIDemoGridItemData("SelectModeImage01", "", "jjj", 10);
            m_DataList.Add(data10);

            m_LoopGridView_ListView.SetListItemCount(m_DataList.Count, false);
        }

        LoopGridViewItem OnGetItemByIndex(LoopGridView gridView, int index, int row, int column)
        {
            if (index < 0 || index >= m_DataList.Count) return null;

            UIDemoGridItemData itemData = m_DataList[index];
            if (itemData == null) return null;

            LoopGridViewItem item = gridView.NewListViewItem("ItemPrefab");
            UIDemoGridListItem itemScript = item.GetComponent<UIDemoGridListItem>();
            if (!item.IsInitHandlerCalled)
            {
                item.IsInitHandlerCalled = true;
                itemScript.Init();
                itemScript.SetClickCallBack(OnListViewItemClicked);
                itemScript.SetItemData(index);
            }

            string collectionPath = AssetUtility.UI.GetSpriteCollectionPath("SelectMode");
            string spriteBgPath = AssetUtility.UI.GetSpritePath($"SelectMode/{itemData.bg}");
            string spriteIconPath = AssetUtility.UI.GetSpritePath($"SelectMode/{itemData.icon}");

            itemScript.mBgImg.SetSprite(collectionPath, spriteBgPath);
            itemScript.mIconImg.SetSprite(collectionPath, spriteIconPath);

            itemScript.mTitleText.text = itemData.title;

            return item;
        }

      

        void OnListViewItemClicked(int index)
        {
            GameEntry.UI.OpenTips(index.ToString());
        }

        private void Button_BackEvent()
        {
            Close();
        }
        /*--------------------Auto generate footer.Do not add anything below the footer!------------*/
    }
}
