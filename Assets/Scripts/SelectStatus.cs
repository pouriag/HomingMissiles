using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStatus : MonoBehaviour
{
    // Start is called before the first frame update
    private bool selected = false;
    public bool get(){
        return selected;
    } 
    public void set(bool state){
        this.selected = state;
    }
}
