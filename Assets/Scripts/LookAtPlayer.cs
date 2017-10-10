using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
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
        // 01.Playerと自身のPositonから目的のQuaternionを算出する
        Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);

        // 02.算出したQuaternionからx軸・z軸の回転を除去して、新しいQuaternionを算出
        Vector3 eulerRotation = targetRotation.eulerAngles;
        eulerRotation.x = 0;
        eulerRotation.z = 0;
        Quaternion newTargetRotation = Quaternion.Euler(eulerRotation);

        // 02.Slerp関数を使って自身のRotationを目的のQuaternionに近づける
        transform.rotation = Quaternion.Slerp(transform.rotation, newTargetRotation, rotationSpeed * Time.deltaTime);
    }
}
