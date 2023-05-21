namespace SmugTowerDefense.Behaviours.Soldiers
{
    public class Archer : Soldier
    {
        private void OnValidate()
        {
            attackType = AttackType.Ranged;
        }
    }
}