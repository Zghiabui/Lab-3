using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; // Bắt buộc dòng này để dùng Action

public class PlayerHealth : MonoBehaviour
{
    // Cấu hình máu
    public int maxHealth = 100;
    private int currentHealth;

    // --- KHAI BÁO SỰ KIỆN (Events) ---
    // 1. Sự kiện thay đổi máu (Gửi kèm số máu hiện tại ra ngoài)
    public static event Action<int> OnHealthChanged;

    // 2. Sự kiện chết (Không cần gửi tham số gì cả)
    public static event Action OnPlayerDeath;

    void Start()
    {
        currentHealth = maxHealth;
        // Báo cáo máu đầy lúc mới vào game
        // Dấu ?. nghĩa là: Nếu có ai đang nghe thì mới báo, không thì thôi
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn phím H để trừ máu (Yêu cầu bài Lab)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        // Trừ máu
        currentHealth -= damage;

        // Log để kiểm tra trong Console
        Debug.Log($"Bị đánh! Máu còn: {currentHealth}");

        // BẮN PHÁO HIỆU: Báo cho cả thế giới biết máu đã thay đổi
        OnHealthChanged?.Invoke(currentHealth);

        // Kiểm tra chết
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // BẮN PHÁO HIỆU: Báo là đã chết
            OnPlayerDeath?.Invoke();

            // Tắt Player đi (giả vờ chết)
            gameObject.SetActive(false);
        }
    }
}
