using UnityEngine;

public class EffectController : MonoBehaviour
{
    float span = 1f;
    float delta = 0;
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            Destroy(gameObject);
        }
    }
}
