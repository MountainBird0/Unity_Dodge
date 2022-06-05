using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
  
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // ��� ���� ������Ʈ���� ������Ʈ ������ ��
            PlayerController playerController = other.GetComponent<PlayerController>();

            // ������Ʈ�� �� ������ �Դٸ�
            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
