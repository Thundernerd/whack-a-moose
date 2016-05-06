using System.Collections;
using UnityEngine;

public class RotationWizard : MonoBehaviour {

    [Header( "David->Christian->Christiaan->Erik->Chi->Yero" )]
    public PersonRotator[] Peeps;

    void Start() {

    }

    void Update() {
        if ( Input.GetKeyUp( KeyCode.Space ) ) {
            StartCoroutine( FireEmAll() );
        }
    }

    private IEnumerator FireEmAll() {
        for ( int i = 0; i < Peeps.Length; i++ ) {
            Peeps[i].Rotate();
            yield return new WaitForSeconds( 0.2f );
        }

        yield break;
    }
}
