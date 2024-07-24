using UnityEngine;
using System.Collections;

public class ParticleManger : MonoBehaviour {

	public GameObject StarParticle;
	public GameObject SelectionParticle;

	private static ParticleManger _instance;

	public static ParticleManger instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<ParticleManger>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}

	void Awake() 
	{
		//Debug.Log("Awake Called");

		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(gameObject);
		}
	}


	#region Utility Methods 
	public void ShowStarParticle(GameObject obj) {
	    GameObject temp = (GameObject)Instantiate (StarParticle,obj.transform.position,Quaternion.identity);
        Destroy(temp,2f);
	}
	
	#endregion
}
