using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private byte _speed;
    private Animator _animator;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int LeftRotate = Animator.StringToHash("leftRotate");
    private static readonly int RightRotate = Animator.StringToHash("rightRotate");
    

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponentInChildren<Animator>();
        _speed = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();
        transform.Translate(_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f,
            _speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }

    private void InputMovement()
    {
      
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            _animator.SetBool(IsMoving, true);
            if (_speed < 5)
            {
                _speed += 1;
            }
        }

        if (Input.GetKey("a"))
        {
            _animator.SetBool(LeftRotate, true);
        }
        else
        {
            if (!Input.GetKey("a"))
            {
                _animator.SetBool(LeftRotate, false);
            }
            
        }

        if (Input.GetKey("d"))
        {
            _animator.SetBool(RightRotate, true);
        }
        else
        {
            if (!Input.GetKey("d"))
            {
                _animator.SetBool(RightRotate, false);
            }
        }


        if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            _animator.SetBool(IsMoving, false);
            if (_speed != 1)
            {
                _speed -= 2;
            }

            if (_speed < 1)
            {
                _speed = 1;
            }
        }


    }
    
    
}