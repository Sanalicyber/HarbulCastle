namespace SmugTowerDefense.Behaviours.Soldiers
{
    public class Mage : Soldier
    {
        private void OnValidate()
        {
            attackType = AttackType.Ranged;
        }
    }
}