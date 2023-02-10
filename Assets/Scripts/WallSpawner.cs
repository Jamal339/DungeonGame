using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if Colision in dir if not enable wall, if yes delete wall object make door in place

    }

    public void SpawnWall()
    {
        //Call this func somewhere after room spawning done
        if (!Physics2D.OverlapBox((Vector2)transform.position + dir, new Vector2(5, 5), 0))
        {
            //enable SpriteRenderer and BoxCol of object LEAVE OBJECT ENABLED OR CAN'T FIND
            enabled = true;
        }
    }
}
