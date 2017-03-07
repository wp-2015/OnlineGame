using System;

public class TransformUtils {

	public static byte[] IntToBytes(int num){
		byte[] bytes = new byte[4];
		for (int i = 0; i < 4; i++){
			bytes[i] = (byte)(num >> (24 - i * 8));
		}
		return bytes;
	}
}
