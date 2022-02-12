using System;
using Sirenix.OdinInspector;
using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[Serializable]
public class UnityFloatEvent : UnityEvent<float> { }

public class Cooldown : MonoBehaviour
{
	[Header("Info")]
	[SerializeField] bool useRandom = false;
	[ShowIf("useRandom")]
	[SerializeField] [MinMaxSlider(0, 40)] Vector2 randomValue;
	[HideIf("useRandom")]
	public FloatReference startTimeValue;
	public bool RunOnAwake = false;
	
	[Header("Events")]
	[SerializeField] UnityFloatEvent OnCooldownStart;
	[SerializeField] UnityFloatEvent OnCooldown;
	[SerializeField] UnityFloatEvent OnCooldownEnd;

	private float cooldown;
	bool isStart = false;

	void OnAwake ()
	{
		InitCooldown();

		if (RunOnAwake)
		{
			StartCooldown();
		}
	}

	void OnEnable()
	{
		InitCooldown();
	}

	public void StartCooldown()
	{
        if (isStart == true)
			return;
		isStart = true;
		StartCoroutine(IECooldown());
	}

	IEnumerator IECooldown()
	{
		OnCooldownStart.Invoke(startTimeValue.Value);
		while(isStart)
		{
			// Start Cooldown
			if(cooldown <= 0)
			{
				cooldown = 0;
				isStart = false;
				InitCooldown();
				OnCooldownEnd.Invoke(startTimeValue.Value);
            }
			else
			{
                cooldown -= Time.deltaTime;
			}

			OnCooldown.Invoke(cooldown);

			yield return null;
		}
	}

	public void Restart(float waitTime)
	{
		StartCoroutine(IERestart(waitTime));
	}

	IEnumerator IERestart(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		InitCooldown();
		StartCooldown();
	}

	public void InitCooldown(float time)
	{
		cooldown = (int)time;
	}

	public void InitCooldown(FloatVariable time)
	{
		cooldown = time.Value;
	}

	public void InitCooldown()
	{
		if (useRandom)
			cooldown = Random.Range(randomValue.x, randomValue.y);
		else
			cooldown = startTimeValue.Value;
	}
}