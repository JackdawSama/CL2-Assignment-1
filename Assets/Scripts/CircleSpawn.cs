using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{

    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Target Sprite")
                {
                    Debug.Log("Sprite Clicked");
                }
            }
        }
    }

    void Spawn()
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/Blue")) as GameObject;
        int num = GetComponent<ColourPicker>().SetSprite();
        go.GetComponent<SpriteRenderer>().sprite = sprites[num];
    }
}
