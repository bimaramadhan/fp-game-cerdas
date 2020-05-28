using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

	int coin;
	int isShip1Sold;
	int isShip2Sold;

	public Text coinText;
	public Text ship1Price;
	public Text ship2Price;

	public Button buyButton1;
	public Button buyButton2;

	// Use this for initialization
	void Start () {
		coin = PlayerPrefs.GetInt ("coin");
	}
	
	// Update is called once per frame
	void Update () {
		
		coinText.text = "Money: " + coin.ToString() + "$";

		isShip1Sold = PlayerPrefs.GetInt ("IsShip1Sold");
		isShip2Sold = PlayerPrefs.GetInt ("IsShip2Sold");

		if (coin >= 250 && isShip1Sold == 0)
			buyButton1.interactable = true;
		else if (coin >= 150 && isShip2Sold == 0)
			buyButton2.interactable = true;
		else
			buyButton1.interactable = false;	
			buyButton2.interactable = false;	
	}

	public void buyShip1()
	{
		coin -= 250;
		PlayerPrefs.SetInt ("IsShip1Sold", 1);
		ship1Price.text = "Sold!";
		buyButton1.gameObject.SetActive (false);
	}
	
	public void buyShip2()
	{
		coin -= 150;
		PlayerPrefs.SetInt ("IsShip2Sold", 1);
		ship2Price.text = "Sold!";
		buyButton2.gameObject.SetActive (false);
	}
}
