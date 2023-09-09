using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassScroll : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        Vector2 offset = new Vector2(speed / 10 * Time.deltaTime, 0); //Moves background
        GetComponent<TilemapRenderer>().material.mainTextureOffset += offset; //Offset background
    }
}
