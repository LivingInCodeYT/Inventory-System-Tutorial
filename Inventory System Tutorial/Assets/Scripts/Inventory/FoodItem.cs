using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Inventory/FoodItem")]
public class FoodItem : ItemBase {
    public int foodRestoreOnEat = 3;

    public override void Use() {
        Debug.Log($"We ate {name} to restore {foodRestoreOnEat} food!");
    }
}