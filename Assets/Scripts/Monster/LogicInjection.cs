using UnityEngine;

public class LogicInjection : MonoBehaviour
{
    public float speed;
    public GameObject explodeEffect;

    public enum MonsterType
    {
        Default,
        Smart,
        Pussy,
        Drunk,
        Old,
        Size
    }

    static readonly float[] Probability = { 0.05f, 0.45f, 0.2f, 0.2f, 0.1f };

    MonsterType GetRandomType()
    {
        float rand = Random.value;
        for (int i = 0; i < Probability.Length; i++)
        {
            if (rand < Probability[i])
            {
                return (MonsterType)i;
            }
            rand -= Probability[i];
        }
        return MonsterType.Default;
    }

    private void Start()
    {
        //MonsterType type = (MonsterType)Random.Range(0, (int)MonsterType.Size);
        MonsterType type = GetRandomType();
        Monster comp = null;
        switch (type)
        {
            case MonsterType.Default:
                comp = gameObject.AddComponent<Monster>();
                break;
            case MonsterType.Smart:
                SmartMonster smartComp = gameObject.AddComponent<SmartMonster>();
                smartComp.searchPeriod = 1.0f;
                comp = smartComp;
                break;
            case MonsterType.Pussy:
                PussyMonster pussyComp = gameObject.AddComponent<PussyMonster>();
                pussyComp.minPussyCount = 1;
                pussyComp.maxPussyCount = 5;
                pussyComp.pussyRange = 2.0f;
                pussyComp.runTime = 1.5f;
                pussyComp.runSpeedUp = 1.8f;
                comp = pussyComp;
                break;
            case MonsterType.Drunk:
                DrunkMonster drunkComp = gameObject.AddComponent<DrunkMonster>();
                drunkComp.maxOffsetAngle = 90f;
                drunkComp.swingSpeed = 90f;
                comp = drunkComp;
                break;
            case MonsterType.Old:
                OldMonster oldComp = gameObject.AddComponent<OldMonster>();
                oldComp.searchPeriod = 2.5f;
                comp = oldComp;
                break;
        }
        comp.speed = speed;
        comp.explodeEffect = explodeEffect;
    }
}
