using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public static int[,] cells = new int[16, 12];

    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                cells[i, j] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Input.mousePosition;
            Debug.Log("mousePos = " + mousePos);
            if (mousePos.x > 10 && mousePos.x < 1014 && mousePos.y > 0 && mousePos.y < 718)
            {

                int xIndex = ((int)mousePos.x / 64);
                int yIndex = ((int)mousePos.y / 64);
                //Debug.Log(xIndex + " , " + yIndex);
                if (cells[xIndex, yIndex] == 0)
                {
                    cells[xIndex, yIndex] = 1;
                    Vector3 blockPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //Debug.Log("mouse position "+blockPoint);

                    blockPoint = new Vector3(xIndex * 64, yIndex * 64, 0);
                    Vector3 _blockPoint = Camera.main.ScreenToWorldPoint(blockPoint);
                    _blockPoint.z = 0;
                    _blockPoint.x += 0.4f;
                    _blockPoint.y += 0.4f;
                    //Debug.Log(_blockPoint);

                    GameObject blockObj = Instantiate(
                        block,
                        _blockPoint,
                        Quaternion.identity
                    );

                }
            }
        }

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right button.");


    }
}
