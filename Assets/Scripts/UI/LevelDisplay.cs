using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    private int level = 0;
    private int levelbefore = 0;
    private EnemySpawner EnemyLevel;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        EnemyLevel = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();
        if (EnemyLevel == null) Debug.Log(EnemyLevel);
        text = GetComponent<TextMeshProUGUI>();
        if(text == null)
        { Debug.Log("leer"); }
        text.text = "";
    }

    void FixedUpdate()
    {
        level = EnemyLevel.level;
        Debug.Log(level);
        if (level > levelbefore) { 
        text.text = "Level" + level;
        levelbefore = level;
        StartCoroutine(ShowHide());
        }
    }
    private IEnumerator ShowHide()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }
}