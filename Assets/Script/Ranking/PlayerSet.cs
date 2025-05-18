using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayerSet : MonoBehaviour
{
    public static PlayerSet Instance { get; private set; }

    public string PlayFabId { get; private set; } // ログイン後に保存されるID
    public string DisplayName { get; private set; }

    void Awake()
    {
        // Singletonパターン（1つだけ存在）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいで保持
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ログイン後にIDを保存するための初期化関数
    public void InitializePlayer(LoginResult result)
    {
        PlayFabId = result.PlayFabId;
        DisplayName = result.InfoResultPayload?.PlayerProfile?.DisplayName ?? "";
        Debug.Log($"プレイヤー初期化完了: ID={PlayFabId}, DisplayName={DisplayName}");
    }

    // 表示名を変更する
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
                Debug.Log($"プレイヤー名の変更に成功しました: {DisplayName}");
            },
            error =>
            {
                Debug.LogError($"プレイヤー名の変更に失敗しました: {error.GenerateErrorReport()}");
            });
    }
}
