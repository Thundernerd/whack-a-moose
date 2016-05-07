using System.Collections;
using UnityEngine;

public class RotationWizard : MonoBehaviour {

    [Header( "David->Christian->Christiaan->Erik->Chi->Yero" )]
    public PersonRotator[] Peeps;

    private string[] chars = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

    void Start() {

    }

    void Update() {
        if ( Input.GetKeyUp( KeyCode.Space ) ) {
            StartCoroutine( FireEmAll() );
        }
    }

    private IEnumerator FireEmAll() {
        for ( int i = 0; i < Peeps.Length; i++ ) {
            Peeps[i].SetLetter( chars[Random.Range( 0, chars.Length )].ToUpper() );
        }

        for ( int i = 0; i < Peeps.Length; i++ ) {
            Peeps[i].Rotate();
            yield return new WaitForSeconds( 0.2f );
        }

        yield break;
    }

    public void Score() {

    }
}
