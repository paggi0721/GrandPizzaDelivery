using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerStat
{
    private Vector3 angle = new Vector3(0, 0, 300);

    private float time;
    public bool Stop = false;
    private bool bananaTrigger = false;
    void Update()
    {
        if (!Stop && !bananaTrigger)
        {
            time += Time.deltaTime;
            if (Input.GetKey(KeyCode.W))
            {
                if (Speed < 0)
                {
                    Speed *= Braking;
                }
                Speed += acceleration * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Speed > 0)
                {
                    Speed *= Braking;
                }
                Speed -= acceleration * Time.deltaTime;
            }
            else
            {
                if (time > 0.01f)
                {
                    Speed *= Braking;
                    time = 0;
                }
            }

            float angleRatio;
            if(Speed > 0)
            {
                angleRatio = Speed / (Speed + (MaxSpeed / 2));
            }
            else
            {
                angleRatio = -(Speed / (Speed + (-MaxSpeed / 2)));
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(angle * angleRatio * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(-angle * angleRatio * Time.deltaTime);
            }
            this.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, Speed);
        }
        else if(Stop && !bananaTrigger)
        {
            Speed = 0;
            this.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, Speed);
        }else if(Stop && bananaTrigger)
        {
            StopCoroutine(bananaCoroutine);
            bananaTrigger = false;
        }
    }
    IEnumerator bananaCoroutine;
    IEnumerator banana(float time, Transform t)
    {
        bananaTrigger = true;
        float count = 0;
        if(Speed >= 0)
            this.GetComponent<Rigidbody2D>().velocity = t.rotation * new Vector2(0, 10);
        else
            this.GetComponent<Rigidbody2D>().velocity = t.rotation * new Vector2(0, -10);
        while (true)
        {
            Debug.Log("코루틴 실행중");
            count += Time.deltaTime;
            this.transform.Rotate(angle * 10 * Time.deltaTime);
            if (count > time)
            {
                bananaTrigger = false;
                break;
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Banana"))
        {
            bananaCoroutine = banana(2, this.transform);
            StartCoroutine(bananaCoroutine);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Police"))
        {
            HP -= (int)(Speed * 1.5 - collision.transform.GetComponent<PoliceCar>().Speed * 1.5 + Speed * (Random.Range(0, 10)) * 0.01);
        }
    }
}
