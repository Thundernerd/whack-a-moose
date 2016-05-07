using UnityEngine;
using UnityEngine.UI;

public class PersonRotator : MonoBehaviour {

    public GameObject N1;
    public GameObject N2;
    public GameObject N3;

    private SpriteRenderer s1;
    private SpriteRenderer s2;

    private Image img;
    private Text txt;

    private KeyCode key;

    [Component( "Main Camera" )]
    private RotationWizard wizard;

    void Awake() {
        s1 = N1.GetComponent<SpriteRenderer>();
        s2 = N2.GetComponent<SpriteRenderer>();

        img = N3.GetComponent<Image>();
        txt = N3.GetComponentInChildren<Text>();

        s2.enabled = false;
        img.enabled = false;
        txt.enabled = false;

        this.LoadComponents();
    }

    void Update() {
        if ( Input.GetKeyUp( key ) ) {
            wizard.Score();
            RotateBack();
        }
    }

    public void SetLetter( string value ) {
        txt.text = value;
        key = Event.KeyboardEvent( value ).keyCode;
    }

    public void Rotate() {
        LeanTween.cancel( gameObject );
        LeanTween.value( gameObject, 0, 180, 0.35f ).setEase( LeanTweenType.easeOutBack )
            .setOnUpdate( ( float value ) => {
                var euler = Quaternion.Euler( 0, value, 0 );
                N1.transform.rotation = euler;
                N2.transform.rotation = euler;
                if ( value >= 90 && s1.enabled ) {
                    s1.enabled = false;
                    s2.enabled = true;
                    img.enabled = true;
                    txt.enabled = true;
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
                if ( value <= 90 && s2.enabled ) {
                    s1.enabled = true;
                    s2.enabled = false;
                    img.enabled = false;
                    txt.enabled = false;
                }
            } ).setOnComplete( () => {

            } );
    }
}
