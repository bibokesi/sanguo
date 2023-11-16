using Main.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Runtime
{
    public partial class UIInitForm : UIBaseForm
    {
        private static UIInitForm instance;

        public static UIInitForm Instance
        {
            get { return instance; }
        }

        public RectTransform m_Transform_UILaunch;
        public RectTransform m_Transform_UILoading;
        public RectTransform m_Transform_UIDialog;

        public UIButtonSuper m_Btn_bg;
        public TextMeshProUGUI m_TxtM_Content;
        public TextMeshProUGUI m_TxtM_Tilte;
        public UIButtonSuper m_Btn_Sure;
        public TextMeshProUGUI m_TxtM_Sure;
        public UIButtonSuper m_Btn_Cancel;
        public TextMeshProUGUI m_TxtM_Cancel;
        public UIButtonSuper m_Btn_Other;
        public TextMeshProUGUI m_TxtM_Other;

        public RectTransform m_Trans_Progress;
        public Image m_Img_ProgressValue;
        public TextMeshProUGUI m_TxtM_Tips;

        private UIDialogParams m_DialogParams;

        private void Awake()
        {
            OnInit(this);
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            instance = this;

            m_Btn_bg.onClick.AddListener(Btn_bgEvent);
            m_Btn_Sure.onClick.AddListener(Btn_SureEvent);
            m_Btn_Cancel.onClick.AddListener(Btn_CancelEvent);
            m_Btn_Other.onClick.AddListener(Btn_OtherEvent);

            CloseAll();
        }

        private void CloseAll()
        {
            m_Transform_UILaunch.gameObject.SetActive(true);
            m_Transform_UILoading.gameObject.SetActive(false);
            m_Transform_UIDialog.gameObject.SetActive(false);
        }

        public void OpenLaunch(bool isLandscape = true)
        {
            Logger.Debug<UIInitForm>("OpenLaunch");
            m_Transform_UILaunch.gameObject.SetActive(true);
        }

        public void CloseLaunch()
        {
            m_Transform_UILaunch.gameObject.SetActive(false);
        }

        public void OpenLoading(bool isOpen)
        {
            m_Transform_UILoading.gameObject.SetActive(isOpen);
            m_Transform_UILaunch.gameObject.SetActive(false);
        }

        public void RefreshLoadingProgress(float curProgress, float totalProgress, string tips = "")
        {
            m_Img_ProgressValue.fillAmount = curProgress / totalProgress;
            m_TxtM_Tips.text = tips;
        }

        public void OpenUIDialog(object userData)
        {
            m_DialogParams = (UIDialogParams)userData;
            if (m_DialogParams == null)
            {
                m_Transform_UIDialog.gameObject.SetActive(false);
                return;
            }
           
            m_Transform_UIDialog.gameObject.SetActive(true);

            m_TxtM_Tilte.text = m_DialogParams.Title;
            m_TxtM_Content.text = m_DialogParams.Message;
            m_TxtM_Sure.text = m_DialogParams.ConfirmText;
            m_TxtM_Cancel.text = m_DialogParams.CancelText;
            m_TxtM_Other.text = m_DialogParams.OtherText;
            m_Btn_Sure.gameObject.SetActive(m_DialogParams.Mode >= 1);
            m_Btn_Cancel.gameObject.SetActive(m_DialogParams.Mode >= 2);
            m_Btn_Other.gameObject.SetActive(m_DialogParams.Mode >= 3);
        }

        private void Btn_bgEvent()
        {
            m_DialogParams.OnClickBackground?.Invoke(m_DialogParams.UserData);
            m_Transform_UIDialog.gameObject.SetActive(false);
        }

        private void Btn_SureEvent()
        {
            m_DialogParams.OnClickConfirm?.Invoke(m_DialogParams.UserData);
            m_Transform_UIDialog.gameObject.SetActive(false);
        }

        private void Btn_CancelEvent()
        {
            m_DialogParams.OnClickCancel?.Invoke(m_DialogParams.UserData);
            m_Transform_UIDialog.gameObject.SetActive(false);
        }

        private void Btn_OtherEvent()
        {
            m_DialogParams.OnClickOther?.Invoke(m_DialogParams.UserData);
            m_Transform_UIDialog.gameObject.SetActive(false);
        }
    }
}
