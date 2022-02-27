using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State {
    Idle=0,
    Walk=1,
    Jump=2,
    Dead=3

}
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    State currentState;
    public float m_Speed = 5f;
    public Vector3 magnitude = new Vector3(0,0,0);
    public Rigidbody m_Rigidbody;
    public bool isAlive = false;
    public GameObject ball;
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public LineRenderer lineRenderer;
    void Update()
    {
        DrawQuadraticBezierCurve(p0.position,  new Vector3(p1.position.x, p1.position.y+1.6f, p1.position.z), p2.position);
    }

    void DrawQuadraticBezierCurve(Vector3 point0, Vector3 point1, Vector3 point2)
    {
        lineRenderer.positionCount = 100;
        float t = 0f;
        Vector3 B = new Vector3(0, 0, 0);
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            B = (1 - t) * (1 - t) * point0 + 2 * (1 - t) * t * point1 + t * t * point2;
            lineRenderer.SetPosition(i, B);
            t += (1 / (float)lineRenderer.positionCount);
        }
        
    }
    public void moveHorizontal(float magnitude)
    {
        p2.position = new Vector3(p2.position.x + magnitude, p2.position.y, p2.position.z);
    }
    public void moveVertical(float magnitude)
    {
        p1.position = new Vector3(p1.position.x , p1.position.y + magnitude, p1.position.z);
    }
    public void shoot()
    {
        StartCoroutine(movePos(0));
         

    }
    IEnumerator movePos(int index)
    {
        ball.transform.position = lineRenderer.GetPosition(index);
        yield return new WaitForSeconds(0.001f);
        if (index + 1 < lineRenderer.positionCount)
        {
            StartCoroutine(movePos(index + 1));
        }
        else
        {
            ball.transform.position = p0.position;
        }
    }
    void Start()
    {
        
    }
    public void SetAlive(bool alive)
    {
        this.isAlive = alive;
    }
    void FixedUpdate()
    {
        //Store user input as a movement vector
        if (isAlive)
        {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            m_Rigidbody.MovePosition(transform.position + magnitude * Time.deltaTime * m_Speed);

        }
    }

 
    public void collide(GameObject obj)
    {
        if (obj.name.Contains("Obstacle"))
        {
            GameManager.instance.GameOver();
        }

    }
    public void ChangeState(State state)
    {
        switch (state)
        {
            case State.Idle: break;
            case State.Dead: break;
            case State.Jump: break;
            case State.Walk: break;

        }

    }
}
