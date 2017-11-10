using UnityEngine;

public class Windmill : MonoBehaviour {

	public GameObject fan;

	private float fanSpeed = 7.5f;

	void Update () {
		fan.transform.localRotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * fanSpeed);
	}
}

