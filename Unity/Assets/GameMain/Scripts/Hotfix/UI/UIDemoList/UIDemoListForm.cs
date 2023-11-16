using SuperScrollView;
using System.Collections.Generic;


public partial class UIDemoListForm : UIFixBaseForm
{
    List<UIDemoItemData> m_DataList = null;

    protected override void OnInit(object userData) {
			base.OnInit(userData);
			GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
		m_Button_Back.onClick.AddListener(Button_BackEvent);
        /*--------------------Auto generate end button listener.Do not modify!----------------------*/

        //获取数据, 设置ListView
        m_DataList = new List<UIDemoItemData>();
        m_LoopListView2_ListView.InitListView(m_DataList.Count, OnGetItemByIndex);
    }


    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        UIDemoItemData data1 = new UIDemoItemData("SelectModeImage01", "", "aaa", 1);
        m_DataList.Add(data1);

        UIDemoItemData data2 = new UIDemoItemData("SelectModeImage02", "", "bbb", 2);
        m_DataList.Add(data2);

        UIDemoItemData data3 = new UIDemoItemData("SelectModeImage03", "", "ccc", 3);
        m_DataList.Add(data3);

        UIDemoItemData data4 = new UIDemoItemData("SelectModeImage01", "", "ddd", 4);
        m_DataList.Add(data4);

        UIDemoItemData data5 = new UIDemoItemData("SelectModeImage02", "", "eee", 5);
        m_DataList.Add(data5);

        UIDemoItemData data6 = new UIDemoItemData("SelectModeImage03", "", "fff", 6);
        m_DataList.Add(data6);

        UIDemoItemData data7 = new UIDemoItemData("SelectModeImage01", "", "ggg", 7);
        m_DataList.Add(data7);

        UIDemoItemData data8 = new UIDemoItemData("SelectModeImage02", "", "hhh", 8);
        m_DataList.Add(data8);

        UIDemoItemData data9 = new UIDemoItemData("SelectModeImage03", "", "iii", 9);
        m_DataList.Add(data9);

        UIDemoItemData data10 = new UIDemoItemData("SelectModeImage01", "", "jjj", 10);
        m_DataList.Add(data10);

        m_LoopListView2_ListView.SetListItemCount(m_DataList.Count, false);
    }

    LoopListViewItem2 OnGetItemByIndex(LoopListView2 listView, int index)
    {
        if (index < 0 || index >= m_DataList.Count) return null;

        UIDemoItemData itemData = m_DataList[index];
        if (itemData == null) return null;

        LoopListViewItem2 item = listView.NewListViewItem("ItemPrefab");
        UIDemoListItem itemScript = item.GetComponent<UIDemoListItem>();
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

