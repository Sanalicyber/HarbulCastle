namespace SmugTowerDefense.Behaviours.Soldiers
{
    public class Warrior : Soldier
    {
        private void OnValidate()
        {
            attackType = AttackType.Melee;
        }
    }
}