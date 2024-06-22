using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static List<Transform> portalSpawnPoints = new List<Transform>();

    private void Awake()
    {
        // 포탈의 위치를 spawn point 리스트에 추가
        if (!portalSpawnPoints.Contains(transform))
        {
            portalSpawnPoints.Add(transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    void TeleportPlayer(GameObject player)
    {
        if (portalSpawnPoints.Count <= 1)
        {
            return; // 포탈이 하나만 있으면 이동하지 않음
        }

        Transform randomSpawnPoint = transform;
        while (randomSpawnPoint == transform)
        {
            randomSpawnPoint = portalSpawnPoints[Random.Range(0, portalSpawnPoints.Count)];
        }

        player.transform.position = randomSpawnPoint.position + new Vector3(0, 1, 0); // 포탈 위로 이동
    }
}
