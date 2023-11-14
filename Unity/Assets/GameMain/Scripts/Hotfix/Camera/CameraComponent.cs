using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityGameFramework.Runtime;

public enum BaseCamera:int
{
    MainCamera,
    ArCamera,
    BattleCamera
}

[DisallowMultipleComponent]
[AddComponentMenu("GameMain/Camera")]
public partial class CameraComponent : GameFrameworkComponent
{
    /// <summary>
    /// 主相机
    /// </summary>
    private Camera m_MainCamera;
    private UniversalAdditionalCameraData m_MainCameraUniData;
    public Camera MainCamera 
    {
        get => m_MainCamera;
        set => m_MainCamera = value;
    }

    private Camera m_CurUseCamera;
    public Camera CurUseCamera => m_CurUseCamera;

    /// <summary>
    /// 相机灵敏度
    /// </summary>
    private float CameraSensitivity = 0.1f;

    protected override void Awake()
    {
        base.Awake();

        m_MainCamera = transform.Find("MainCamera").GetComponent<Camera>();
        m_MainCameraUniData = m_MainCamera.GetComponent<UniversalAdditionalCameraData>();
        m_CurUseCamera = m_MainCamera;
        OnFreeLookAwake();
        OnOrbitAwake();
        OnUICameraAwark();
        //CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public void OpenVCamera(int type)
    {
        FollowFreeIsShow(type == 1);
        OrbitIsShow(type == 2);
    }

    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X")
        {
            if (Input.GetMouseButton(0))
            {
                return Input.GetAxis("Mouse X");
            }
            else
            {
                return 0;
            }
        }
        else if (axisName == "Mouse Y")
        {
            if (Input.GetMouseButton(0))
            {
                return Input.GetAxis("Mouse Y");
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }
}