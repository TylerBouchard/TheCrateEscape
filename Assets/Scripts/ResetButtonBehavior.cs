using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonBehavior : MonoBehaviour
{
    public int roomItResets;
    private GameObject[] crates;
    private CrateBehavior crateBehaviorScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if (collision.gameObject.tag == "Player")
        {
            gc.DisplayInstructions("Press [R] to put crates back");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();
        if (collision.gameObject.tag == "Player")
        {
            gc.HideInstructions();
        }
    }
    public void ResetCrates() {
        crates = GameObject.FindGameObjectsWithTag("Crate");
        for (int i = 0; i < crates.Length; i++) {
            print(i);
            crateBehaviorScript = crates[i].GetComponent<CrateBehavior>();
            crateBehaviorScript.ResetCrate(roomItResets);
        }
    }
}
