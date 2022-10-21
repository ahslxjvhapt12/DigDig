using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProficiency : MonoBehaviour
{
    //����ŷ
    private float jumpPower = 1;
    //�� ŷ
    private float damage = 1;
    //�ĸ�ŷ
    private float health = 1;
    //����ŷ
    private float miningSpeed = 1;
    //�ĸ�ŷ
    private float evasion = 1;


    public float JumpPower
    {
        get
        {
            if (jumpPower <= 0)
            {
                return 1;
            }
            else
            {
                return jumpPower;
            }
        }
        set { jumpPower = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float MininngSpeed
    {
        get { return miningSpeed; }
        set { miningSpeed = value; }
    }

    public float Evasion
    {
        get { return evasion; }
        set { evasion = value; }
    }
}
