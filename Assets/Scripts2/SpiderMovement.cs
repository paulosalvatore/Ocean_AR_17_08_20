using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float speed = 0.2f;

    public float rotationSpeed = 5f;

    public Vector3 targetPosition;

    public Animator anim;

    private void Update()
    {
        var initialPosition = transform.position;

        var finalPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        transform.position = finalPosition;

        var direction = finalPosition - initialPosition;

        var distance = Vector3.Distance(finalPosition, initialPosition);

        if (distance > 0 && direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
