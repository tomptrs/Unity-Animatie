using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rBody;
    [SerializeField]
    public float speed = 4f;

    public float turnSpeed = 20f;

    Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();

    }

    float forwardAmount = 0;
    float turnAmount = 0;
    // Update is called once per frame
    void Update()
    {
        mAnimator.SetFloat("posX", 0);
        mAnimator.SetFloat("posY", 0);
        mAnimator.SetBool("jump", false);
        forwardAmount = 0;
        turnAmount = 0;
        if (Input.GetKey(KeyCode.LeftArrow))//start left animation
        {
            Debug.Log("left");
            turnAmount = -1f;
            mAnimator.SetFloat("posX", -1);

        }
        if (Input.GetKey(KeyCode.RightArrow))//start left animation
        {
            Debug.Log("left");
            turnAmount = 1f;
            mAnimator.SetFloat("posX", 1);

        }
        if (Input.GetKey(KeyCode.UpArrow))//start left animation
        {
            Debug.Log("left");
            forwardAmount = 1f;
            mAnimator.SetFloat("posY", 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))//start left animation
        {
            Debug.Log("left");
            forwardAmount = -1f;
            mAnimator.SetFloat("posY", 1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            mAnimator.SetBool("jump", true);
        }



        rBody.MovePosition(transform.position + transform.forward * forwardAmount * speed * Time.fixedDeltaTime);
        transform.Rotate(transform.up * turnAmount * turnSpeed * Time.fixedDeltaTime);
    }
}
