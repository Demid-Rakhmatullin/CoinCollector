using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] CoinType type;
    [SerializeField] AudioClip collectSound;

    public CoinType Type => type;

    private CoinSpawner spawner;
    private new BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();

        switch (type)
        {
            case CoinType.Type3:
                collider.enabled = false;
                transform.localScale = Vector3.zero;
                transform.LeanScale(Vector3.one, 0.5f).setEaseInOutBack().setOnComplete(() => collider.enabled = true);
                break;
        }
    }

    public void SetSpawner(CoinSpawner spawner)
        => this.spawner = spawner;

    public void Collect()
    {
        if (collectSound != null)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

        switch (type)
        {
            case CoinType.Type2:
                transform.LeanScale(Vector3.zero, 0.5f).setOnComplete(() => ReturnToPull());
                break;
            default:
                ReturnToPull();
                break;
        }
    }

    private void ReturnToPull()
    {
        spawner.Recycle(gameObject);
    }    
}

public enum CoinType
{
    Type1,
    Type2,
    Type3
}
