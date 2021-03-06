﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 DelayRange = new Vector2(1, 2);

	// Use this for initialization
	void Start () {
        ResetDelay();
        StartCoroutine (EnemyGenerator ());
	}

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);

        if (active)
        {
            var newTransform = transform;

            Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);
            ResetDelay();
        }

        StartCoroutine(EnemyGenerator());
    }

    void ResetDelay()
    {
        delay = Random.Range(DelayRange.x, DelayRange.y);
    }

}
