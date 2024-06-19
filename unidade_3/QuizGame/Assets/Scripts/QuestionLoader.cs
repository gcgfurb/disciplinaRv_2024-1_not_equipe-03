using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public static class QuestionLoader
{
    public static List<Category> categories = JsonUtility
        .FromJson<Categories>((Resources.Load("perguntas_e_respostas") as TextAsset).text)
        .categories; // the JSON file containing the questions

    public static List<Question> GetQuestions(int idx)
    {
        return new List<Question>(categories[idx].questions);
    }
}

public class Categories
{
    public List<Category> categories;
}