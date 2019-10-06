using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speedx = 2.0f;

    float jumpForce = 20.0f;

    Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(speedx * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        Vector3 t = transform.position;
        if (t.x > -10 && t.x < 10 && t.y > -5 && t.y < 5)
        {
            Vector3 v = Camera.main.WorldToScreenPoint(t);
            //check current cell
            int x = ((int)v.x) / 64;
            int y = ((int)v.y) / 64;

            if (speed.x > 0)
            {
                if (MainGame.cells[x + 1, y] == 1 && MainGame.cells[x + 1, y + 1] == 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
                }
                else if ((MainGame.cells[x + 1, y] == 1 && MainGame.cells[x + 1, y + 1] == 1) || (transform.position.x > 5.5))
                {
                    speed.x *= -1.0f;

                    //flip x
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
            }
            else if (speed.x < 0)
            {
                if (MainGame.cells[x - 1, y] == 1 && MainGame.cells[x - 1, y + 1] == 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
                }
                else if (MainGame.cells[x - 1, y] == 1 && MainGame.cells[x - 1, y + 1] == 1 || (transform.position.x < -5.5))
                {
                    speed.x *= -1.0f;

                    //flip x
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
            }

            transform.Translate(speed);
        }
    }
}
