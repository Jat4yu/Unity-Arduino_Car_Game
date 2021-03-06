using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Unity_Car_Behaviour_Script : MonoBehaviour {

	public float speed;
	private float amounttomove;
	private float amounttorotate=20;

	SerialPort sp = new SerialPort("COM3",9600);
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		amounttomove = speed * Time.deltaTime;
		amounttorotate = 20;

		if (sp.IsOpen) 
		{
			try{
				Movement(sp.ReadByte());
				print(sp.ReadByte());
			}
			catch(System.Exception){
			}

		}
	}


	void Movement(int Direction){
		if (Direction == 200) {
			transform.Translate (Vector3.left * amounttomove, Space.Self);
		}
		if (Direction == 201) {
			transform.Translate (Vector3.right * amounttomove, Space.Self);
		}

		if (0 <= Direction && Direction <= 63) {
			transform.Rotate (Vector3.up *3* ((63-Direction)/2) * Time.deltaTime, Space.Self);
		}
			if(64<=Direction && Direction<=127) {
			transform.Rotate (Vector3.down *3* ((Direction-64)/2)*Time.deltaTime,Space.Self);
		}
	}
}
