using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public float thrust;
    public float coinCounter = 3f;
    public GameObject coin;
    public GameObject coinPos;
    private GameObject copy_coin;
    private Rigidbody rb_coinBone;
    private Animator animatorTest;
    private GameObject m_camera;
    private SkinnedMeshRenderer meshRendererCoin;
    private bool canAttack = true;

    // Use this for initialization
    void Start()
    {
        animatorTest = GetComponent<Animator>();
        m_camera = GameObject.FindWithTag("MainCamera");
        meshRendererCoin = coinPos.transform.parent.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            animatorTest.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (coinCounter > 0 && canAttack)
            {
                canAttack = false;
                coinCounter--;
                meshRendererCoin.enabled = true;
                animatorTest.SetTrigger("CoinThrow");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            coinCounter = 3;
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
}
