using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance;
    public GameObject ResultPrefab;
    public GameObject Throwable;
    [HideInInspector] public float StartVelocity;
    float _maxHeight;
    float _prevHeight;
    float timer;
    Vector2 _prevThrowablePos;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _maxHeight = 0;
        _prevHeight = Throwable.transform.position.y;

        _prevThrowablePos = Throwable.transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Throwable.transform.position.y > _prevHeight)
        {
            _maxHeight = Throwable.transform.position.y - _prevThrowablePos.y;
            _prevHeight = Throwable.transform.position.y;
        }
    }

    public void Results()
    {
        var result = Instantiate(ResultPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        result.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Throwable.transform.position.x - _prevThrowablePos.x).ToString() + "m";
        result.transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _maxHeight.ToString() + "m";
        result.transform.GetChild(2).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = StartVelocity.ToString() + "m/s";
        result.transform.GetChild(2).transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = timer.ToString() + "s";
    }
}
