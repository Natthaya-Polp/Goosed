using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 5f;

    private Vector2[] waypoints;
    private int currentWaypointIndex;
    private bool isFollowingPath = false;
    private bool isReturning = false;

    private void Start()
    {
        // เก็บจุดที่เป็น waypoint จาก line renderer
        waypoints = new Vector2[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            waypoints[i] = lineRenderer.GetPosition(i);
        }
    }

    private void Update()
    {
        if (isFollowingPath)
        {
            if (isReturning)
            {
                // เคลื่อนที่กลับไปยัง waypoint ต่อไปในลำดับย้อนกลับ
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);

                if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.001f)
                {
                    currentWaypointIndex--;
                    if (currentWaypointIndex < 0)
                    {
                        // เคลื่อนที่ไปยังจุดเริ่มต้นเมื่อกลับสู่จุดสุดท้ายของเส้นทาง
                        isFollowingPath = false;
                    }
                }
            }
            else
            {
                // เคลื่อนที่ไปยัง waypoint ต่อไปในลำดับ
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);

                if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.001f)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                    {
                        // เมื่อเคลื่อนที่ถึงสุดของเส้นทาง
                        currentWaypointIndex = waypoints.Length - 1;
                        isReturning = true;
                    }
                }
            }
        }
        else
        {
            // เคลื่อนที่อิสระ
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // เมื่อสัมผัส collider ที่ตั้งไว้
        if (collision.gameObject.CompareTag("Spline"))
        {
            isFollowingPath = true;
            isReturning = false;
            currentWaypointIndex = 0;
        }
    }
}
