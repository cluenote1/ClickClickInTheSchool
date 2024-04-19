using System.Linq;
using System.Collections.Generic;
using UnityEngine.U2D.Animation;
using UnityEngine;
using System.Globalization;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private CharacterType CharType;
    private enum CharacterType
    {
        Ork,
        Bandit
    }

    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CharType = CharType == CharacterType.Ork ? CharacterType.Bandit : CharacterType.Ork;
            ChangeOutfit();
        }
    }

    private void ChangeOutfit()
    {
        foreach (SpriteResolver resolver in resolvers)
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), CharType.ToString());

            if (resolver.GetCategory() == "Weapon")
            {
                resolver.gameObject.SetActive(resolver.GetLabel() == "Bandit");
            }

            Sprite sprite = resolver.spriteLibrary.GetSprite(resolver.GetCategory(), resolver.GetLabel());
            Debug.Log($"sprite : {sprite}") ;
        }
    }
}
