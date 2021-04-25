using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public GameObject[] PrefabBlock;
    public float triggerlevel;
    public float savepointspawn = 16;

    public Text gametext;
    public bool lose;
    
    void Start()
    {
        triggerlevel = -6;
        lose = false;
    }

    
    void Update()
    {


        if (player != null)
        {
            camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);

            gametext.text = "Score: " + Mathf.Floor(player.transform.position.x);
        } else
        {
            if (!lose)
            {
                lose = true;
                gametext.text += "\nGame Over\nPress R to restart or E to exit";
            }
            if (lose)
            {
                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                if (Input.GetKeyDown("e"))
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }



        while (player != null && triggerlevel<player.transform.position.x + savepointspawn)
        {
            int indblock = Random.Range(0, PrefabBlock.Length - 1);

            if (triggerlevel < 0)
            {
                indblock = 9;
            }
            GameObject ObjBlock = Instantiate(PrefabBlock[indblock]);
            ObjBlock.transform.SetParent(this.transform);
            Block block = ObjBlock.GetComponent<Block>();
            ObjBlock.transform.position = new Vector2(triggerlevel + block.size / 2, 0);
            triggerlevel += block.size;
        }


    }
}
