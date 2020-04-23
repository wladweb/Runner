using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health) 
    {
        if (_hearts.Count < health)
        {
            for (int i = 0, l = health - _hearts.Count; i < l; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > health)
        {
            for (int i = 0, l = _hearts.Count - health; i < l; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        Heart heart = Instantiate(_heartTemplate, transform);
        _hearts.Add(heart.GetComponent<Heart>());
        heart.ToFill();
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
