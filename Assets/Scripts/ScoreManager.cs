using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _hitText;
    private int hitCount = 0;

    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void InrecementHit()
    {
        hitCount += 1;
        _hitText.text = "Hit: " + hitCount.ToString();
    }

}
