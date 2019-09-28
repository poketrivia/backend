using System.Collections.Generic;

namespace PokeTrivia.DataImport.TriviaData.Models.App
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string CorrectAnswerText { get; set; }

        public List<string> AnswerChoices { get; set; }

        public QuestionDifficulty Difficulty { get; set; }
    }
}