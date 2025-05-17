using KanKikuchi.AudioManager;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class TimeResult : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text TimeText;
    [SerializeField] private PlayerMover playerMove;
    [SerializeField] private CountUpTimer CountUpTime;
    [SerializeField] GameObject[] character;       // PlayerMove�̎Q�Ƃ�ݒ�

    bool ClearCall = false;
    private void Start()
    {
        resultPanel.SetActive(false);
        character[1].SetActive(false);
        character[0].SetActive(false);
    }
    private void Update()
    {
        if (playerMove.CurrentScore >= 10000)
        {
            resultPanel.SetActive(true);
            if (!ClearCall)
            {
                if (playerMove.dumbbellcnt >= 8)
                {
                    SEManager.Instance.Play(SEPath.MUSCLE_CLEAR);
                    character[1].SetActive(true);
                }
                else
                {
                    SEManager.Instance.Play(SEPath.CLEAR);
                    character[0].SetActive(true);
                }
                ClearCall = true;
            }
            ShowResult();
        }
    }
    public void ShowResult()
    {
        Debug.Log("ShowResult called");
        resultPanel.SetActive(true);
        if (playerMove != null && TimeText != null)
        {
            TimeText.text = $"�H�����ԁF{string.Format("{0:00}:{1:00}", CountUpTime.seconds, CountUpTime.frames)}�b";
        }
    }
}