using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float minY = 0f, maxY;

    private float lastY;

	// Update is called once per frame
	void Update () {
        if (target)
            if (target.position.y > transform.position.y)
                transform.position = new Vector3(0f, Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
	}
}
