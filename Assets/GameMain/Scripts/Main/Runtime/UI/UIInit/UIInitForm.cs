using Main.Runtime;
namespace Main.Runtime.UI
{

    public partial class UIInitForm : UIBaseForm
    {
        private static UIInitForm instance;

        public static UIInitForm Instance
        {
            get { return instance; }
        }

        public UILoadingForm UILoadingForm;
        public UIDialogForm UIDialogForm;
        private void Awake()
        {
            OnInit(this);
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            GetBindComponents(gameObject);
            instance = this;
            UILoadingForm = m_Transform_UILoadingForm.GetComponent<UILoadingForm>();
            UIDialogForm = m_Transform_UIDialogForm.GetComponent<UIDialogForm>();
            /*--------------------Auto generate start button listener.Do not modify!--------------------*/
            /*--------------------Auto generate end button listener.Do not modify!----------------------*/
            CloseAllView();
            OnOpenLoadingForm(true);
        }

        private void CloseAllView()
        {
            m_Transform_UILaunchView.gameObject.SetActive(true);
            m_Transform_UILoadingForm.gameObject.SetActive(false);
            m_Transform_UIDialogForm.gameObject.SetActive(false);
        }
        public void OnOpenLaunchView(bool isLandscape = true)
        {
            Logger.Debug<UIInitForm>("OnOpenLaunchView");
            m_Transform_UILaunchView.gameObject.SetActive(true);
        }
        public void OnCloseLaunchView()
        {
            m_Transform_UILaunchView.gameObject.SetActive(false);
        }
        public void OnOpenLoadingForm(bool isOpen)
        {
            m_Transform_UILoadingForm.gameObject.SetActive(isOpen);
            m_Transform_UILaunchView.gameObject.SetActive(false);
        }
        public void OnRefreshLoadingProgress(float curProgress, float totalProgress, string tips = "")
        {
            UILoadingForm.RefreshProgress(curProgress, totalProgress, tips);
        }
        public void OnOpenUIDialogForm(object userData)
        {
            m_Transform_UIDialogForm.gameObject.SetActive(true);
            UIDialogForm.Open(userData);
        }
        /*--------------------Auto generate footer.Do not add anything below the footer!------------*/
    }
}
