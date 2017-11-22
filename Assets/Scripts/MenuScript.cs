using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject levelButton;
    public GameObject levelButtonContainer;
    public GameObject shopButton;
    public GameObject shopButtonContainer;

    private Transform _cameraTransform;
    private Transform _cameraPrefferedLookat;

    private const float _rotationSpeed = 2.5f;
    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        for (int i = 0; i < 3; i++)
        {
            GameObject container = Instantiate(levelButton) as GameObject;
            
            container.transform.SetParent(levelButtonContainer.transform,false);
          
            string levelName = levelButton.name + i.ToString();
            container.GetComponent<Button>().onClick.AddListener(() => _LoadLevel(levelName)); 
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject container = Instantiate(shopButton) as GameObject;

            container.transform.SetParent(shopButtonContainer.transform, false);

            string shopName = shopButton.name + i.ToString();
            container.GetComponent<Button>().onClick.AddListener(() => _shopItem(shopName));
        }


    }

    private void Update()
    {
        if(_cameraPrefferedLookat != null)
        {
            _cameraTransform.rotation = Quaternion.Slerp(_cameraTransform.rotation, _cameraPrefferedLookat.rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void _LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    private void _shopItem(string shopName)
    {
        SceneManager.LoadScene(shopName);
    }

    public void LookAtMenu(Transform menuTransform)
    {
        _cameraPrefferedLookat = menuTransform;
    }
}
