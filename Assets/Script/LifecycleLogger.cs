using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifecycleLogger : MonoBehaviour
{
    // 1. Chạy ĐẦU TIÊN khi object được khởi tạo (kể cả khi script bị tắt)
    void Awake()
    {
        Debug.Log("<color=green>1. Awake</color>: Object thức dậy!");
    }

    // 2. Chạy mỗi khi Object hoặc Script được BẬT (Active)
    void OnEnable()
    {
        Debug.Log("<color=blue>2. OnEnable</color>: Script đã được bật.");
    }

    // 3. Chạy 1 lần duy nhất ở frame đầu tiên (sau OnEnable)
    void Start()
    {
        Debug.Log("<color=yellow>3. Start</color>: Bắt đầu khởi chạy logic.");
    }

    // 4. Chạy vật lý (Mặc định 0.02s/lần). Dùng để di chuyển Rigidbody.
    void FixedUpdate()
    {
        // Tôi comment lại để tránh spam đầy console, bạn có thể mở ra nếu muốn test
        Debug.Log("4. FixedUpdate: Đang tính toán vật lý...");
    }

    // 5. Chạy mỗi frame (xử lý Input, Logic game).
    void Update()
    {
        Debug.Log("5. Update: Đang chạy mỗi khung hình...");
    }

    // 6. Chạy SAU KHI Update xong (Thường dùng để Camera bám theo nhân vật).
    void LateUpdate()
    {
        Debug.Log("6. LateUpdate: Chạy sau Update.");
    }

    // 7. Chạy khi Object hoặc Script bị TẮT (Deactive)
    void OnDisable()
    {
        Debug.Log("<color=orange>7. OnDisable</color>: Script bị tắt tạm thời.");
    }

    // 8. Chạy khi Object bị HỦY HOÀN TOÀN khỏi game
    void OnDestroy()
    {
        Debug.Log("<color=red>8. OnDestroy</color>: Tạm biệt! Object đã bị hủy.");
    }
}
