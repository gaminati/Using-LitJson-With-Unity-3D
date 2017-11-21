using UnityEngine;
using LitJson;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class parseJSON
{
	//Parse JSON is the class which have these string you can change it according to your need
	//If you want signup scene you can email us at gaminatistudio@gmail.com

	public string username;
	public string company_name;
	public string email;
	public string phone;
	public string status;
}
public class GameController : MonoBehaviour
{
	public Text TXT_1,Txt_2;
	public InputField user_field,pass_field;
	public Text Json_String;
	public GameObject Help_Panel,Login_Panel,Fingure;


	public void Help_Button_Pressed(){
		Help_Panel.SetActive (true);
		Login_Panel.SetActive (false);
	}
	public void Help_Close_Button_Pressed(){
		Help_Panel.SetActive (false);
		Login_Panel.SetActive (true);
		Fingure.SetActive (false);

	}    
	private void Processjson (string jsonString)
	{
		JsonData jsonvale = JsonMapper.ToObject (jsonString);
		parseJSON parsejson;
		parsejson = new parseJSON ();


		//Data is the JSON OBJECT Which Have The Key Username 
		//0 is the index of json object

		parsejson.username = jsonvale ["data"][0]["username"].ToString ();
		parsejson.company_name = jsonvale ["data"][0]["company_name"].ToString ();
		parsejson.email = jsonvale ["data"][0]["email"].ToString ();
		parsejson.phone = jsonvale ["data"][0]["phone"].ToString ();
		parsejson.status = jsonvale ["data"][0]["status"].ToString ();
		//-----//----//

		TXT_1.text = parsejson.username;
		Txt_2.text = parsejson.company_name;




	}


	public void SIGNUPBUTTONPRESSED(){

		StartCoroutine (SignUp ());
	}

	IEnumerator SignUp(){
	string signupurl = "ADD Sign Up URL Here";
	WWWForm form = new WWWForm ();




		form.AddField ("company_name", "ADD YOUR SIGNUP FIELD HERE");
		form.AddField ("username", "ADD YOUR SIGNUP FIELD HERE");
		form.AddField ("password", "ADD YOUR SIGNUP FIELD HERE");
		form.AddField ("email", "ADD YOUR SIGNUP FIELD HERE");
		form.AddField ("phone", "ADD YOUR SIGNUP FIELD HERE");
		Dictionary<string,string> headers = new Dictionary<string, string>();
		//System.Collections.Hashtable headers = form.headers;
		headers ["Content-Type"] = "application/json";
		byte[] rawData = form.data;

		WWW w = new WWW (signupurl, form);
		//WWW w = new WWW (signupurl, rawData,headers);



		yield return w;

		Debug.Log (w.text);
	}


	public void LOGIN_BUTTON_PRESSED(){

		StartCoroutine (LOGIN ());
	}

	IEnumerator LOGIN(){ // This is a POST Method Service

		string signupurl = "ADD YOUR WEB SERVICE URL HERE";
		WWWForm form = new WWWForm ();
		form.AddField ("email", user_field.text);
		form.AddField ("password", pass_field.text);
		Dictionary<string,string> headers = new Dictionary<string, string> ();
		headers ["Content-Type"] = "application/json";
		byte[] rawData = form.data;
		WWW w = new WWW (signupurl, form);
		yield return w;
		Debug.Log (w.text);
		Json_String.text = w.text;
		Processjson (w.text); // This function is fetching the Json Data of entered username or password


	}}