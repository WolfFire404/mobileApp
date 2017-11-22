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
    public GameObject imageField;

    [SerializeField]
    private GameObject _startBtn;
    

    private Transform _cameraTransform;
    private Transform _cameraPrefferedLookat;
    

    private const float _rotationSpeed = 2.5f;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if(_cameraPrefferedLookat != null)
        {
            _cameraTransform.rotation = Quaternion.Slerp(_cameraTransform.rotation, _cameraPrefferedLookat.rotation, _rotationSpeed * Time.deltaTime);
        }
    }



        public void LookAtMenu(Transform menuTransform)
    {
        _cameraPrefferedLookat = menuTransform;
    }

   


}
