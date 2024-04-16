using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Windows;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void OnEnable()
    {
        InputController.onNewPlayerAnimation += OnNewPlayerAnimation;
    }

    void OnDisable()
    {
        InputController.onNewPlayerAnimation -= OnNewPlayerAnimation;
    }

    void OnNewPlayerAnimation()
    {
        virtualCamera.Follow = GameManager.Instance.currentPlayer.transform;
    }
}
