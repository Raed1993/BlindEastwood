using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Attacks : MonoBehaviour
{
	public GameObject porraDamage;
    public float thrust;
    public int coinCounter = 50;
    public GameObject coin;
    public GameObject coinPos;
    private GameObject copy_coin;
    private Rigidbody rb_coinBone;
    private Animator animatorTest;
    private GameObject m_camera;
    private SkinnedMeshRenderer meshRendererCoin;
    private bool canAttack = true;
	private CapsuleCollider porraCollider;
    private AtaquePorra ataquePorra;
    private FirstPersonController fps;

    // Use this for initialization
    void Start()
    {
        animatorTest = GetComponent<Animator>();
        m_camera = GameObject.FindWithTag("MainCamera");
        meshRendererCoin = coinPos.transform.parent.GetComponent<SkinnedMeshRenderer>();
		porraCollider = porraDamage.GetComponent<CapsuleCollider> ();
        ataquePorra = porraDamage.GetComponent<AtaquePorra>();
        fps = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetMouseButtonDown(1))
        {
            animatorTest.SetTrigger("Attack");
        }

		if (Input.GetMouseButtonDown(0))
        {
            if (coinCounter > 0 && canAttack)
            {
                canAttack = false;
                coinCounter--;
                meshRendererCoin.enabled = true;
                animatorTest.SetTrigger("CoinThrow");
            }
        }

    }

    void CoinThrow()
    {
        meshRendererCoin.enabled = false;
        copy_coin = Instantiate(coin, coinPos.transform.position, coin.transform.rotation) as GameObject;
        rb_coinBone = copy_coin.GetComponent<Rigidbody>();
        rb_coinBone.AddForce(coinPos.transform.forward * thrust, ForceMode.Impulse);
        Destroy(copy_coin, 10);

    }

    void CanAttack()
    {
        canAttack = true;
    }

	void CanDamage(int canDamage)
	{
        if (canDamage > 0)
        {
            porraCollider.enabled = true;
            ataquePorra.Sound();
        }
        else
        {
            porraCollider.enabled = false;
            fps.InstantiateSound();
        }
	}
}