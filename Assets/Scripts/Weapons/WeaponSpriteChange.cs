using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpriteChange : MonoBehaviour
{
    // https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/
    // public SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite ogSprite, newSprite;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ogSprite;
        }
    }
}
