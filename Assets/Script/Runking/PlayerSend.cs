using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayerSet : MonoBehaviour
{
    public static PlayerSet Instance { get; private set; }

    public string PlayFabId { get; private set; } // ���O�C����ɕۑ������ID
    public string DisplayName { get; private set; }

    void Awake()
    {
        // Singleton�p�^�[���i1�������݁j
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ŕێ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���O�C�����ID��ۑ����邽�߂̏������֐�
    public void InitializePlayer(LoginResult result)
    {
        PlayFabId = result.PlayFabId;
        DisplayName = result.InfoResultPayload?.PlayerProfile?.DisplayName ?? "";
        Debug.Log($"�v���C���[����������: ID={PlayFabId}, DisplayName={DisplayName}");
    }

    // �\������ύX����
    public void SetUserName(string newName)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = newName
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request,
            result =>
            {
                DisplayName = result.DisplayName;
                Debug.Log($"�v���C���[���̕ύX�ɐ������܂���: {DisplayName}");
            },
            error =>
            {
                Debug.LogError($"�v���C���[���̕ύX�Ɏ��s���܂���: {error.GenerateErrorReport()}");
            });
    }
}
