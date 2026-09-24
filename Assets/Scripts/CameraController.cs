using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target; // 注視するキャラ
    [SerializeField] float distance = 5f; // キャラとの距離
    [SerializeField] float height = 2f; // カメラの高さ
    [SerializeField] float rotateSpeed = 120f; // 操作で回る速さ
    [SerializeField] float followSpeed = 2f; // 背後へ回り込む速さ
    float currentAngle; // キャラを中心とした水平角度
    void LateUpdate()
    {
        if (target == null) return;
        // ① 操作でキャラの周りを回す（円運動）
        currentAngle += Input.GetAxis("Horizontal")
        * rotateSpeed * Time.deltaTime;
        // ② キャラの真後ろへ少しずつ近づく
        // （見えないターゲット。その場回転には即追従しない）
        currentAngle = Mathf.LerpAngle(currentAngle,
        target.eulerAngles.y, followSpeed * Time.deltaTime);
        // ③ 角度と距離からカメラ位置を計算（キャラ中心の円運動）
        Quaternion rot = Quaternion.Euler(0, currentAngle, 0);
        transform.position =
        target.position + rot * new Vector3(0, height, -distance);
        // ④ 常にキャラの方を向く（LookAt）
        transform.LookAt(target.position + Vector3.up * height);
    }
}