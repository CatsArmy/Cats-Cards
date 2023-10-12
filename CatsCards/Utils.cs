using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace Lightsaber.Utils
{
    internal class Utils
    {
        public List<CardCategory> categoryList = new List<CardCategory>();

        private CardCategory cardCategory;

        private CardInfo card;

        private CardInfo GetCardByName(string cardName)
        {
            return CardChoice.instance.cards.FirstOrDefault((CardInfo c) => c.cardName.ToLower() == cardName.ToLower());
        }

        private CardCategory GetCardCategoryByName(string category)
        {
            return CustomCardCategories.instance.CardCategory(category);
        }

        private void AddCardCategory(string cardName, string categories = "CardManipulation")
        {
            try
            {
                card = GetCardByName(cardName);
                cardCategory = GetCardCategoryByName(categories);
                categoryList.Clear();
                categoryList.AddRange(card.categories.ToList());
                if (!categoryList.Contains(cardCategory))
                {
                    categoryList.Add(cardCategory);
                    card.categories = new CardCategory[categoryList.ToArray().Length];
                    card.categories = categoryList.ToArray();
                    UnityEngine.Debug.Log($"log card ||");
                }
                else
                    UnityEngine.Debug.Log($"{categories} is allready present on {card.name}");
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.Log(exception.Message);
            }
        }
    }
}
