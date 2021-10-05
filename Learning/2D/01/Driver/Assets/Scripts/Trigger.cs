using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Color32 holdPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    private bool hasPackage = false;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Pickup")){
            if(hasPackage){
                Debug.Log("Already have package");
            } else {
                Debug.Log("pickup");
                hasPackage = true;    
                spriteRenderer.color = holdPackageColor;
                Destroy(other.gameObject, 0f);
            }
            
        } else if(other.tag.Equals("Dropoff")){
            if(hasPackage){
                Debug.Log("dropoff");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            } else {
                Debug.Log("Don't have package");
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
       // Debug.Log("exited");
    }
}
