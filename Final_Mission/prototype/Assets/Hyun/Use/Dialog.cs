using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialog : MonoBehaviour
{
    // Use this for initialization
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.15f;
    public float CharacterRateMultuplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.Return;
    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndofDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

    public GameObject Me;
    public GameObject Boss;
    void Start()
    {
        DialogueStrings = new string[5];
        DialogueStrings[0] = "야 임마";
        DialogueStrings[1] = "잘해라!";
        DialogueStrings[2] = "바빠도 열심히 하고!";
        DialogueStrings[3] = "안 바쁘면 더 열심히하고!";
        DialogueStrings[4] = "졸업하고 취업하자!";
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
        moveSetting();
        HideIcons();
        _isDialoguePlaying = true;
        StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    if (!_isStringBeingRevealed)
        //    {
        //        _isDialoguePlaying = true;
        //        StartCoroutine(StartDialogue());
        //    }
        //}
    }
    private IEnumerator StartDialogue()
    {
        int dialogueLengh = DialogueStrings.Length;
        int currentDialogueIndex = 0;
        while (currentDialogueIndex < dialogueLengh || !_isStringBeingRevealed)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                moveImage(currentDialogueIndex);
                StartCoroutine(DisplatStrings(DialogueStrings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLengh)
                    _isEndofDialogue = true;
            }
            yield return 0;
        }
        while (true)
        {
            if (Input.GetKeyDown(DialogueInput)) break;
            yield return 0;
        }
        HideIcons();
        _isEndofDialogue = false;
        _isDialoguePlaying = false;
    }
    private IEnumerator DisplatStrings(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCaracterIndex = 0;
        HideIcons();
        _textComponent.text = "";
        while (currentCaracterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCaracterIndex];
            currentCaracterIndex++;
            if (currentCaracterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {

                    yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultuplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else break;
        }
        ShowIcon();
        while (true)
        {
            if (Input.GetKeyDown(DialogueInput)) break;

            yield return 0;
        }
        HideIcons();
        _isStringBeingRevealed = false;
        _textComponent.text = "";
    }
    private void HideIcons()
    {
        ContinueIcon.SetActive(false);
        StopIcon.SetActive(false);
    }
    private void ShowIcon()
    {
        if (_isEndofDialogue)
        {
            StopIcon.SetActive(true);
            return;
        }
        ContinueIcon.SetActive(true);
    }
    private void moveSetting()
    {
        iTween.MoveFrom(Me, iTween.Hash("x", Me.transform.position.x - 10.0f, "time", 1.0f, "easetype", iTween.EaseType.easeOutBounce));
        iTween.MoveFrom(Boss, iTween.Hash("x", Boss.transform.position.x + 10.0f, "time", 1.0f, "easetype", iTween.EaseType.easeOutBounce));
    }
    private void moveImage(int currentDialogueIndex)
    {
        if (currentDialogueIndex == 0) return;
        if (currentDialogueIndex % 2 == 0) 
        iTween.ShakePosition(Me, iTween.Hash("amount",new Vector3( 0.2f,0.1f,0.1f), "time", 1.0f));
        else
        {
            iTween.ShakePosition(Boss, iTween.Hash("amount", new Vector3(0.2f, 0.1f, 0.1f), "time", 1.0f));

        }
    }
}
