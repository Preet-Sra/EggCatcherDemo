using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minX, maxX;
    Animator anim;
    public bool isDead;

    float horzontalInput;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        if (!isDead)
        {
           Movement();
           
            CheckBounds();
        }
      
    }

    void Movement()
    {
        //float horzontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = horzontalInput * speed * Time.deltaTime;

        if (horzontalInput == 0)
        {
            //Idle Animtion
            anim.SetBool("isRunning",false);
        }
        else
        {
            //Running Animation
            anim.SetBool("isRunning", true);
            Vector3 ScaleX = transform.localScale;

            if (horzontalInput > 0)
                ScaleX.x = 1;
            else
                ScaleX.x = -1;

            transform.localScale = ScaleX;
        }


        transform.position = new Vector3(transform.position.x + horizontalMovement, transform.position.y, transform.position.z);

    }


    public void MoveLeft()
    {
        horzontalInput = -1;
        Debug.Log("Moving Left");
    }
    public void MoveRight()
    {
        horzontalInput = 1;
    }

    public void StayIdle()
    {
        horzontalInput = 0;
    }


    void CheckBounds()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
            temp.x = maxX;
        if (temp.x < minX)
            temp.x = minX;

        transform.position = temp;
    }

    public void Dead()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        
    }
   
}
