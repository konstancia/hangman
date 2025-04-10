using System;
using System.Collections.Generic;

class Hangman
{
    static void Main()
    {
     
        string[] words = { "florida", "california", "texas" };

     
        Random rand = new Random();
        string wordToGuess = words[rand.Next(words.Length)];

        
        char[] guessedLetters = new string('_', wordToGuess.Length).ToCharArray();
        List<char> incorrectGuesses = new List<char>();
        int maxTries = 5;

       
        while (incorrectGuesses.Count < maxTries && new string(guessedLetters) != wordToGuess)
        {
            Console.Clear();
            Console.WriteLine("HANGMAN GAME");
            Console.WriteLine("Word: " + string.Join(" ", guessedLetters));
            Console.WriteLine("Incorrect guesses: " + string.Join(", ", incorrectGuesses));
            Console.WriteLine($"Remaining tries: {maxTries - incorrectGuesses.Count}");

            Console.Write("Enter a letter: ");
            string input = Console.ReadLine().ToLower();

            char guess = input[0];

            if (guessedLetters.Contains(guess) || incorrectGuesses.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter.");
                Console.ReadKey();
                continue;
            }
            
            if (wordToGuess.Contains(guess))
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                        guessedLetters[i] = guess;
                }
            }
            else
            {
                incorrectGuesses.Add(guess);
            }
        }

        Console.Clear();
        if (new string(guessedLetters) == wordToGuess)
        {
            Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
        }
        else
        {
            Console.WriteLine("☠Game over! The word was: " + wordToGuess);
        }
    }
}
