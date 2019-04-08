using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain;
    public CinemachineVirtualCamera[] allCameras;


    private void Update()
    {
        for (int i = 0; i < allCameras.Length; i++)
        {
            if (Input.GetButtonDown(i.ToString()))
            {
                if (allCameras[i] != null)
                {
                    cinemachineBrain.ActiveVirtualCamera.Priority = 10;
                    allCameras[i].Priority = 11;
                }
            }
        }
    }
}
