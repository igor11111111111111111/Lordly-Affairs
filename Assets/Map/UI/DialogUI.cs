using Leopotam.Ecs;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] private ButtonUI _prefab;
        [SerializeField] private Transform _playerPhrasesParent;
        [SerializeField] private TextMeshProUGUI _unitName;
        [SerializeField] private TextMeshProUGUI _unitPhrase;
        [SerializeField] private UnitModel _unitModel;
        private AllClothMesh _allClothMesh;
        private SquadComponent _player;
        private SquadComponent _collocutor;
        private EcsEntity _playerEntity;

        public void Init(ButtonClickedEvent talkPaty, AllClothMesh allClothMesh)
        {
            _allClothMesh = allClothMesh;

            talkPaty.AddListener(TalkUnit);
            //_neverMind.Button.onClick.AddListener(() => Show(false));
            Show(false);
        }

        public void TalkSquad(EcsEntity entity)
        {
            _playerEntity = entity;
            ref var player = ref entity.Get<SquadComponent>();
            _player = player;
            if (player.Target is SquadComponent == false) return;
            var collocutor = (SquadComponent)player.Target;
            _collocutor = collocutor;

            _unitName.text = collocutor.Name;
            _unitModel.RefreshCloth(collocutor, _allClothMesh);

            Greetings();

            Show(true);
        }

        private void Greetings()
        {
            ClearPlayerPhrases();
            if(_collocutor.Commander.Name != null)
            {
                _unitPhrase.text = "Hello, my name is " + _collocutor.Commander.Name;
            }
            else
            {
                _unitPhrase.text = "Hello, we dont have leader, so call me <My sovereign>. In principle, <Dude> will also do";
            }
            _unitPhrase.text += "\n How Can i help you?";

            CreateButton("My name is " + _player.Commander.Name + ". Glade to see you", PlayerMainPhrases);

            CreateButton("Nevermind",
            () => {
                Show(false);
                _playerEntity.Del<EnterPlayerRelationshipStateComponent>();
            });
        }

        private void PlayerMainPhrases()
        {
            ClearPlayerPhrases();

            _unitPhrase.text = "Soo, what do you want to tell me?";

            CreateButton("Tell local news", TellLocalNews);
            CreateButton("Prepare to DIE", PrepareToDie);
            CreateButton("Nevermind",
            () => {
                Show(false);
                _playerEntity.Del<EnterPlayerRelationshipStateComponent>();
            });
        }

        private void TellLocalNews()
        {
            ClearPlayerPhrases();

            _unitPhrase.text = "Time passes, nothing changes. The rich get richer, poor get poorer. Be careful, near bandits want get your ass";

            CreateButton("Enough about politics", PlayerMainPhrases);
        }

        private void PrepareToDie()
        {
            ClearPlayerPhrases();

            _unitPhrase.text = "How dare you?!";
            CreateButton("Chill, chill, im joke", PlayerMainPhrases);
        }

        private void Show(bool active)
        {
            gameObject.SetActive(active);
        }

        private void TalkUnit()
        {
            ClearPlayerPhrases();
            _unitPhrase.text = "??";
            CreateButton("Nevermind", () => Show(false));
            Show(true);
        }

        private void ClearPlayerPhrases()
        {
            foreach (Transform child in _playerPhrasesParent)
            {
                Destroy(child.gameObject);
            }
        }

        private void CreateButton(string text, UnityAction action)
        {
            var button = Instantiate(_prefab, _playerPhrasesParent);
            button.Text.text = text;
            button.Button.onClick.AddListener(action);
        }
    }
}