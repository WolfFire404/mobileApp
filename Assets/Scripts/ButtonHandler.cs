using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {
    
    [SerializeField]
    private GameObject _scoreButton;
    [SerializeField]
    private GameObject _potButton;
    [SerializeField]
    private GameObject _bigPotButton;
    [SerializeField]
    private MenuScript menuscript;
    [SerializeField]
    private GameObject _startScreen;

    [SerializeField]
    private Text _pickaxeUP;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _shopText;
    [SerializeField]
    private Text _minerText;
    [SerializeField]
    private Text _hardwareText;

    private float _score;
    private float _scoreGained;
    private float _scoreEnhancer = 1;
    private float _scoreNeeded;
    private float _costMultiplier;
    private float _minerWorth;
    private float _minerCount;
    private float _minerCost;
    private float _hardwareUP;
    private bool _minerActive;
        
    
    void Start()
    {
        _hardwareUP = 500;
        _minerCost = 200;
        _minerActive = false;
        _minerCount = 0f;
        _minerWorth = 1f;
        _costMultiplier = 1.5f;
        _scoreNeeded = 50;
        _scoreGained = 1;
        _score = 100000;
        _scoreText.text = _score.ToString();
        _hardwareText.text = "Score: " + _hardwareUP.ToString();
        _minerText.text = "score: " + _minerCost.ToString();
        _pickaxeUP.text = "Score: " + _scoreNeeded;
       
    }
     
    void Update()
    {
        _shopText.text = _score.ToString();
        _hardwareText.text = "Score: " + _hardwareUP.ToString();
    }

    public void StartButton()
    {
               _startScreen.SetActive(false);
    }

     public void ScoreButton()
    {
        _score += _scoreGained * _scoreEnhancer;
        _scoreText.text = _score.ToString();
        Mathf.FloorToInt(_score);
       
    }

    public void ScoreEnhancer()
    {
        if(_score >= _scoreNeeded)
        {
            
            _score -= Mathf.FloorToInt(_scoreNeeded);
            
            _scoreNeeded *= _costMultiplier;
            _scoreEnhancer *= 2;
           
            _scoreText.text = _score.ToString();
            Mathf.FloorToInt(_score);
            _pickaxeUP.text = "Score: " + Mathf.Floor(_scoreNeeded);
           
        }
    }
    public void SmallGamble()
    {
        if(_score >= 10)
        {
            _score -= 10;
            int gamble = Random.Range(5, 14);
            _score = _score + gamble;
            _scoreText.text = _score.ToString();
           
        }
        
    }

    public void MediumGamble()
    {
        if (_score >= 100)
        {
            _score -= 100;
            int gamble = Random.Range(50, 140);
            _score = _score + gamble;
            _scoreText.text = _score.ToString();
            
        }
        
    }

    public void BigGamble()
    {
        if (_score >= 1000)
        {
            _score -= 1000;
            int gamble = Random.Range(500, 1400);
            _score = _score + gamble;
            _scoreText.text = _score.ToString();
            

        }
        
    }

    IEnumerator minerTimer()
    {
        while (true)
        {
            _score = _score + (_minerWorth * _minerCount);
            yield return new WaitForSeconds(1);
            _scoreText.text = _score.ToString();
        }
        
    }

    public void buyMiner()
    {
        if(_score >= _minerCost)
        {
            _score -= _minerCost;
            if(_minerActive == false)
            {
                _minerCount++;
                StartCoroutine(minerTimer());
                _minerActive = true;
                
            }
            else
            {
                _minerCount++;
                
            }
            _minerCost += 50;
            _minerText.text = "Cost: " + _minerCost.ToString();
            _scoreText.text = _score.ToString();
        }

    
    }

    public void HardwareUpgrade()
    {
        if(_score >= _hardwareUP)
        {
            _score -= _hardwareUP;
            _minerWorth += _minerWorth;
            _hardwareUP *= 4f;
        }
    }
}
