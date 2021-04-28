# Unity-Animatie

1.	Start nieuwe 3D scene
2.	Ga naar https://www.mixamo.com/
3.	Log in en zoek naar vb. “locomation pack”
4.	Je kan je eigen 3D model in mixamo slepen zodat je asset automatisch animatie mogelijkheden krijgt
5.	Download een fbx bestand
6.	Sleep je model in de Assets folder
7.	Sleep je xbot in je Scene (en reset de positie naar (0,0,0)
8.	Maak een script zodat je je model kan laten bewegen door middel van je keyboard.
9. Aanmaken van de animaties
10. Zet de animaties op humanoid
11. maak animator controller aan
12. maak blend tree aan
13. Maak vb. posX en posY aan, en zet de blend tree op 2d cartesian
14. Hang de juiste animaties aan de posities
15. Pas je script aan:
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
