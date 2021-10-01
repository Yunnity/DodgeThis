using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    Timer deathTimer;

    void Start()
    {
        float lifeSpan = Random.Range(12, 15);
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = lifeSpan;
        const float minSpeed = 4f;
        const float maxSpeed = 7f;
        float magnitude = Random.Range(minSpeed, maxSpeed);
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
        deathTimer.Run();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Champion")
        {
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(deathTimer.isFinished && gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
