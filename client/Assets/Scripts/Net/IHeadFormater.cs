using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeadFormater {

	bool TryParse(string data, NetworkType type, out PackageHead head, out object body);
	bool TryParse(byte[] data, out PackageHead head, out byte[] bodyBytes);
	byte[] BuildHearbeatPackage();
}
