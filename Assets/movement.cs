using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController ILikeTo;

    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;

    public Transform feetsies;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 it;
    bool pesho;

    public void Update()
    {
        pesho = Physics.CheckSphere(feetsies.position, groundDistance, groundMask);

        if(pesho && it.y < 0)
        {
            it.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveIt = transform.right * x + transform.forward * z;
        ILikeTo.Move(moveIt * speed * Time.deltaTime);

        it.y = it.y + gravity * Time.deltaTime;
        ILikeTo.Move(it * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && pesho && gravity <= 0)
        {
            it.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        } else if (Input.GetButtonDown("Jump") && pesho && gravity > 0)
        {
            it.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            gravity = -gravity;
        }
    }
}
