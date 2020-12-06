using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum PlayerState
    {
        Idle,
        Move,
        Attack,
        Heat,
        Die
    }

    PlayerState playerState = PlayerState.Idle;

    Animator anim;
    [SerializeField] float _speed = 5;
    Vector3 destPos;
    float wait_run_ratio = 0;

    void Start()
    {
        Managers._input.KeyAction -= MovePlayer;
        Managers._input.KeyAction += MovePlayer;
        Managers._input.MouseAction -= OnMouseClicked;
        Managers._input.MouseAction += OnMouseClicked;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Move:
                UpdateMove();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
        }
    }

    void UpdateIdle()
    {
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 0.2f);
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
    }

    void UpdateMove()
    {
        Vector3 dir = destPos - transform.position;
        if (dir.magnitude > 0.001f)
        {
            float dist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * dist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);

            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 0.05f);
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
        }
        else
        {
            playerState = PlayerState.Idle;
        }
    }

    void UpdateDie()
    {
        anim.SetTrigger("isDead");
    }





    public void MovePlayer()
    {
        if (playerState == PlayerState.Die)
            return;

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

    private void OnMouseClicked(Define.MouseEvent obj)
    {
        if (playerState == PlayerState.Die)
            return;

        switch (obj)
        {
            case Define.MouseEvent.Down_0:
                break;
            case Define.MouseEvent.Press_0:
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    playerState = PlayerState.Move;
                    destPos = hit.point;
                }
                break;
            case Define.MouseEvent.Up_0:
                break;
        }

    }
}
