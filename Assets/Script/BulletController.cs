using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.1f, 0);

        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
