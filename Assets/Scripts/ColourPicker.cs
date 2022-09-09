using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPicker : MonoBehaviour
{
    //function to randomise and obtain an integer value that ranges from 0 to 3
    public int SetSprite()
    {
        return Random.Range(0, 4);
    }
}
