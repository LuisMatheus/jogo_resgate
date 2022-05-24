using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementSimpleHumans : MonoBehaviour
{
    private Animator _animator;
    // Get legs and arms parameters from animator to vars
    private int setLegs = Animator.StringToHash("legs");
    private int setArms = Animator.StringToHash("arms");
    // set speed of gameObject
    private int _speed;
    private Rigidbody _rb;
    // for movement
    private NavMeshAgent _agent;
    // for switch between walking animations
    private bool _ducked;
 
    void Start()
    {
        // get component from object using the script
        _animator = this.GetComponent<Animator>();
        _speed = 100;
        _rb = this.GetComponent<Rigidbody>();
        _agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // rb.velocity = motion * _speed;
        
        // Rotate right and *-1, because Object has own axis
        Vector3 verticalMovement = (transform.right * -1) * Input.GetAxis("Vertical") ;
        //Vector3 horizontalMovement = transform.right * Input.GetAxis("Horizontal");
        
        // float slerpTValue = Mathf.Abs(Input.GetAxis("Vertical") / Input.GetAxis("Horizontal"))/2;
        // Vector3 targetPosition = Vector3.Slerp(horizontalMovementation, verticalMovimentation, slerpTValue);
        // targetPosition.y = 0.0f;
        
        // Move using navMesh
        _agent.Move(verticalMovement * _speed * Time.deltaTime);
        
        
        // Normal walk
        if ((Input.GetKey("w") || Input.GetKey("s")) && !_ducked)
        { 
            _animator.SetInteger(setLegs, 1);
            _animator.SetInteger(setArms, 1);
        }
        

        // Running, breaks ducked as well
        if (Input.GetKey("w") && Input.GetKey("left shift"))
        {
            _animator.SetInteger(setLegs, 2);
            _animator.SetInteger(setArms, 2);
            _ducked = false;
        }
        
        // Stop walking
        if (!Input.GetKey("s") && !Input.GetKey("w") && !_ducked)
        {
            _animator.SetInteger(setLegs, 0);
            _animator.SetInteger(setArms, 0);
        }
        
        // Stop Running
        if (!Input.GetKey("left shift") && Input.GetKey("w"))
        {
            _animator.SetInteger(setLegs, 1);
            _animator.SetInteger(setArms, 1);
        }
        
        // Rotate Left
        if (Input.GetKey("a"))
        {
            var rotate = transform.localRotation.eulerAngles.y;
            transform.localRotation = Quaternion.Euler(new Vector3(0, rotate-1f, 0));
        }
        
        // Rotate Right
        if (Input.GetKey("d"))
        {
            double rotate = transform.localRotation.eulerAngles.y;
            transform.localRotation = Quaternion.Euler(new Vector3(0, (float) rotate+1, 0));
        }
        
        // Pick-up
        if (Input.GetKey("e") && !Input.GetKey("w") && !Input.GetKey("s"))
        {
            _animator.SetInteger(setLegs, 9);
            _animator.SetInteger(setArms, 9);
        }
        
        // Switch between ducked and no-ducked animations
        if (Input.GetKey("space"))
        {
            if (_ducked)
            {
                _ducked = false;
                _animator.SetInteger(setLegs, 0);
                _animator.SetInteger(setArms, 0);
            }
            else
            {
                _ducked = true;
                _animator.SetInteger(setLegs, 8);
                _animator.SetInteger(setArms, 8);
            }
        }
        
        // Walk while ducked
        if ((Input.GetKey("w") || Input.GetKey("s")) && _ducked)
        {
            _animator.SetInteger(setLegs, 6);
            _animator.SetInteger(setArms, 6);
        }
        
        // Stop walking if ducked
        if ((!Input.GetKey("w") && !Input.GetKey("s")) && _ducked)
        {
            _animator.SetInteger(setLegs, 8);
            _animator.SetInteger(setArms, 8);
        }
        
    }
}
