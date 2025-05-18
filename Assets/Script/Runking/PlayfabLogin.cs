using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// <summary>
// PlayFabで一意なcustomIDのログイン処理を行うクラス
// </summary>

public class PlayFabLogin : MonoBehaviour
{
    // アカウントを新規作成するかどうか
    bool shouldCreateAccount;
    // customIDを代入しておく変数
    string customID;
    // customIDに使用する文字一覧
    static readonly string ID_CHARACTERS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    // ==============================================================
    // ログイン処理
    // ==============================================================

    void Start()
    {
        // ログイン処理の実行
        Login();
    }

    // ログインメソッド
    void Login()
    {
        // customIDを読み込む
        customID = LoadCustomID();

        // ログイン情報の代入
        var request = new LoginWithCustomIDRequest { CustomId = customID, CreateAccount = shouldCreateAccount };

        // ログイン処理
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    // ログイン成功時の処理
    void OnLoginSuccess(LoginResult result)
    {
        // 新規でアカウントを作成しようとしたが、既にcustomIDが使われていた場合
        if (shouldCreateAccount && !result.NewlyCreated)
        {
            // 再度ログインし直す
            Login();

            return;
        }

        // 新規でアカウントを作成した場合
        if (result.NewlyCreated)
        {
            // デバイスにcustomIDを保存する
            SaveCustomID();
        }

        Debug.Log("ログインに成功しました");
        Debug.Log($"CustomID：{customID}");
    }

    // ログイン失敗時の処理
    void OnLoginFailure(PlayFabError error)
    {
        Debug.Log("ログインに失敗しました");
    }

    // ==============================================================
    // customIDの取得
    // ==============================================================

    // デバイスにcustomIDを保存する場合に使うキーの設定
    // PlayerPrefsを使って保存をcustomIDの保存を行うので、そのキーの設定です
    // 詳しくは「オフラインランキングを実装する」の「PlayerPrefsって何？」をご覧ください
    static readonly string CUSTOM_ID_SAVE_KEY = "TEST_RANKING_SAVE_KEY";

    // 自分のIDを取得するメソッド
    string LoadCustomID()
    {
        // エディタモード時は常に新しいIDを生成
    #if UNITY_EDITOR
        shouldCreateAccount = true;
        return GenerateCustomID();
    #else
    // 通常の処理
        string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);
        shouldCreateAccount = string.IsNullOrEmpty(id);
        return shouldCreateAccount ? GenerateCustomID() : id;
    #endif
    }

    // customIDをデバイスに保存するメソッド
    void SaveCustomID()
    {
        // PlayerPrefsを使って、customIDを保存する
        PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, customID);
    }

    // ==============================================================
    // customIDの生成
    // ==============================================================

    // customIDを生成するメソッド
    string GenerateCustomID()
    {
        int idLength = 32;
        StringBuilder stringBuilder = new StringBuilder(idLength);

        for (int i = 0; i < idLength; i++)
        {
            stringBuilder.Append(ID_CHARACTERS[UnityEngine.Random.Range(0, ID_CHARACTERS.Length)]);
        }

        return stringBuilder.ToString();
    }
}