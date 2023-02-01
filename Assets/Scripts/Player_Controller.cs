using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public enum animState {idle,run };
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);

        updateAnimState();
        
    }

    public void updateAnimState()
    {
        animState state;
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        if (dirX > 0.1f)//right
        {
            state= animState.run;
            spriteRenderer.flipX = false;
        }else if(dirY > 0.1f)//up
        {
            state = animState.run;
            
        }
        else if(dirX < -0.1f || dirY < -0.1f)//left
        {
            state = animState.run;
            
            spriteRenderer.flipX = true;
        }
        else if (dirY < -0.1f)//down
        {
            state = animState.run;
            
        }
        else
        {
            state= animState.idle;
        }

        anim.SetInteger("state", (int)state);
    }
}
