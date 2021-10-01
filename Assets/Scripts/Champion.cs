using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabChampion;

    float baseMoveSpeed = 7;
    public static int pointsPerSec = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 currPosition = transform.position;
        float horizMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");
        //if (horizMove != 0 && vertMove != 0)
        //{
        //    currPosition.x += horizMove * Mathf.Sqrt(baseMoveSpeed) * Time.deltaTime;
        //    currPosition.y += vertMove * Mathf.Sqrt(baseMoveSpeed) * Time.deltaTime;
        //}
        if (horizMove != 0 || vertMove != 0)
        {
            currPosition.x += horizMove * baseMoveSpeed * Time.deltaTime;
            currPosition.y += vertMove * baseMoveSpeed * Time.deltaTime;
            if (Input.GetKeyDown("return"))
            {
                if(horizMove != 0)
                {
                    currPosition.x += horizMove/Mathf.Abs(horizMove) * Time.deltaTime * 400;
                }
                if(vertMove != 0)
                {
                    currPosition.y += vertMove/Mathf.Abs(vertMove) * Time.deltaTime * 400;
                }
                transform.position = currPosition;
                GameObject newChamp = Instantiate(prefabChampion, currPosition, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                transform.position = currPosition;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        HUD.running = false;
    }
}
