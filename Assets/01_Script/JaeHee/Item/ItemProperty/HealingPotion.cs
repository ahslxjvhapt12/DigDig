using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Potion/HealingPotion")]
public class HealingPotion : UseItem
{
    public int healAmount;
    public override bool ExecuteRole()
    {
        //���ӸŴ����� �÷��̾� hp �����ؼ� ȸ����Ű��
        Debug.Log($"��?�� {healAmount}");
        return true;
    }

}
