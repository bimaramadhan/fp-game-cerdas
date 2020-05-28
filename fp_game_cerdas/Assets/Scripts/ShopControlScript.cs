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
	public Text shop1Price;
	public Text shop2Price;
	public Text shop3Price;
	public Text shop4Price;

	public Button buyButton1;
	public Button buyButton2;
	public Button buyButton3;
	public Button buyButton4;

	// public MaskableGraphic imageToToggle;

	private int coins;

	// Use this for initialization
	void Start () {
		// coin = PlayerPrefs.GetInt ("coin");
		coin = CoinScript.coinValue;
		Debug.Log(coin);
	}
	
	// Update is called once per frame
	void Update () {
		

		// buyButton1.interactable = false;	
		// buyButton2.interactable = false;	
		// buyButton3.interactable = false;	
		// buyButton4.interactable = false;	

		// if (coin >= 250)
		// 	buyButton1.interactable = true;
		// 	buyButton4.interactable = true;
		// if (coin >= 150)
		// {
		// 	buyButton2.interactable = true;
		// 	buyButton3.interactable = true;
		// }
	}

	public void buyShop1()
	{
		if (coin >= 250){
			coin -= 250;
			// PlayerPrefs.SetInt ("IsShip1Sold", 1);
			// shop1Price.text = "Sold!";
			// buyButton1.gameObject.SetActive (false);
		}
		else
			shop1Price.text = "Insufficent coin!";

		coinText.text = " " + coin;

	}
	
	public void buyShop2()
	{
		if (coin >= 100) {
			coin -= 100;
			WaterBoat.MaxSpeed += 10f;
			// PlayerPrefs.SetInt ("IsShip2Sold", 1);
			// shop2Price.text = "Sold!";
			// buyButton2.gameObject.SetActive (false);
		}
		else
			shop2Price.text = "Insufficent coin";

		coinText.text = " " + coin;
	}
	public void buyShop3()
	{
		if (coin >= 150) {
			coin -= 150;
			// PlayerPrefs.SetInt ("IsShip2Sold", 1);
			// shop3Price.text = "Sold!";
			// buyButton3.gameObject.SetActive (false);
		}
		else
			shop3Price.text = "Insufficent coin";
		
		coinText.text = " " + coin;

	}
	public void buyShop4()
	{
		if (coin >= 250) {
			coin -= 250;
			// PlayerPrefs.SetInt ("IsShip2Sold", 1);
			// shop4Price.text = "Sold!";
			// buyButton4.gameObject.SetActive (false);
		}
		else
			// buyButton4.interactable = false;	
			shop4Price.text = "Insufficent coin";

		coinText.text = " " + coin;

	}
}
