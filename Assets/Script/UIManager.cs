using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // Dùng TextMeshPro

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI healthText;    // Kéo HealthText vào đây
    public TextMeshProUGUI gameOverText;  // Kéo GameOverText vào đây

    // --- ĐĂNG KÝ LẮNG NGHE (QUAN TRỌNG NHẤT) ---

    // Khi Object này bật lên -> Đăng ký nghe
    void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthUI; // Nghe tin đổi máu
        PlayerHealth.OnPlayerDeath += ShowGameOver;     // Nghe tin chết
    }

    // Khi Object này tắt đi -> Hủy đăng ký (BẮT BUỘC để tránh lỗi bộ nhớ)
    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealthUI;
        PlayerHealth.OnPlayerDeath -= ShowGameOver;
    }

    // --- CÁC HÀM XỬ LÝ ---

    // Hàm này tự chạy khi Player báo tin OnHealthChanged
    public void UpdateHealthUI(int currentHp)
    {
        healthText.text = $"HP: {currentHp}";

        // Đổi màu chữ theo máu cho sinh động
        if (currentHp < 30) healthText.color = Color.red;
        else healthText.color = Color.green;
    }

    // Hàm này tự chạy khi Player báo tin OnPlayerDeath
    public void ShowGameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true); // Hiện chữ Game Over lên
            healthText.text = "HP: 0";
        }
    }
}