using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField] float steerSpeed = 300f;
  [SerializeField] float moveSpeed = 20f;
  [SerializeField] float slowSpeed = 15f;
  [SerializeField] float boostSpeed = 30f;

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Boost") {
      moveSpeed = boostSpeed;
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
    moveSpeed = slowSpeed;
  }
  private void Update()
  {
    float d = Time.deltaTime;
    float steerAmount = -Input.GetAxis("Horizontal") * steerSpeed * d;
    float moveAmount = Input.GetAxis("Vertical") * moveSpeed * d;
    transform.Rotate(0, 0, steerAmount);
    transform.Translate(0, moveAmount, 0);
  }
}
