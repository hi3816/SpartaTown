using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public int characterIndex; // 생성할 캐릭터 인덱스

    void Start()
    {
        SpawnCharacter();
    }

    void SpawnCharacter()
    {
        // 캐릭터 인덱스를 가져와서 프리팹을 얻음
        characterIndex = GameManager.Instance.SelectCharacterIndex;
        GameObject characterPrefab = GameManager.Instance.GetCharacterPrefab(characterIndex);

        if (characterPrefab != null)
        {
            // Player 오브젝트의 Transform을 부모로 설정하여 캐릭터 생성
            GameObject characterInstance = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Player").transform);

            // 생성된 캐릭터의 SpriteRenderer 가져오기
            SpriteRenderer characterSpriteRenderer = characterInstance.GetComponent<SpriteRenderer>();

            if (characterSpriteRenderer != null)
            {
                // Player 오브젝트의 TownMovement 컴포넌트를 가져오기
                TownMovement playerMovement = GameObject.Find("Player").GetComponent<TownMovement>();

                if (playerMovement != null)
                {
                    // TownMovement의 CharacterRenderer 변수에 생성된 캐릭터의 SpriteRenderer 할당
                    playerMovement.characterRenderer = characterSpriteRenderer;
                }
                else
                {
                    Debug.LogWarning("Player object does not have a TownMovement component.");
                }
            }

            // 생성된 캐릭터에서 Animator 가져오기
            Animator characterAnimator = characterInstance.GetComponentInChildren<Animator>();

            if (characterAnimator != null)
            {
                // Player 오브젝트의 TownAnimationController 컴포넌트를 가져오기
                TownAnimationController animationController = GameObject.Find("Player").GetComponent<TownAnimationController>();

                if (animationController != null)
                {
                    // TownAnimationController의 animator 변수에 할당
                    animationController.animator = characterAnimator;
                    Debug.Log("Animator successfully assigned to TownAnimationController.");
                }
                else
                {
                    Debug.LogWarning("Player object does not have a TownAnimationController component.");
                }
            }
            else
            {
                Debug.LogWarning("Character prefab does not have a SpriteRenderer.");
            }
        }
        else
        {
            Debug.LogWarning("Invalid character index.");
        }
    }
}