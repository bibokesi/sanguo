using Main.Runtime;

public partial class UILoadingForm : UIFixBaseForm
{
    private int m_curProgress = 0;
    private bool m_loadComplete = false;

	protected override void OnInit(object userData) {
		base.OnInit(userData);
		GetBindComponents(gameObject);

        m_curProgress = 0;
        m_loadComplete = false;
    }

    public void OnRefreshLoadingProgress(float curProgress, float totalProgress, string tips = "")
    {
        m_Image_ProgressValue.fillAmount = curProgress / totalProgress;
        m_Text_Tips.text = tips;
    }

    private void Update()
    {
        if (m_loadComplete) return;

        m_curProgress += 8;
        if (m_curProgress > 100)
        {
            m_curProgress = 100;
            m_loadComplete = true;
            GameEntry.Event.Fire(null, LoadSceneCompleteEventArgs.Create());
        }
        OnRefreshLoadingProgress(m_curProgress, 100, m_curProgress.ToString() + "%");
    }
}

