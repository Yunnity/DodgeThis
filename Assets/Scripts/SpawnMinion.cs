using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinion : MonoBehaviour
{
    [SerializeField]
    GameObject BlueMinion;
    [SerializeField]
    GameObject RedMinion;
    [SerializeField]
    GameObject Champion;

    float minSpawnTime = 1f;
    float maxSpawnTime = 3f;
    Timer spawnTimer;

    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 champVector = new Vector3(500, 500, -Camera.main.transform.position.z);
        Vector3 champSpawn = Camera.main.ScreenToWorldPoint(champVector);
        Instantiate(Champion, champSpawn, Quaternion.identity);
        GameObject tempMinion = Instantiate(BlueMinion);
        float minionWidth = tempMinion.GetComponent<BoxCollider2D>().size.x;
        float minionHeight = tempMinion.GetComponent<BoxCollider2D>().size.y;
        Destroy(tempMinion);

        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - minSpawnX;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - minSpawnY;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(minSpawnTime, maxSpawnTime);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(HUD.running)
        {
            if (spawnTimer.isFinished)
            {
                SpawnAMinion();
                spawnTimer.Duration = Random.Range(minSpawnTime, maxSpawnTime);
                spawnTimer.Run();
            }
        }
    }

    Vector3 tryPosition()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(spawnLocation);
        return worldLocation;
    }

    void SpawnAMinion()
    {
        Vector3 location = tryPosition();
        int spawnTries = 0;
        while (Physics2D.OverlapArea(location, transform.position) != null && spawnTries < 20)
        {
            location = tryPosition();
            spawnTries += 1;
        }

        if(Physics2D.OverlapArea(location, transform.position) == null)
        {
            int minionNum = Random.Range(0, 2);
            if (minionNum == 0)
            {
                Instantiate<GameObject>(BlueMinion, location, Quaternion.identity);
            }
            else if (minionNum == 1)
            {
                Instantiate<GameObject>(RedMinion, location, Quaternion.identity);
            }
        }
        else
        {
            return;
        }
    }
}
