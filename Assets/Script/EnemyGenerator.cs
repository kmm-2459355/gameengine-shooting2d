using UnityEngine;
using UnityEngine.VFX;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float span = 1f;
    float delta = 0;
    float time = 0;

    void Update()
    {
        this.time += Time.deltaTime;
        this.delta += Time.deltaTime;
        if (time <= 25)
        {
            if (this.delta > this.span)
            {
                this.delta = 0;
                int rx = Random.Range(-2, 3);
                Vector3 spawnPosition = new Vector3(rx, 5, 0);
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
