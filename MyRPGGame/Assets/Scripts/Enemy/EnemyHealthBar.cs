using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject healthBarPrefab; // 血条预制体
    private GameObject healthBarInstance; // 实例化的血条
    private Slider healthBarSlider; // 血条的 Slider
    private Transform healthBarAnchor; // 血条挂点

    public int exp = 20;

    public int maxHealth = 100; // 最大生命值
    private int currentHealth; // 当前生命值

    public float takeDamageTime = 0.5f;
    private float takeDamageTimer = 0f; 
    private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        canvasTransform = GameObject.Find("WorldCanvas").transform;

        // 实例化血条
        healthBarInstance = Instantiate(healthBarPrefab, canvasTransform, false);
        healthBarSlider = healthBarInstance.GetComponent<Slider>();

        // 将血条挂点设置到敌人头部
        healthBarAnchor = transform.Find("HPUI");
    }

    // Update is called once per frame
    void Update()
    {
        takeDamageTimer += Time.deltaTime;
        if (healthBarInstance)
        {
            // 血条跟随敌人头部
            healthBarInstance.transform.position = healthBarAnchor.position;

            // 更新血条
            healthBarSlider.value = currentHealth * 1.0f / maxHealth;
        }
    }

    public void TakeDamage(int attackValue){
        if(takeDamageTimer > takeDamageTime){
            takeDamageTimer = 0f;
            currentHealth -= attackValue;
            if (currentHealth <= 0)
            {
                PlayerPropertyUI.Instance.AddExp(20);
                Destroy(healthBarInstance); // 移除血条
                Destroy(gameObject); // 销毁敌人
            }

            // 获取当前物体的 Transform
            Transform enemyTransform = this.transform;

            // 计算击飞方向（沿物体的后方方向）
            Vector3 knockbackDirection = -enemyTransform.forward;

            // 设置击飞距离
            float knockbackDistance = 2f;

            // 计算目标位置
            Vector3 targetPosition = enemyTransform.position + knockbackDirection * knockbackDistance;

            // 平滑击飞：使用协程进行移动
            StartCoroutine(KnockbackCoroutine(targetPosition));
        }

        
        
        
    }

    private IEnumerator KnockbackCoroutine(Vector3 targetPosition)
    {
        float duration = 0.2f; // 击飞动画的持续时间
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }

        // 确保击飞结束时位置正确
        transform.position = targetPosition;
    }
}
