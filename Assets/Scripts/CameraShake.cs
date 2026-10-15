using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float _duration;
    [SerializeField] AnimationCurve _curve;

    public static CameraShake Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, kill myself NOW.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public IEnumerator Shake()
    {
        float currentTime = 0;
        Vector3 basePos = new Vector3(0,0,-10);

        while (currentTime < _duration)
        {
            Vector3 test = Random.insideUnitCircle * _curve.Evaluate(currentTime / _duration);
            test.x = -10;
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.position = basePos;
    }
}
