using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory/EquipmentItem")]
public class EquipmentItem : ItemBase {
    public int attackBonus;
    public int defenseBonus;

    public override void Use() {
        Debug.Log($"We equipped {name}");
    }
}