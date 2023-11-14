using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hotfix.UI
{
    public class UIDemoListItem : MonoBehaviour
    {
        public Image mBgImg;
        public Button mBtn;
        public Image mIconImg;
        public TMP_Text mTitleText;

        int mItemDataIndex = -1;
        Action<int> mClickHandler;

        public void Init()
        {
            mBtn.onClick.AddListener(OnButtonClicked);
        }

        public void SetClickCallBack(Action<int> clickHandler)
        {
            mClickHandler = clickHandler;
        }

        public void SetItemData(int index)
        {
            mItemDataIndex = index;
        }

        void OnButtonClicked()
        {
            if (mClickHandler != null)
                mClickHandler(mItemDataIndex);
        }
    }

    public class UIDemoItemData
    {
        public string bg;
        public string icon;
        public string title;
        public int index;

        public UIDemoItemData(string bg, string icon, string title, int index)
        {
            this.bg = bg;
            this.icon = icon;
            this.title = title;
            this.index = index;
        }
    }
}