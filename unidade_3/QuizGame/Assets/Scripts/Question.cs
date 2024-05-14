using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string question; // the question text
    public List<string> options; // the options choices
    public int answer; // the index of the correct answer
}