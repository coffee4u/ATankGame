using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private UIManager uiManager;
    private AudioManager audioManger;
    private PlayerManager playerManager;
    private CameraManager cameraManager;
    private RequestManager requestManager;
    private ClientManager clientManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitManager()
    {
        uiManager = new UIManager();
        audioManger = new AudioManager();
        playerManager = new PlayerManager();
        cameraManager = new CameraManager();
        requestManager = new RequestManager();
        clientManager = new ClientManager();

        uiManager.OnInit();
        audioManger.OnInit();
        playerManager.OnInit();
        cameraManager.OnInit();
        requestManager.OnInit();
        clientManager.OnInit();
    }

    private void DestroyManager()
    {
        uiManager.OnDestroy();
        audioManger.OnDestroy();
        playerManager.OnDestroy();
        cameraManager.OnDestroy();
        requestManager.OnDestroy();
        clientManager.OnDestroy();
    }

    private void OnDestroy()
    {
        DestroyManager();
    }
}
