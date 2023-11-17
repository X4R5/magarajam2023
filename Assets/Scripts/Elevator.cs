using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform target;
    bool _move;
    bool _moveBack;
    bool _isStartedMove;
    Vector3 _startPos = Vector3.zero;

    private void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        if (_move || _isStartedMove)
        {
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                _moveBack = true;
                _isStartedMove = false;
                return;
            }
            _isStartedMove = true;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if(_moveBack)
        {
            if(_move) return;
            transform.position = Vector3.MoveTowards(transform.position, _startPos, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _move = true;
            _moveBack = false;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _move = false;
        }
    }
}
