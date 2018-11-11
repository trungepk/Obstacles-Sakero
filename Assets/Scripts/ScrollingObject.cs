using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
    [SerializeField] float scrollSpeed = -1f;

	void Start () {

    }

    void Update () {
        transform.position += transform.forward * scrollSpeed * Time.deltaTime;
	}
}
