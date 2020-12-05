using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    Vector3 destPos;
    bool moveToDest = false;

    void Start()
    {
        Managers._input.KeyAction -= MovePlayer;
        Managers._input.KeyAction += MovePlayer;
        Managers._input.MouseAction -= OnMouseClicked;
        Managers._input.MouseAction += OnMouseClicked;
    }

    private void OnMouseClicked(Define.MouseEvent obj)
    {
        switch(obj)
        {
            case Define.MouseEvent.Down_0:
                break;
            case Define.MouseEvent.Press_0:
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    destPos = hit.point;
                    moveToDest = true;
                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 0.1f);
                }
                break;
            case Define.MouseEvent.Up_0:
                break;
        }

    }

    void Update()
    {
        if (moveToDest)
        {
            Vector3 dir = destPos - transform.position;
            if (dir.magnitude > 0.001f)
            {
                float dist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * dist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
            }
            else
            {
                moveToDest = false;
            }
        }
    }

    public void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.Translate(Vector3.back * _speed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
         }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.World);
        }
    }

}
