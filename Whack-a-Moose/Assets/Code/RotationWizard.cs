using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RotationWizard : MonoBehaviour {

    [Header( "David->Christian->Christiaan->Erik->Chi->Yero" )]
    public PersonRotator[] Peeps;

    private string[] chars = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };//, "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

    private float timeInBetween = 2f;
    private int score = 0;
    private bool startedRandom = false;

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
        } else if ( !startedRandom ) {
            startedRandom = true;
            StartCoroutine( RandomRotates() );
        }

        GameObject.Find( "Text" ).GetComponent<Text>().text = "Score: " + score;
    }

    public void Fail() {
        score--;
        GameObject.Find( "Text" ).GetComponent<Text>().text = "Score: " + score;
    }

    private IEnumerator RandomRotates() {
        while ( true ) {
            Peeps[Random.Range( 0, 6 )].Rotate( timeInBetween );
            yield return new WaitForSeconds( timeInBetween );
            timeInBetween *= 0.98f;
        }

        //yield break;
    }
}
