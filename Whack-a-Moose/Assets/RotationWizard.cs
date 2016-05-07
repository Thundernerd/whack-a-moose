using System.Collections;
using UnityEngine;
using System.Linq;

public class RotationWizard : MonoBehaviour {

    [Header( "David->Christian->Christiaan->Erik->Chi->Yero" )]
    public PersonRotator[] Peeps;

    private string[] chars = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };//, "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
    private int score = 0;

    void Start() {
        var t = chars.ToList();
        for ( int i = 0; i < Peeps.Length; i++ ) {
            var j = Random.Range( 0, t.Count );
            var c = t[j];
            t.RemoveAt( j );

            Peeps[i].SetLetter( c.ToUpper() );
        }

        Peeps[0].Rotate();
    }

    void Update() {

    }

    public void Score() {
        score++;

        if ( score < 6 ) {
            Peeps[score].Rotate();
        }
    }
}
