using System;
using System.Collections.Generic;
using System.Linq;
using PokeTrivia.DataImport.PokeApiData.Mappers;
using PokeTrivia.DataImport.PokeApiData.Models;
using PokeTrivia.DataImport.TriviaData.Models;
using PokeTrivia.DataImport.TriviaData.Models.App;

namespace PokeTrivia.DataImport.TriviaData.QuestionGenerators
{
    public static class PokemonSpeciesQuestionGenerator
    {
        public static List<Question> GeneratePokemonSpeciesQuestions()
        {
            // TODO: This should be database driven
            var pokemonSpecies = PokemonSpeciesDataMapper.GetPokemonSpecies();

            var questions = GenerateFlavorTextQuestions(pokemonSpecies);

            return questions;
        }

        private static List<Question> GenerateFlavorTextQuestions(List<PokemonSpeciesData> pokemonSpeciesData)
        {
            Question questionTemplate(PokemonSpeciesData speciesData)
            {
                var flavorText = speciesData.FlavorTextEntries
                    .First(f => f.Language == "en") // TODO: Pick latest main series game
                    .FlavorText;

                var questionText = $"Which Pokemon is described by the following flavor text?\n\n{flavorText}";

                var correctAnswer = speciesData.Names
                    .First(f => f.Language == "en")
                    .Name;

                // Get bad answers
                // TODO: Pick the choices more intelligently
                var answerChoices = pokemonSpeciesData
                    .OrderBy(x => Guid.NewGuid())
                    .Take(3)
                    .Select(x => x.Names.First(n => n.Language == "en").Name)
                    .ToList();

                // Add correct answer
                answerChoices.Add(correctAnswer);

                answerChoices = answerChoices
                    .OrderBy(x => Guid.NewGuid())
                    .ToList();

                return new Question
                {
                    QuestionText = questionText,
                    Difficulty = QuestionDifficulty.Hard,
                    CorrectAnswerText = correctAnswer,
                    AnswerChoices = answerChoices
                };
            }

            return pokemonSpeciesData
                .Select(data => questionTemplate(data))
                .ToList();
        }
    }
}