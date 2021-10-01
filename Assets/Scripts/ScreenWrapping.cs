using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<BoxCollider2D>().size.x;
        height = GetComponent<BoxCollider2D>().size.y;
    }
    void OnBecameInvisible()
    {
        Vector2 currPosition = transform.position;
        if (height + currPosition.y > ScreenUtils.ScreenTop)
        {
            //currPosition.y = ScreenUtils.ScreenBottom + shipRadius; 
            currPosition.y *= -1;
        }
        else if (currPosition.y - height < ScreenUtils.ScreenBottom)
        {
            //currPosition.y = ScreenUtils.ScreenTop - shipRadius;
            currPosition.y *= -1;
        }
        if (width + currPosition.x > ScreenUtils.ScreenRight)
        {
            //currPosition.x = shipRadius + ScreenUtils.ScreenLeft;
            currPosition.x *= -1;
        }
        else if (currPosition.x - width < ScreenUtils.ScreenLeft)
        {
            //currPosition.x = ScreenUtils.ScreenRight - shipRadius;
            currPosition.x *= -1;
        }
        transform.position = currPosition;
    }
}
