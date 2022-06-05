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
            // 상대 게임 오브젝트에서 컴포넌트 가지고 옴
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 컴포넌트를 잘 가지고 왔다면
            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
