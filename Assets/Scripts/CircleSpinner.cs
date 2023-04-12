using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpinner : MonoBehaviour {
    [SerializeField]
    private float turningSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, turningSpeed * Time.deltaTime);
	}
}
