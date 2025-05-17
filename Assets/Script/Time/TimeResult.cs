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

    private void Start()
    {
        resultPanel.SetActive(false);
    }
    private void Update()
    {
        if (playerMove.CurrentScore > 10000)
        {
            ShowResult();
        }
    }
    public void ShowResult()
    {
        Debug.Log("ShowResult called");
        resultPanel.SetActive(true);
        if (playerMove != null && TimeText != null)
        {
            
            TimeText.text = $"êHéñéûä‘ÅF{string.Format("{0:00}:{1:00}", CountUpTime.seconds, CountUpTime.frames)}ïb";
        }
    }
}