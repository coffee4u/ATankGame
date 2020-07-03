using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade) { }

    private Dictionary<RequestCode, BaseRequest> requestDict = new Dictionary<RequestCode, BaseRequest>();

    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        requestDict.Add(requestCode, request);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        requestDict.Remove(requestCode);
    }
    public void HandleResponse(RequestCode rc,string data)
    {
        BaseRequest request = requestDict.TryGet(rc);
        if (!request)
        {
            Debug.LogWarning("Can get Request,may be request code is wrong");
        }
        request.OnResponse(data);
    }
}
