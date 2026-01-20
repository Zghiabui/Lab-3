using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Cài đặt Mục Tiêu")]
    public Transform target; // Kéo vật thể Target vào đây

    [Header("Cài đặt Xoay")]
    public float rotateSpeed = 60f; // Tốc độ xoay (độ/giây) - Dùng cho chế độ mượt
    public bool useSmoothRotation = true; // Check = Mượt, Bỏ check = Nhìn ngay lập tức

    void Update()
    {
        // 1. Kiểm tra an toàn: Nếu không có mục tiêu thì không làm gì cả
        if (target == null) return;

        // 2. Tính toán Vector hướng (Từ súng -> Mục tiêu)
        Vector3 directionToTarget = target.position - transform.position;

        // [Mẹo] Khóa trục Y (độ cao) để súng chỉ xoay ngang, không ngửa lên trời/cúi xuống đất
        // Nếu bạn muốn súng bắn máy bay thì bỏ dòng này đi
        directionToTarget.y = 0;

        // 3. Xử lý logic xoay theo 2 chế độ
        if (useSmoothRotation)
        {
            // --- CHẾ ĐỘ 1: XOAY MƯỢT (RotateTowards) ---

            // Bước A: Tính xem "cần phải xoay thế nào" để nhìn thấy mục tiêu (Quaternion đích)
            // Quaternion.LookRotation sẽ đổi từ Vector hướng sang Góc quay
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Bước B: Xoay từ từ góc hiện tại sang góc đích
            // RotateTowards(Góc hiện tại, Góc đích, Tốc độ tối đa mỗi frame)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        else
        {
            // --- CHẾ ĐỘ 2: XOAY CỨNG (LookAt) ---

            // Hàm này ép vật thể nhìn ngay lập tức vào vị trí mục tiêu
            // Lưu ý: LookAt yêu cầu một điểm (Vector3), không phải hướng
            // Ta tạo một điểm mới có độ cao bằng súng để tránh bị nghiêng
            Vector3 lookSpot = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(lookSpot);
        }
    }

    // Vẽ đường line nối súng và mục tiêu để dễ debug
    void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
}
