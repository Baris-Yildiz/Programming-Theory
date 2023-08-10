using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldHealthManager : MonoBehaviour
{
    Slider healthBar;
    public static WorldHealthManager Instance;

    public Renderer worldRenderer;
    Color firstDefaultColor;
    Color secondDefaultColor;

    public ParticleSystem explosion;
    bool destroyed = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        healthBar = GetComponentInChildren<Slider>();
        healthBar.value = healthBar.maxValue;
        
        firstDefaultColor = worldRenderer.materials[0].color;
        secondDefaultColor = worldRenderer.materials[1].color;
    }


    public void TakeDamage(float damage)
    {
        healthBar.value -= damage;
        
        if (healthBar.value == 0)
        {
            if (!destroyed)
            {
                destroyed = true;
                ChangeIntoDestroyedColor();
                explosion.Play();
                MusicManager.Instance.PlayAudio(Audio.WorldExplosion);
                GameManager.Instance.EndGame();
            }
        } else 
        {
            StartCoroutine(ChangeColorWhenDamaged());
        }
    }

    IEnumerator ChangeColorWhenDamaged()
    {
        worldRenderer.materials[0].color = Color.red;
        worldRenderer.materials[1].color = Color.red;
        for (float i = 0; i < 0.5f; i+= Time.deltaTime)
        {
            worldRenderer.materials[0].color = Color.Lerp(Color.red, firstDefaultColor, i*2);
            worldRenderer.materials[1].color = Color.Lerp(Color.red, secondDefaultColor, i*2);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    void ChangeIntoDestroyedColor()
    {
        worldRenderer.materials[0].color = Color.black;
        worldRenderer.materials[1].color = Color.black;
    }

}
