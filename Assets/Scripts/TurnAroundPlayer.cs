using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundPlayer : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]
    private float rotationSpeed = 1f;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 axis = Vector3.up;
        transform.RotateAround(playerTransform.position, axis, rotationSpeed* Time.deltaTime);
    }
}
