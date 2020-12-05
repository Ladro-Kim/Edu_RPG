using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Define.CameraMode _cameraMode = Define.CameraMode.QuaterView;

    [SerializeField] GameObject _player = null;
    [SerializeField] Vector3 _delta = new Vector3(0, 6, -5);
    float distance;
    float zoomSpeed = 5;

    void Start()
    {
        distance = Vector3.Distance(_player.transform.position + Vector3.up, transform.position);
        _delta = transform.position + Vector3.up - _player.transform.position;
    }

    void LateUpdate()
    {
        switch(_cameraMode)
        {
            case Define.CameraMode.QuaterView:
                Ray ray = new Ray(_player.transform.position + Vector3.up, _delta);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
                {
                    float dist = (hit.point - _player.transform.position + Vector3.up).magnitude * 0.8f;
                    transform.position = _player.transform.position + Vector3.up + _delta.normalized * dist;
                }
                else
                {
                    transform.position = _player.transform.position + Vector3.up + _delta;
                    transform.LookAt(_player.transform);
                }
                break;
            case Define.CameraMode.FPS:
                break;
        }
    }

    public void SetQuaterViewCamera(Vector3 delta)
    {
        _cameraMode = Define.CameraMode.QuaterView;
        _delta = delta;
    }

}
