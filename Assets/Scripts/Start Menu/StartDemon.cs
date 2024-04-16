using System.Collections;
using UnityEngine;

public class StartDemon : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MoveDemon(transform.up, 20f, 5f));
    }

    IEnumerator MoveDemon(Vector3 direction, float distance, float time)
    {
        Vector3 start = transform.position;
        Vector3 end = start + (direction * distance);

        float timeElapsed = 0;

        while (timeElapsed < time)
        {
            transform.position = Vector3.Lerp(start, end, timeElapsed / time);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
