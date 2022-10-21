using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField]
    private List<MineralSO> mineralInfo;
    private float _mineralSpeed;
    public int worldSize = 100;

    // ������
    public Sprite ground;
    public Sprite rockOre;
    public Sprite coalOre;
    public Sprite silverOre;
    public Sprite goldOre;
    public Sprite DiamondOre;

    // ���� ���� Ȯ��
    public float coalSpawnPercent = 12f;
    public float silverSpawnPercent = 7f;
    public float GoldSpawnPercent = 5f;
    public float DiamondSpawnPercent = 0.1f;

    public bool[,] isOreAlive;

    private void Start()
    {
        IsOreSpawn();
        GenerateTerrain();
    }

    private void IsOreSpawn()
    {
        isOreAlive = new bool[worldSize + 1, worldSize + 1];
        for (int x = 0; x < worldSize; x++)
        {
            for (int y = 0; y < worldSize; y++)
            {
                isOreAlive[x, y] = true;
            }
        }
    }


    private void GenerateTerrain()
    {
        for (int x = 0; x > -worldSize; x--)
        {
            for (int y = 0; y > -worldSize; y--)
            {

                //if (isOreAlive[x, y])
                //{
                GameObject newObj = new();

                newObj.AddComponent<SpriteRenderer>();
                newObj.AddComponent<MineralScript>();
                newObj.AddComponent<BoxCollider2D>();
                newObj.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                newObj.transform.parent = this.transform;
                newObj.transform.position = new Vector2(x, y);
                newObj.layer = LayerMask.NameToLayer("Mineral");
                newObj.GetComponent<BoxCollider2D>().isTrigger = false;
                newObj.GetComponent<SpriteRenderer>().color = Color.white;
                newObj.GetComponent<SpriteRenderer>().sprite = ground;
                int OreSpawnPercent = UnityEngine.Random.Range(0, 100);
                if (y >= -2)
                {
                    newObj.GetComponent<SpriteRenderer>().sprite = ground;
                    newObj.GetComponent<SpriteRenderer>().color = Color.red;
                    newObj.GetComponent<MineralScript>().MineralType = MineralType.Ground;
                }
                else
                {
                    if (newObj.GetComponent<SpriteRenderer>().sprite == ground)
                    {
                        if (y >= -5)//��
                        {
                            newObj.GetComponent<SpriteRenderer>().sprite = rockOre;
                            newObj.GetComponent<SpriteRenderer>().color = Color.gray;
                            newObj.GetComponent<MineralScript>().MineralType = MineralType.Rock;
                        }
                        if (y <= -5 && y >= -50)// ��ź
                        {
                            //int coalSpawnPoint = UnityEngine.Random.Range(0, 100);
                            if (OreSpawnPercent < coalSpawnPercent)
                            {
                                newObj.GetComponent<SpriteRenderer>().sprite = coalOre;
                                newObj.GetComponent<SpriteRenderer>().color = Color.black;
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Coal;
                            }
                        }
                        if (y <= -7 && y >= -35)// �ǹ�
                        {
                            if (OreSpawnPercent < silverSpawnPercent)
                            {
                                newObj.GetComponent<SpriteRenderer>().sprite = silverOre;
                                newObj.GetComponent<SpriteRenderer>().color = Color.cyan;
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Silver;
                            }

                        }
                        if (y <= -13 && y >= -45)// ���
                        {
                            if (OreSpawnPercent < GoldSpawnPercent)
                            {
                                newObj.GetComponent<SpriteRenderer>().sprite = goldOre;
                                newObj.GetComponent<SpriteRenderer>().color = Color.yellow;
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Gold;
                            }

                        }
                        if (y <= -60 && y >= -80)// ���̾�
                        {
                            if (OreSpawnPercent < DiamondSpawnPercent)
                            {
                                newObj.GetComponent<SpriteRenderer>().sprite = DiamondOre;
                                newObj.GetComponent<SpriteRenderer>().color = Color.blue;
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Diamond;
                            }
                        }
                    }
                }
            }
        }
    }
}