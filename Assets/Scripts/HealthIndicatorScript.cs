using UnityEngine;
using System.Collections;

public class HealthIndicatorScript : MonoBehaviour {

    public Sprite HighHealth;
    public Sprite MediumHealth;
    public Sprite LowHealth;

    EnemyAI enemyScript;

    double halfHealth;
    double quarterHealth;

	// Use this for initialization
	void Start () {
        enemyScript = this.GetComponentInParent<EnemyAI>();
        halfHealth = enemyScript.health / 2;
        quarterHealth = enemyScript.health / 4;
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyScript.health <= halfHealth)
        {
            this.GetComponentInParent<SpriteRenderer>().sprite = MediumHealth;
        }
        else if (enemyScript.health <= quarterHealth)
        {
            this.GetComponentInParent<SpriteRenderer>().sprite = LowHealth;
        }
        else
        {
            this.GetComponentInParent<SpriteRenderer>().sprite = HighHealth;
        }
	}
}
