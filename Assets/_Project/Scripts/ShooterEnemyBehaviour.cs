namespace com.digitalmind.towertest
{
    public class ShooterEnemyBehaviour : EnemyBehaviour
    {
        //TODO - Extract into a Scriptable Object
        public float maxHealth = 2f;
        
        public float speed = 8f;
        public float stoppingDistance = 40f;
        
        public float rateOfFire = 3f;
        public float damagePerShot = 2f;

        public override void SetUpBehaviour(Enemy enemy)
        {
            enemy.SetMaxHealth(maxHealth);
            enemy.SetSpeed(speed);
            enemy.SetStoppingDistance(stoppingDistance);
        }
    }
}