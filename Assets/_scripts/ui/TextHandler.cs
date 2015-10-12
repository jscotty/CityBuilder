using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour {

	[SerializeField]
	private Text cashTxt;


	private string moneyCount = "";
	float money;

	void Start(){

	}

	void Update(){
		money = Stats.cash;
		if(Stats.cash >= 1000000000){
			moneyCount = "B";
			money = money/1000000000;
		} else if(Stats.cash >= 1000000){
			moneyCount = "M";
			money = money/1000000;
		} else if(Stats.cash >= 1000){
			moneyCount = "K";
			money = money/1000;
		}


		money = Mathf.Round(money);
		cashTxt.text = "Cash: " + money + moneyCount;
	}
}
