using Mirror;
using SmugTowerDefense.Management;
using UnityEngine;

namespace SmugTowerDefense.Behaviours.Soldiers
{
    public class Soldier : NetworkBehaviour
    {
        public int teamId;
        public AttackType attackType;
        public float attackSpeed = 1.0f;
        public float attackValue = 1.0f;
        public float health = 10.0f;
        public float movementSpeed = 1.0f;
        public float range = 1.0f;

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0.0f)
            {
                Destroy(gameObject);
            }
        }

        public void Attack(Soldier target)
        {
            target.TakeDamage(attackValue);
        }

        public void Move(Vector3 direction)
        {
            transform.position += movementSpeed * Time.deltaTime * direction;
        }

        private void Update()
        {
            if (!isServer)
            {
                return;
            }

            var target = FindClosestTarget();
            if (target == null)
            {
                return;
            }

            if (Vector3.Distance(transform.position, target.transform.position) <= range)
            {
                Attack(target);
            }
            else
            {
                Move((target.transform.position - transform.position).normalized);
            }
        }

        private Soldier FindClosestTarget()
        {
            var closestTarget = default(Soldier);
            var closestDistance = float.MaxValue;
            foreach (var target in SoldierManagement.Instance.GetSoldiers())
            {
                if (target == this || target.teamId == teamId)
                {
                    continue;
                }

                var distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < closestDistance)
                {
                    closestTarget = target;
                    closestDistance = distance;
                }
            }

            return closestTarget;
        }
    }
}