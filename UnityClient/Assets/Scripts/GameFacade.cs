using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
public class GameFacade : MonoBehaviour
{
    private static GameFacade _instance;
    public static GameFacade Instance
    {
        get { return _instance; }
    }

    private UIManager uiManager;
    private AudioManager audioManger;
    private PlayerManager playerManager;
    private CameraManager cameraManager;
    private RequestManager requestManager;
    private ClientManager clientManager;
    private void Awake()
    {
        if (_instance)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }
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
        uiManager = new UIManager(this);
        audioManger = new AudioManager(this);
        playerManager = new PlayerManager(this);
        cameraManager = new CameraManager(this);
        requestManager = new RequestManager(this);
        clientManager = new ClientManager(this);

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

    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        requestManager.AddRequest(requestCode, request);
    }
    public void RemoveRequest(RequestCode rc)
    {
        requestManager.RemoveRequest(rc);
    }
    public void HandleResponse(RequestCode rc, string data)
    {
        requestManager.HandleResponse(rc, data);
    }
}