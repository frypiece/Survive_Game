﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
	public static Dictionary<string,Item> Itemlist = new Dictionary<string,Item>();	// name -> item
	//public static Dictionary<HashSet<string>, HashSet<string>> ItemCombo = 
		//new Dictionary<HashSet<string>, HashSet<string>>(HashSet<string>.CreateSetComparer());
	public static Dictionary<string, HashSet<string>> ItemCombo = new Dictionary<string, HashSet<string>>();
	public Item apple;
	public Item knife;
	public Item stick;
	public Item spear;

	private static HashSet<string> Set(List<string> items) {
		HashSet<string> res = new HashSet<string> ();
		for (int i = 0; i < items.Count; i++) {
			res.Add (items [i]);
		}
		return res;

	}
		

	public static HashSet<string> MakeItem(List<string> items) {
		string key = makeString (items);
		if (ItemCombo.ContainsKey(key)){
			Debug.Log ("Hello");
			return ItemCombo[key];
		}
		else {
			return null;
		}
	}

	private static string makeString(List<string> list) {
		list.Sort ();
		string res = "";
		foreach (string str in list) {
			res += str;	
		}
		return res;
	}

	public static Item getItem(string newItem) {
		if (Itemlist.ContainsKey (newItem)) {
			return Itemlist [newItem];
		} else {
			return null;
		}
	}

	// Use this for initialization, build the hashmap and item list
	void Start () {
		Itemlist.Add (apple.item_name, apple);
		Itemlist.Add (stick.item_name,stick);
		Itemlist.Add (knife.item_name,knife);
		Itemlist.Add (spear.item_name,spear);
		ItemCombo.Add (makeString(new List<string>{knife.item_name,stick.item_name}), Set(new List<string>{spear.item_name}));
		ItemCombo.Add (makeString(new List<string>{spear.item_name}), Set(new List<string>{knife.item_name,stick.item_name}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}