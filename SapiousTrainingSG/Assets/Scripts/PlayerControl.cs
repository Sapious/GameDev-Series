using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizantal = Input.GetAxis("Horizontal"); //1 or -1
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizantal, 0, vertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        if (horizantal != 0 || vertical !=0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
