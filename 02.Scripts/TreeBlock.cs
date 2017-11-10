using UnityEngine;

public class TreeBlock : MonoBehaviour {

	public GameObject[] treeGameObjects;

	private float minScaleRate = 0.9f;
	private float maxScaleRate = 1.1f;

	void Start () {
		for (int i = 0; i < treeGameObjects.Length; i++) {
			Vector3 localScale = treeGameObjects[i].transform.localScale;
			localScale *= Random.Range (minScaleRate, maxScaleRate);

			treeGameObjects[i].transform.localScale = localScale;
		}
	}
}
