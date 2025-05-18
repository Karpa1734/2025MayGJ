using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// <summary>
// PlayFab�ň�ӂ�customID�̃��O�C���������s���N���X
// </summary>

public class PlayFabLogin : MonoBehaviour
{
    // �A�J�E���g��V�K�쐬���邩�ǂ���
    bool shouldCreateAccount;
    // customID�������Ă����ϐ�
    string customID;
    // customID�Ɏg�p���镶���ꗗ
    static readonly string ID_CHARACTERS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    // ==============================================================
    // ���O�C������
    // ==============================================================

    void Start()
    {
        // ���O�C�������̎��s
        Login();
    }

    // ���O�C�����\�b�h
    void Login()
    {
        // customID��ǂݍ���
        customID = LoadCustomID();

        // ���O�C�����̑��
        var request = new LoginWithCustomIDRequest { CustomId = customID, CreateAccount = shouldCreateAccount };

        // ���O�C������
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    // ���O�C���������̏���
    void OnLoginSuccess(LoginResult result)
    {
        // �V�K�ŃA�J�E���g���쐬���悤�Ƃ������A����customID���g���Ă����ꍇ
        if (shouldCreateAccount && !result.NewlyCreated)
        {
            // �ēx���O�C��������
            Login();

            return;
        }

        // �V�K�ŃA�J�E���g���쐬�����ꍇ
        if (result.NewlyCreated)
        {
            // �f�o�C�X��customID��ۑ�����
            SaveCustomID();
        }

        Debug.Log("���O�C���ɐ������܂���");
        Debug.Log($"CustomID�F{customID}");
    }

    // ���O�C�����s���̏���
    void OnLoginFailure(PlayFabError error)
    {
        Debug.Log("���O�C���Ɏ��s���܂���");
    }

    // ==============================================================
    // customID�̎擾
    // ==============================================================

    // �f�o�C�X��customID��ۑ�����ꍇ�Ɏg���L�[�̐ݒ�
    // PlayerPrefs���g���ĕۑ���customID�̕ۑ����s���̂ŁA���̃L�[�̐ݒ�ł�
    // �ڂ����́u�I�t���C�������L���O����������v�́uPlayerPrefs���ĉ��H�v��������������
    static readonly string CUSTOM_ID_SAVE_KEY = "TEST_RANKING_SAVE_KEY";

    // ������ID���擾���郁�\�b�h
    string LoadCustomID()
    {
        // �G�f�B�^���[�h���͏�ɐV����ID�𐶐�
    #if UNITY_EDITOR
        shouldCreateAccount = true;
        return GenerateCustomID();
    #else
    // �ʏ�̏���
        string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);
        shouldCreateAccount = string.IsNullOrEmpty(id);
        return shouldCreateAccount ? GenerateCustomID() : id;
    #endif
    }

    // customID���f�o�C�X�ɕۑ����郁�\�b�h
    void SaveCustomID()
    {
        // PlayerPrefs���g���āAcustomID��ۑ�����
        PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, customID);
    }

    // ==============================================================
    // customID�̐���
    // ==============================================================

    // customID�𐶐����郁�\�b�h
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