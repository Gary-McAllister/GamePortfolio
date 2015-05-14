using UnityEngine;
using System.Collections;

public class CharacterControlerLogic : MonoBehaviour {

	#region Variables (private)
	
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private float directionDampTime = .25f;
	
	private float speed = 0.0f;
	private float h = 0.0f;
	private float v = 0.0f;
	#endregion


	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		
		if(animator.layerCount >= 2)
		{
			animator.SetLayerWeight(1, 1);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (animator)
		{
			//pull values from controller/keyboard
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
			
			speed = new Vector2(h, v).sqrMagnitude;
			
			animator.SetFloat ("Speed", speed);
			animator.SetFloat ("Direction", h, directionDampTime, Time.deltaTime);
		
		
		}
	}
}
