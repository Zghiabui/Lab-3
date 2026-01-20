using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMovement : MonoBehaviour
{
    [Header("Cài đặt di chuyển")]
    public float moveSpeed = 5f; // Tốc độ di chuyển

    [Header("Debug")]
    public bool useNormalize = true; // Toggle để so sánh bật/tắt chuẩn hóa

    void Update()
    {
        // 1. Lấy tín hiệu từ bàn phím (WASD hoặc Mũi tên)
        // GetAxisRaw trả về -1, 0, 1 ngay lập tức (không có độ trễ) -> Dễ test hơn
        float h = Input.GetAxisRaw("Horizontal"); // Trục X (Trái/Phải)
        float v = Input.GetAxisRaw("Vertical");   // Trục Z (Lên/Xuống)

        // 2. Tạo Vector hướng di chuyển
        // (x, y, z) -> Ta di chuyển trên mặt phẳng nên y = 0
        Vector3 direction = new Vector3(h, 0, v);

        // 3. XỬ LÝ CHUẨN HÓA (NORMALIZE) - YÊU CẦU CỦA LAB
        if (useNormalize)
        {
            // Nếu độ dài vector > 1 (tức là đang đi chéo), ta ép nó về 1
            if (direction.magnitude > 1)
            {
                direction.Normalize();
            }
        }

        // 4. Thực hiện di chuyển
        // Công thức: Vị trí mới = Hướng * Tốc độ * Thời gian bất đồng bộ
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    // 5. VẼ GIZMOS (YÊU CẦU CỦA LAB)
    // Hàm này tự chạy trong Scene View để vẽ hình hỗ trợ debug
    void OnDrawGizmos()
    {
        // Chỉ vẽ khi game đang chạy và có nhấn nút
        if (!Application.isPlaying) return;

        // Vẽ tia màu vàng thể hiện hướng di chuyển
        Gizmos.color = Color.yellow;

        // Vẽ từ tâm nhân vật, hướng ra theo vector di chuyển, dài 2 mét
        Vector3 currentDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (useNormalize && currentDirection.magnitude > 1)
            currentDirection.Normalize();

        if (currentDirection.magnitude > 0)
        {
            Gizmos.DrawRay(transform.position, currentDirection * 2f);

            // Vẽ thêm 1 quả cầu nhỏ ở đầu mũi tên cho đẹp
            Gizmos.DrawWireSphere(transform.position + currentDirection * 2f, 0.2f);
        }
    }
}