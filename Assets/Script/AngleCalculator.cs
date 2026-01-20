using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 

public class AngleCalculator : MonoBehaviour
{
    [Header("Cài đặt")]
    public Transform target; 
    public TextMeshProUGUI angleDisplay; 

    void Update()
    {
        if (target == null) return;

        // 1. Tính Vector hướng tới mục tiêu
        Vector3 targetDir = target.position - transform.position;

        // 2. Tính Signed Angle (Góc có dấu)
        // - from: Hướng mặt hiện tại của nhân vật (transform.forward)
        // - to: Hướng tới mục tiêu (targetDir)
        // - axis: Trục xoay (Vector3.up là trục Y - trục thẳng đứng)
        float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);

        // 3. Hiển thị lên UI
        if (angleDisplay != null)
        {
            // Làm tròn 1 chữ số thập phân cho đẹp (F1)
            angleDisplay.text = $"Góc lệch: {angle.ToString("F1")}°";

            // [Mẹo Deliverable] Đổi màu chữ để dễ nhìn: 
            // Lệch phải (Dương) -> Xanh, Lệch trái (Âm) -> Đỏ
            if (angle > 0) angleDisplay.color = Color.green;
            else angleDisplay.color = Color.red;
        }

        // 4. (Tùy chọn) Xoay nhân vật theo chuột hoặc target (Yêu cầu bài lab)
        // Ở đây mình làm xoay theo Target cho dễ demo
        // Debug tia nhìn để dễ chụp ảnh báo cáo
        Debug.DrawRay(transform.position, transform.forward * 5, Color.blue); // Hướng mặt
        Debug.DrawLine(transform.position, target.position, Color.yellow);    // Hướng mục tiêu
    }
}
