using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class DummyUnit : MonoBehaviour
{
    [Header("Movement (Lab 2)")]
    public float speed = 5f;

    [Header("Health & Events (Lab 6)")]
    public int maxHp = 100;
    private int currentHp;

    // Định nghĩa Event gửi kèm số máu
    [System.Serializable] public class HealthEvent : UnityEvent<int> { }

    public HealthEvent OnHit;      // Khi bị bắn
    public UnityEvent OnDead;      // Khi chết

    void Start()
    {
        currentHp = maxHp;
        OnHit?.Invoke(currentHp); // Cập nhật UI ban đầu
    }

    void Update()
    {
        // --- PHẦN DI CHUYỂN (LAB 2) ---
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        // Normalize để không chạy chéo nhanh (Tiêu chí: Di chuyển ổn định)
        if (dir.magnitude > 1) dir.Normalize();

        transform.Translate(dir * speed * Time.deltaTime);
    }

    // Hàm nhận sát thương (được gọi bởi Turret)
    public void TakeDamage(int damage)
    {
        if (currentHp <= 0) return;

        currentHp -= damage;
        // Bắn Event ra ngoài
        OnHit?.Invoke(currentHp);

        if (currentHp <= 0)
        {
            OnDead?.Invoke();
            gameObject.SetActive(false); // Biến mất
        }
    }
}