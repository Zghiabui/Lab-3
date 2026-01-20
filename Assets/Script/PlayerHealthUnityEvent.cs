using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class PlayerHealthUnityEvent : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // --- ĐỊNH NGHĨA UNITY EVENT ---

    // 1. Định nghĩa Event có tham số (gửi kèm số máu int)
    // Phải khai báo class riêng và thêm [Serializable] thì nó mới hiện trong Inspector
    [System.Serializable]
    public class HealthEvent : UnityEvent<int> { }

    // 2. Khai báo biến Event để hiện ra Inspector
    [Header("Cài đặt Sự kiện (Kéo thả vào đây)")]
    public HealthEvent OnHealthChanged; // Event đổi máu
    public UnityEvent OnPlayerDeath;    // Event chết (không cần tham số)

    void Start()
    {
        currentHealth = maxHealth;
        // Bắn sự kiện khởi tạo
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn K để trừ máu (Lab 6 dùng K khác với H của Lab 5 cho dễ phân biệt)
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"[UnityEvent] Máu còn: {currentHealth}");

        // BẮN SỰ KIỆN (Invoke)
        // Lúc này Unity sẽ tự tìm xem bạn đã kéo thả hàm nào vào Inspector thì nó chạy hàm đó
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnPlayerDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}