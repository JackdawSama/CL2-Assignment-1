using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{

    public Sprite[] sprites;
    private int score = 0;
    private int num;
    private Vector2 pos;
    public int radius;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.3f, Random.Range(1,3));                                      //spawns a sprite randomly every 1 to 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector2(Random.Range(-radius, radius), Random.Range(-radius, radius));        //randomises the position

        //checks if the left mouse button is clicked and if true it executes a raycasts
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            //checks if the raycast collides with an object and if true deletes the game object and increases the player score
            if(hit.collider != null)
            {
                Destroy(hit.collider.gameObject);
                score ++;
                Debug.Log("Sprite Clicked");
                Debug.Log("Score: " + score);
            }
        }
    }

    //function to spwan a game object
    void Spawn()
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/Blue"), pos, Quaternion.identity) as GameObject;    //creates an instance of the seleced object from the resources folder as a game object
        num = GetComponent<ColourPicker>().SetSprite();                                                         //gets a random number from the ColourPicker script's SetSprite() funcion
        go.GetComponent<SpriteRenderer>().sprite = sprites[num];                                                //sets the sprite from he list of sprites available based on the return of the SetSprite() function
    }
}
