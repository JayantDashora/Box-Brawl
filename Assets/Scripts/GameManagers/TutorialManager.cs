using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialManager : MonoBehaviour
{

    // Variables

    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private string firstInstruction;
    [SerializeField] private string secondInstruction;
    [SerializeField] private string thirdInstruction;
    [SerializeField] private string fourthInstruction;
    [SerializeField] private string fifthInstruction;
    void Start(){
        StartCoroutine("Tutorial");
    }

    private IEnumerator Tutorial(){
        yield return new WaitForSeconds(3);
        tutorialText.text = firstInstruction;
        yield return new WaitForSeconds(5);
        tutorialText.text = secondInstruction;
        yield return new WaitForSeconds(5);
        tutorialText.text = thirdInstruction;
        yield return new WaitForSeconds(5);
        tutorialText.text = fourthInstruction;
        yield return new WaitForSeconds(5);
        tutorialText.text = fifthInstruction;
        yield return new WaitForSeconds(5);
        Destroy(tutorialText);
    }
}
