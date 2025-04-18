using System;
using System.Collections.Generic;

class Hangman
{
    
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlayGame();

            Console.Write("\nDo you want to play again? (y/n): ");
            string response = Console.ReadLine().ToLower();

            playAgain = response == "y";
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }

    static void PlayGame()
    {
        string[] words = { "computer", "programming", "hangman", "challenge", "keyboard" };
        Random rand = new Random();
        string wordToGuess = words[rand.Next(words.Length)];
        const int MAX_TRIES = 5;
        const char Placeholder = '_';


        char[] guessedLetters = new char[wordToGuess.Length];
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            guessedLetters[i] = Placeholder;
        }

        List<char> incorrectGuesses = new List<char>();
       

        while (incorrectGuesses.Count < MAX_TRIES && guessedLetters.Contains(Placeholder))
        {
            Console.Clear();
            Console.WriteLine("HANGMAN GAME");
            Console.WriteLine("Word: " + string.Join(" ", guessedLetters));
            Console.WriteLine("Incorrect guesses: " + string.Join(", ", incorrectGuesses));
            Console.WriteLine($"Remaining tries: {MAX_TRIES - incorrectGuesses.Count}");

            Console.Write("Enter a letter: ");
            string input = Console.ReadLine().ToLower();
            
            if (input.Length != 1)
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
                Console.ReadKey();
                continue;
            }
            

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
        if (!guessedLetters.Contains(Placeholder))
        {
            Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
        }
        else
        {
            Console.WriteLine("☠Game over! The word was: " + wordToGuess);
        }
    }
}
