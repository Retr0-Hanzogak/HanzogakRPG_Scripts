using UnityEngine;

public class TulipBlock : MonoBehaviour {
    public GameObject tulipPrefab;
    public GameObject grassPrefab;

    private int numberOfTulips = 20;
    private int numberOfGrass = 3;

    private float yPosition = 2.25f;
    private float yPositionDelta = 0.25f;
    private float tulipAreaOfWidth = 2f;
    private float grassAreaOfWidth = 2.5f;

    private void Start()
    {
        SetTulips();
        SetGrass();
    }

    void SetTulips()
    {
        for (int i = 0; i < numberOfTulips; i++)
        {
            GameObject tulipGameObject = Instantiate(tulipPrefab) as GameObject;
            tulipGameObject.transform.SetParent(gameObject.transform);

            Vector3 tulipLocalPosition = new Vector3(Random.Range(tulipAreaOfWidth * -1, tulipAreaOfWidth), 
                yPosition + Random.Range(yPositionDelta * -1, yPositionDelta), 
                Random.Range(tulipAreaOfWidth * -1, tulipAreaOfWidth));
            Quaternion tulipRotation = Quaternion.Euler(Vector3.up * Random.Range(0f, 360f));

            tulipGameObject.transform.localPosition = tulipLocalPosition;
            tulipGameObject.transform.rotation = tulipRotation;
        }
    }

    void SetGrass ()
    {
        for (int i = 0; i < numberOfGrass; i++)
        {
            GameObject grassGameObject = Instantiate(grassPrefab) as GameObject;
            grassGameObject.transform.SetParent(gameObject.transform);

            Vector3 grassLocalPosition = new Vector3(Random.Range(grassAreaOfWidth * -1, grassAreaOfWidth), yPosition,
                Random.Range(grassAreaOfWidth * -1, grassAreaOfWidth));

            if (grassLocalPosition.x > 0) {
                grassLocalPosition.x = Mathf.Clamp(grassLocalPosition.x, tulipAreaOfWidth, grassAreaOfWidth);
            } else {
                grassLocalPosition.x = Mathf.Clamp(grassLocalPosition.x, grassAreaOfWidth * -1, tulipAreaOfWidth * -1);
            }

            if (grassLocalPosition.z > 0) {
                grassLocalPosition.z = Mathf.Clamp(grassLocalPosition.z, tulipAreaOfWidth, grassAreaOfWidth);
            } else {
                grassLocalPosition.z = Mathf.Clamp(grassLocalPosition.z, grassAreaOfWidth * -1, tulipAreaOfWidth * -1);
            }

            Quaternion grassRotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360));

            grassGameObject.transform.localPosition = grassLocalPosition;
            grassGameObject.transform.rotation = grassRotation;
        }
    }
}
