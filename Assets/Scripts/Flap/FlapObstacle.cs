using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapObstacle : MonoBehaviour
{
    FlapGM flapGM;

    private void Start()
    {
        flapGM = FlapGM.Instance;
    }

    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 5f;
    public float holeSizeMax = 8f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4.5f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FlapPlayer player = other.GetComponent<FlapPlayer>();
        if (player != null)
            flapGM.AddScore(1);
    }
}
