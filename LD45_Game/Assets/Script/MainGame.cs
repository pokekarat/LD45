using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public static int[,] cells = new int[16, 12];

    public GameObject block;
    public GameObject home;
    public GameObject player;

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

        //Home
        int hx = Random.Range(0,15);
        int hy = Random.Range(0,12);
        Vector3 homePoint = new Vector3(hx * 64, hy * 64, 0);
        Vector3 hp = Camera.main.ScreenToWorldPoint(homePoint);
        hp.z = 0;
        hp.x += 0.4f;
        hp.y += 0.4f;

        Instantiate(
                    home,
                    hp,
                    Quaternion.identity
                );

        //Player
        int px = 0;
        if(hx < 8)
            px = Random.Range(9,15);
        else
            px = Random.Range(0,8);

        Vector3 pPoint = new Vector3(px * 64, 800, 0);
        Vector3 pp = Camera.main.ScreenToWorldPoint(pPoint);
        pp.z = 0;
        pp.x += 0.4f;
        pp.y += 0.4f;

        Instantiate(
                    player,
                    pp,
                    Quaternion.identity
                );
    }

    // Update is called once per frame
    void Update()
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
}
