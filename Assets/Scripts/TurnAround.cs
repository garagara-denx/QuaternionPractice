using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [SerializeField]
    private float angle = 90f;
    [SerializeField]
    private float rotationSpeed = 1f;
    private bool rotationTrigger = false;
    private float lastAngle;
    private float deltaRotationRate = 0f;
    Quaternion targetRotation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            rotationTrigger = true;
            deltaRotationRate = 0;

            // 01.Sキーを押した瞬間に目的のQuaternionを算出する
            lastAngle = transform.eulerAngles.y + angle;
            targetRotation = Quaternion.AngleAxis(lastAngle, Vector3.up);
        }

        if (rotationTrigger)
        {
            // 02.Slerp関数を使って自身のRotationを目的のQuaternionに近づける
            deltaRotationRate += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, deltaRotationRate);

            // 03.自身のRotationと目的のQuaternionが大体一致したら処理を終了
            if (Mathf.Approximately(Quaternion.Angle(transform.rotation, targetRotation), 0f))
            {
                transform.rotation = targetRotation;
                rotationTrigger = false;
            }
        }
    }
}