
using System;
using UnityEngine;

public class CustomSettingsWindow : GameMainCustomSettingWindowHelper
{
    private Vector2 m_LogScrollPosition = Vector2.zero;

    private string m_QuickLevelId;

    private string m_ScriptType;
    private string m_Param1;
    private string m_Param2;
    private string m_Param3;
    private string m_Param4;
    private string m_Param5;
    private string m_Param6;

    private string m_SceneWidth = "1650";
    private string m_SceneHigh = "750";

    private string m_GameSpeed;
    private string m_SyncSpeed;

    private string m_MonsterId = "";
    private string m_MonsterLabel = "99";
    private string m_MonsterPosx = "300";
    private string m_MonsterPosy = "0";
    private string m_MonsterPosz = "300";

    private string m_GameVersion;

    public void OnDrawScrollableWindow()
    {
        if (m_GameVersion == null)
        {
            //m_GameVersion = GameEntry.Builtin.ResourceVersion;
        }
        GUILayout.Label("<b>Custom</b>");
        GUILayout.BeginVertical("box");
        {
            m_LogScrollPosition = GUILayout.BeginScrollView(m_LogScrollPosition);
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label("�汾��", GUILayout.Height(30f));
                    m_GameVersion = GUILayout.TextField(m_GameVersion, GUILayout.Height(30f));
                    //if (GUILayout.Button("ȷ���޸�", GUILayout.Height(30f)))
                    //{
                    //    GameEntry.Builtin.ResourceVersion = m_GameVersion;
                    //}

                    GUILayout.Label("��Ϸ�ٶ�", GUILayout.Height(30f));

                    if (GUILayout.Button("+", GUILayout.Height(30f)))
                    {
                        //GameEntry.Base.GameSpeed += 0.5f;
                    }
                    if (GUILayout.Button("N", GUILayout.Height(30f)))
                    {
                        //GameEntry.Base.GameSpeed = 1;
                    }
                    if (GUILayout.Button("-", GUILayout.Height(30f)))
                    {
                        //GameEntry.Base.GameSpeed -= 0.5f;
                    }

                    //m_GameSpeed = GameEntry.Base.GameSpeed.ToString();
                    //string newGameSpeed = GUILayout.TextField(m_GameSpeed, GUILayout.Height(30f));
                    //if (newGameSpeed != m_GameSpeed)
                    //{
                    //    //GameEntry.Base.GameSpeed = newGameSpeed.ToFloat();
                    //}

                    GUILayout.Label("ͬ���ٶ�", GUILayout.Height(30f));

                    //m_SyncSpeed = GlobalConst.SyncFrequencySpan.ToString();
                    //string newSyncSpeed = GUILayout.TextField(m_SyncSpeed, GUILayout.Height(30f));
                    //if (newSyncSpeed != m_SyncSpeed)
                    //{
                    //    GlobalConst.SyncFrequencySpan = newSyncSpeed.ToFloat();
                    //}


                    //if (GameEntry.SceneData.AutoFight)
                    //{
                    //    GUI.color = Color.yellow;
                    //    if (GUILayout.Button("�ر��Զ�ս��", GUILayout.Height(30f)))
                    //    {
                    //        GameEntry.SceneData.AutoFight = false;
                    //    }
                    //    GUI.color = Color.white;
                    //}


                    if (GUILayout.Button("��ӡ��ɫ����", GUILayout.Height(30f)))
                    {
                        //Character character = GameEntry.Character.GetMainPlayer();
                        //if (character)
                        //{
                        //    Log.Info("{0}|{1}|{2}", character.CachedTransform.position.x, character.CachedTransform.position.y, character.CachedTransform.position.z);
                        //}
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                {
                    //if (GlobalCacheValueManager.IsCloseGuide)
                    //{
                    //    GUI.color = Color.yellow;
                    //    if (GUILayout.Button("��������", GUILayout.Height(30f)))
                    //    {
                    //        GlobalCacheValueManager.IsCloseGuide = false;
                    //        PlayerPrefs.SetInt("CustomSettingWindow_��������", 0);
                    //    }
                    //    GUI.color = Color.white;
                    //}
                    //else
                    //{
                    //    if (GUILayout.Button("�ر�����", GUILayout.Height(30f)))
                    //    {
                    //        GlobalCacheValueManager.IsCloseGuide = true;
                    //        PlayerPrefs.SetInt("CustomSettingWindow_��������", 1);
                    //    }
                    //}

                    GUILayout.Label("�ؿ�Id", GUILayout.Height(30f));
                    m_QuickLevelId = PlayerPrefs.GetString("CustomSettingWindow_���ٹؿ�", "");
                    m_QuickLevelId = GUILayout.TextField(m_QuickLevelId, GUILayout.Height(30f));
                    PlayerPrefs.SetString("CustomSettingWindow_���ٹؿ�", m_QuickLevelId);
                    if (GUILayout.Button("���ٹؿ�", GUILayout.Height(30f)))
                    {
                        QucikLevel(m_QuickLevelId);
                    }
                    if (GUILayout.Button("����û�Token���˳���Ϸ", GUILayout.Height(30f)))
                    {
                        //QucikLevel(m_QuickLevelId);
                        PlayerPrefs.DeleteKey("Pref_Login_Token");
                        Application.Quit();
                    }
                }
                GUILayout.EndHorizontal();

                if (GUILayout.Button("һ��ɱ��", GUILayout.Height(30f)))
                {
                    Debug.Log("һ��ɱ��");
                    //GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UTILS_FAILURE);
                }

                if (GUILayout.Button("������ҩ", GUILayout.Height(30f)))
                {
                    //FullBullet();
                }

                GUILayout.BeginVertical("box");
                {
                    GUILayout.BeginHorizontal("box");
                    {
                        GUILayout.Label("����Id", GUILayout.Height(30f));
                        m_MonsterId = PlayerPrefs.GetString("CustomSettingWindow_����Id", "");
                        m_MonsterId = GUILayout.TextField(m_MonsterId, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_����Id", m_MonsterId);
                        GUILayout.Label("�����ǩ", GUILayout.Height(30f));
                        m_MonsterLabel = PlayerPrefs.GetString("CustomSettingWindow_�����ǩ", "99");
                        m_MonsterLabel = GUILayout.TextField(m_MonsterLabel, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_�����ǩ", m_MonsterLabel);
                        GUILayout.Label("����x", GUILayout.Height(30f));
                        m_MonsterPosx = PlayerPrefs.GetString("CustomSettingWindow_��������x", "300");
                        m_MonsterPosx = GUILayout.TextField(m_MonsterPosx, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_��������x", m_MonsterPosx);
                        GUILayout.Label("����y", GUILayout.Height(30f));
                        m_MonsterPosy = PlayerPrefs.GetString("CustomSettingWindow_��������y", "0");
                        m_MonsterPosy = GUILayout.TextField(m_MonsterPosy, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_��������y", m_MonsterPosy);
                        GUILayout.Label("����z", GUILayout.Height(30f));
                        m_MonsterPosz = PlayerPrefs.GetString("CustomSettingWindow_��������z", "0");
                        m_MonsterPosz = GUILayout.TextField(m_MonsterPosz, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_��������z", m_MonsterPosz);
                        if (GUILayout.Button("ˢ��", GUILayout.Height(30f)))
                        {
                            //CreateCharacterData data = new CreateCharacterData();
                            //data.nConfigId = m_MonsterId.ToInt();
                            //data.nLabel = m_MonsterLabel.ToInt();
                            //data.campType = CampType.Enemy;
                            //data.nAIInitState = 1;
                            //DataConfigMonsterLevelPropertyInfoList.Singleton().SetSingleMonsterAttr(data);
                            //data.sceneTransform = new SceneTransform()
                            //{
                            //    Postion_X = m_MonsterPosx.ToInt(),
                            //    Postion_Y = m_MonsterPosy.ToInt(),
                            //    Postion_Z = m_MonsterPosz.ToInt(),
                            //};
                            //GameEntry.Character.SpawnMonster(data);
                        }
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();

                GUILayout.BeginVertical("box");
                {
                    GUILayout.BeginHorizontal("box");
                    {
                        GUILayout.Label("����1", GUILayout.Height(30f));
                        m_Param1 = PlayerPrefs.GetString("CustomSettingWindow_m_Param1", "");
                        m_Param1 = GUILayout.TextField(m_Param1, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_m_Param1", m_Param1);
                        GUILayout.Label("����2", GUILayout.Height(30f));
                        m_Param2 = PlayerPrefs.GetString("CustomSettingWindow_m_Param2", "");
                        m_Param2 = GUILayout.TextField(m_Param2, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_m_Param2", m_Param2);
                        GUILayout.Label("����3", GUILayout.Height(30f));
                        m_Param3 = PlayerPrefs.GetString("CustomSettingWindow_m_Param3", "");
                        m_Param3 = GUILayout.TextField(m_Param3, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_m_Param3", m_Param3);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal("box");
                    {
                        GUILayout.Label("����4", GUILayout.Height(30f));
                        m_Param4 = PlayerPrefs.GetString("CustomSettingWindow_m_Param4", "");
                        m_Param4 = GUILayout.TextField(m_Param4, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_m_Param4", m_Param4);
                        GUILayout.Label("����5", GUILayout.Height(30f));
                        m_Param5 = PlayerPrefs.GetString("CustomSettingWindow_m_Param5", "");
                        m_Param5 = GUILayout.TextField(m_Param5, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_m_Param5", m_Param5);
                        GUILayout.Label("����6", GUILayout.Height(30f));
                        m_Param6 = PlayerPrefs.GetString("CustomSettingWindow_m_Param6", "");
                        m_Param6 = GUILayout.TextField(m_Param6, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_m_Param6", m_Param6);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal("box");
                    {
                        GUILayout.Label("�ű�����", GUILayout.Height(30f));
                        m_ScriptType = PlayerPrefs.GetString("CustomSettingWindow_�ű�����", "");
                        m_ScriptType = GUILayout.TextField(m_ScriptType, GUILayout.Height(30f));
                        PlayerPrefs.SetString("CustomSettingWindow_�ű�����", m_ScriptType);
                        if (GUILayout.Button("ִ�����������Ľű�", GUILayout.Height(30f)))
                        {
                            //GameEntry.Event.FireNow(KLKDDebuggerSettingChangeEventArgs.EventId, KLKDDebuggerSettingChangeEventArgs.Create(KLKDDebuggerSettingChangeEventArgs.CommandType.ExecuteScript, string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", m_ScriptType, m_Param1, m_Param2, m_Param3, m_Param4, m_Param5, m_Param6)));
                        }
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();

                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label("�ֱ��ʿ�", GUILayout.Height(30f));
                    m_SceneWidth = GUILayout.TextField(m_SceneWidth, GUILayout.Height(30f));
                    GUILayout.Label("�ֱ��ʸ�", GUILayout.Height(30f));
                    m_SceneHigh = GUILayout.TextField(m_SceneHigh, GUILayout.Height(30f));
                    if (GUILayout.Button("���÷ֱ���", GUILayout.Height(30f)))
                    {
                        //Screen.SetResolution(/*��Ļ���*/m_SceneWidth.ToInt(),/*��Ļ�߶�*/ m_SceneHigh.ToInt(), /*�Ƿ�ȫ����ʾ*/false);
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
        GUILayout.EndVertical();
    }

    private void QucikLevel(string m_QuickLevelId)
    {
    }

    /*            void GameMainCustomSettingWindowHelper.OnDrawScrollableWindow()
                {
                    throw new System.NotImplementedException();
                }*/
}
