using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PersonRotator : MonoBehaviour {

    public GameObject N1;
    public GameObject N2;

    private SpriteRenderer s1;
    private SpriteRenderer s2;

    void Start() {
        s1 = N1.GetComponent<SpriteRenderer>();
        s2 = N2.GetComponent<SpriteRenderer>();

        s2.enabled = false;
    }

    void Update() {
        if ( Input.GetKeyUp( KeyCode.A ) ) {
            Rotate();
        } else if ( Input.GetKeyUp( KeyCode.S ) ) {
            RotateBack();
        }
    }

    public void Rotate() {
        LeanTween.cancel( gameObject );
        LeanTween.value( gameObject, 0, 180, 0.35f ).setEase( LeanTweenType.easeOutBack )
            .setOnUpdate( ( float value ) => {
                var euler = Quaternion.Euler( 0, value, 0 );
                N1.transform.rotation = euler;
                N2.transform.rotation = euler;
                //transform.rotation = Quaternion.Euler( 0, value, 0 );
                if ( value >= 90 && s1.enabled ) {
                    s1.enabled = false;
                    s2.enabled = true;
                }
            } ).setOnComplete( () => {

            } );
    }

    public void RotateBack() {
        LeanTween.cancel( gameObject );
        LeanTween.value( gameObject, 180, 0, 0.35f ).setEase( LeanTweenType.easeOutBack )
            .setOnUpdate( ( float value ) => {
                var euler = Quaternion.Euler( 0, value, 0 );
                N1.transform.rotation = euler;
                N2.transform.rotation = euler;
                //transform.rotation = Quaternion.Euler( 0, value, 0 );
                if ( value <= 90 && s2.enabled ) {
                    s1.enabled = true;
                    s2.enabled = false;
                }
            } ).setOnComplete( () => {

            } );
    }
}
