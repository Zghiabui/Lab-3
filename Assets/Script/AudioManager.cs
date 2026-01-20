using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    void OnEnable()
    {
        // Audio cũng đăng ký lắng nghe y hệt UI
        PlayerHealth.OnHealthChanged += PlayHurtSound;
        PlayerHealth.OnPlayerDeath += PlayDeathSound;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= PlayHurtSound;
        PlayerHealth.OnPlayerDeath -= PlayDeathSound;
    }

    void PlayHurtSound(int hp)
    {
        // Ở đây mình chỉ Log ra console giả lập âm thanh
        // Thực tế bạn sẽ dùng AudioSource.Play()
        Debug.Log("🔊 AUDIO: Phát tiếng rên rỉ (Á á...)");
    }

    void PlayDeathSound()
    {
        Debug.Log("🔊 AUDIO: Phát nhạc đám ma (Tèn ten ten...)");
    }
}