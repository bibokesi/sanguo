using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameObjectUtils
{
    public static Vector3 GetFrezzeModeDirection(float dirX, float dirZ)
    {
        Vector3 forward = GameEntry.Camera.MainCamera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        float v = dirZ;
        float h = dirX;
        Vector3 targetDirection = h * right + v * forward;
        if (targetDirection != Vector3.zero)
        {
            targetDirection = targetDirection.normalized;
        }

        return targetDirection;
    }
}