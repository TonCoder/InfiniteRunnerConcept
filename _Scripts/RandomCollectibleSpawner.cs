using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCollectibleSpawner : MonoBehaviour {
    [SerializeField] private Transform ObjectToSpawnCollectible;

    private List<Transform> ActiveCollectibles = new List<Transform> ();

    private void OnDisable () {
        if (ActiveCollectibles.Count <= 0) return;
        ActiveCollectibles.ForEach (x => SimplePoolManager.instance.DisablePoolObject (x.transform));
        ActiveCollectibles.Clear ();
    }

    // Use this for initialization
    void OnEnable () {
        Initialize ();
    }

    void Initialize () {
        if (ObjectToSpawnCollectible.childCount > 0) {
            foreach (Transform child in ObjectToSpawnCollectible) {
                SpawnCollectible (child.GetComponent<Renderer> ().bounds.center);
            }
        } else {
            SpawnCollectible (ObjectToSpawnCollectible.GetComponent<Renderer> ().bounds.center);
        }
    }

    private void SpawnCollectible (Vector3 center) {
        var Obj = SimplePoolManager.instance.GetPoolItem ("Collectibles");
        Obj.transform.position = center;
        Obj.SetActive (true);
        ActiveCollectibles.Add (Obj.transform);
    }

}