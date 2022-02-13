using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] bool isTransformPosition;
    [SerializeField] bool isTransformRotation;
    [SerializeField] bool isTransformParent;

    [SerializeField] bool useRandom = false;
    [ShowIf("useRandom")]
    [SerializeField] [MinMaxSlider(-20, 20)] Vector2 randomPositionX;
    [ShowIf("useRandom")]
    [SerializeField] [MinMaxSlider(-20, 20)] Vector2 randomPositionY;
    [SerializeField] Vector3 spawnPoint;

    Vector3 positionOfObject;
    Quaternion rotationOfObject;
    public void SpawnObject(GameObject go)
    {
        if(isTransformPosition)
        {
            positionOfObject = transform.position;
        }
        else
        {
            positionOfObject = transform.position + spawnPoint;
        }

        if(isTransformRotation)
        {
            rotationOfObject = transform.rotation;
        }
        else
        {
            rotationOfObject = Quaternion.identity;
        }

        if (useRandom)
        {
            positionOfObject = new Vector3( positionOfObject.x + Random.Range(randomPositionX.x, randomPositionX.y),
                                            positionOfObject.y + Random.Range(randomPositionY.x, randomPositionY.y), 0);
        }

        if (isTransformParent)
            Instantiate(go, positionOfObject, rotationOfObject, transform);
        else
            Instantiate(go, positionOfObject, rotationOfObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (!isTransformPosition)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + spawnPoint, 1);
        }
    }
}
