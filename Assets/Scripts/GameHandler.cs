using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public CameraMovement cameraFollow;
    public Transform playerTransform;
    public GameObject enemyPrefab;
    public float spawnInterval;

    float lastSpawnTime;
    private bool showingGameOverUI = false;

    private void Start()
    {
        if(cameraFollow == null) return;

        cameraFollow.Setup(() =>
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var distanceVector = (mousePosition + playerTransform.position) / 2;
            return Vector3.Distance(mousePosition, playerTransform.position) > 20 ? distanceVector : distanceVector.normalized * 5;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (GameFlags.GameOver && !showingGameOverUI) {
            GoToGameOverUI();
        }

        if (lastSpawnTime + spawnInterval < Time.time) {
            var spawnDirection = Random.Range(-179,180);
            Debug.Log($"Spawning enemy in direction: {spawnDirection}");
            var spawnVector = new Vector2(Mathf.Cos(spawnDirection * Mathf.Deg2Rad), Mathf.Sin(spawnDirection * Mathf.Deg2Rad));
            Debug.Log($"Spawning enemy at vector: {spawnVector}");
            var enemy = Instantiate(enemyPrefab, spawnVector * 10, Quaternion.identity);
            enemy.GetComponent<Rigidbody2D>().velocity = -spawnVector;
            lastSpawnTime = Time.time;
        }
    }
    
    void GoToGameOverUI()
    {
    }
}
