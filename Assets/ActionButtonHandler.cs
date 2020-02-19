using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
    private bool buttonWasPressed;
    private bool buttonPressed;
    public bool buttonDown;

    void Update(){
        if(!buttonWasPressed && buttonPressed){
            buttonDown = true;
        }else{
            buttonDown = false;
        }
        buttonWasPressed = buttonPressed;
    }
    
    public void OnPointerDown(PointerEventData eventData){
        buttonPressed = true;
    }
    
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
    }

}
