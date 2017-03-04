using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class MyAllPrefabs {

	public static Units UnitPath = new Units();

}


enum TypePath {
	Unit = 1,
}
	
public class Units {

	public string Buhlishko = MakePath.MakePathForName ("Buhlishko", TypePath.Unit);

}

static class MakePath {

	public static string MakePathForName (string name, TypePath type){

		string path = "";

		switch (type) {
		case(TypePath.Unit):
			path =  "/Prefabs/Units/" + name + ".prefab";
			break;
		default:
			path = "Prefabs/" + name;
			break;
		}

		return path;

	}
}


