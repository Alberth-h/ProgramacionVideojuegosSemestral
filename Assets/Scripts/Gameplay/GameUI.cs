using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    private UIDocument _uiDoc;
    private ProgressBar _healthbar;
    private ProgressBar _manabar;

    private Transform _leader;

    [SerializeField]
    Sprite[] spriteLeader;

    [SerializeField]
    Talks[] partyTalks;

    private void Awake()
    {
        _uiDoc = GetComponent<UIDocument>();
    }

    private void Start()
    {
        _healthbar = _uiDoc.rootVisualElement.Q<ProgressBar>("health");
        _manabar = _uiDoc.rootVisualElement.Q<ProgressBar>("mana");
    }

    private void Update()
    {
        Talking();
    }

    private void Talking()
    {
        _leader = Gamemanager.Instance.CurrentGameMode.GetPartyLeader;
        _uiDoc.rootVisualElement.Q<Label>("name").text = _leader.name;

        switch(_leader.name)
        {
            case "Maggie":
                _uiDoc.rootVisualElement.Q<VisualElement>("talkcontainer").style.backgroundColor= new StyleColor(new Vector4 (0.45f, 0.0f, 0.65f, 0.75f));
                _uiDoc.rootVisualElement.Q<VisualElement>("sprite").style.backgroundImage = new StyleBackground(spriteLeader[0]);
                _uiDoc.rootVisualElement.Q<Label>("talk").text = partyTalks[0].actualTalk;
                break;
            case "Lisa":
                _uiDoc.rootVisualElement.Q<VisualElement>("talkcontainer").style.backgroundColor= new StyleColor(new Vector4 (0.0f, 0.72f, 0.46f, 0.75f));
                _uiDoc.rootVisualElement.Q<VisualElement>("sprite").style.backgroundImage = new StyleBackground(spriteLeader[1]);
                _uiDoc.rootVisualElement.Q<Label>("talk").text = partyTalks[1].actualTalk;
                break;
            case "Bart":
                _uiDoc.rootVisualElement.Q<VisualElement>("talkcontainer").style.backgroundColor= new StyleColor(new Vector4 (0.83f, 0.0f, 0.1f, 0.75f));
                _uiDoc.rootVisualElement.Q<VisualElement>("sprite").style.backgroundImage = new StyleBackground(spriteLeader[2]);
                _uiDoc.rootVisualElement.Q<Label>("talk").text = partyTalks[2].actualTalk;
                break;
        }
    }

    public float Health{get => _healthbar.value; set => _healthbar.value = value;}
    public float Mana{get => _manabar.value; set => _manabar.value = value;}
    
    
}