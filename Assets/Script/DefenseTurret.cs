using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTurret : MonoBehaviour
{
    public DummyUnit target; // Kéo Dummy vào đây
    public float rotateSpeed = 50f;
    public float fireRate = 0.5f; // Bắn 0.5s một lần
    private float nextFireTime;

    void Update()
    {
        if (target == null || !target.gameObject.activeSelf) return;

        // --- PHẦN XOAY (LAB 3) ---
        Vector3 dirToTarget = target.transform.position - transform.position;
        dirToTarget.y = 0; // Khóa trục Y

        // Xoay mượt (Tiêu chí: Xoay đúng)
        Quaternion targetRot = Quaternion.LookRotation(dirToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);

        // --- PHẦN BẮN (LOGIC LAB 4) ---
        // Tính góc lệch giữa nòng súng và mục tiêu
        float angle = Vector3.Angle(transform.forward, dirToTarget);

        // Nếu góc lệch nhỏ hơn 5 độ (đã ngắm trúng) VÀ khoảng cách đủ gần (< 10m)
        if (angle < 5f && dirToTarget.magnitude < 10f)
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }

        // Vẽ tia debug
        Debug.DrawRay(transform.position, transform.forward * 10, angle < 5f ? Color.red : Color.green);
    }

    void Shoot()
    {
        Debug.Log("Bắn trúng!");
        target.TakeDamage(10); // Gọi hàm trừ máu của Dummy
    }
}