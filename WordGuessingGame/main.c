#include "utils.h"
#include <stdio.h>

int main() {

  int maxSize = 5757;
  int wordSize = 6;
  char str[6];
  char randStr[6];
  srand(time(0));

  int winCount = 0;
  int loseCount = 0;
  int gamesPlayed = 0;
  int guessArray[100] = {0};
  int guessArrayIndex = 0;

  char arr[maxSize][wordSize];
  load_word_list(arr);

  int loop = 0;

  while (loop == 0) {

    int randNum = 0;
    int guessCount = 0;
    int gameLoop = 0;
    
    int hardMode = 0;
    int choiceLoopMode = 0;

    char letterBank[wordSize];
    char wordBank[wordSize];

    // Initialise wordbank array
    for (int i = 0; i < wordSize; i++) {
      wordBank[i] = '-';
    }

    // Generate random number
    randNum = (rand() % (maxSize + 1));

    // Store random word
    for (int i = 0; i < 5; i++) {
      randStr[i] = arr[randNum][i];
    }

    // Loop for game
    while (gameLoop == 0) {

        int guessLoop = 0;
      
        // Ask player if they want to play in hard mode
        while (choiceLoopMode == 0) {
    
          printf("Do you want to play in hard mode?: Type 'Y' for yes or 'N' for no \n");
    
          char input = 0;
          input = getchar();
    
          char choice = input;
    
          while (input != '\n') {
            input = getchar();
          }
    
          switch (choice) {
          case 'y':
          case 'Y':
            hardMode++;
            choiceLoopMode++;
            break;
          case 'n':
          case 'N':
            choiceLoopMode++;
            break;
          default:
            printf("Please Enter valid choice. \n");
          }
        }

      // Loop to verify users guess
      while (guessLoop == 0) {

        char c = 0;
        int letterCount = 0;

        printf("Enter 5 letter guess: \n");

        // Get user input
        for (int i = 0; i < 5; i++) {
          if (c != '\n') {
            c = getchar();
          }
          if (c != '\n') {
            str[i] = c;
          } else {
            str[i] = '#';
          }
        }

        //Consume newlines
        while (c != '\n') {
          c = getchar();
        }

        // Check if chars are letters
        for (int i = 0; i < 5; i++) {
          // If char is not between 'a' - 'z' or 'A' - 'Z' show error
          if (!((str[i] >= 'A' && str[i] <= 'Z') ||
                (str[i] >= 'a' && str[i] <= 'z'))) {
            printf(
                "Guess must be at 5 letters long and only contain letters. \n");
            break;
          }
        }

        // Convert to lowercase
        for (int i = 0; i < 5; i++) {
          if (str[i] >= 'A' && str[i] <= 'Z') {
            str[i] = str[i] + 32;
          }
        }

        // Check if word is in wordlist
        for (int i = 0; i <= maxSize; i++) {
          if (letterCount == 6) {
            guessLoop++;
            break;
          }
          letterCount = 0;
          for (int j = 0; j < wordSize; j++) {
            if (str[j] == arr[i][j]) {
              letterCount++;
            }
          }
          if (i == maxSize && letterCount != 6) {
            printf("Word was not found, please enter valid word \n \n");
          }
        }

        // Check if guess has letters in correct positions for hard mode
        if (hardMode == 1) {
          int flag = 0;
          for (int i = 0; i < wordSize; i++) {
            if (str[i] != wordBank[i] && wordBank[i] != '-') {
              flag++;
            }
          }
          if (flag >= 1) {
            printf("Your guess does not contain previously found letters in the correct position. \n");
            guessLoop = 0;
          }
        }
      } // End guessLoop

      printf("Your guess is: %s \n", str);

      char tmpStr[wordSize];
      int charCount = 0;

      // Find correctly placed letters and store word in wordBank
      for (int i = 0; i < wordSize; i++) {
        if (str[i] == randStr[i]) {
          tmpStr[i] = randStr[i];
          charCount++;
        } else {
          tmpStr[i] = '-';
        }
        if (tmpStr[i] != '-') {
          wordBank[i] = tmpStr[i];
        }
      }

      // Find correctly guessed letters that are incorrectly placed and store
      // them in letterBank
      for (int i = 0; i < wordSize; i++) {
        for (int j = 0; j < wordSize; j++) {
          if (str[i] == randStr[j]) {
            letterBank[i] = str[i];
            break;
          } else {
            letterBank[i] = ' ';
          }
        }
      }

      printf("%s \n", tmpStr);
      printf("Correctly guessed Letters: %s \n \n", letterBank);

      guessCount++;

      //Check if user has won or lost
      if (charCount == 6) {
        printf("You win! \n");
        printf("Amount of Guesses: %d \n", guessCount);
        winCount++;
        gameLoop++;
      }
      if (guessCount == 6) {
        printf("You lose! You reached 6 guesses \n");
        loseCount++;
        gameLoop++;
      }

    } //End loop

    printf("Your word was %s \n \n", randStr);

    int choiceLoop = 0;

    gamesPlayed++;
    guessArray[guessArrayIndex] = guessCount;
    guessArrayIndex++;

    // Ask player to play again
    while (choiceLoop == 0) {

      printf("Do you want to play again: Type 'Y' for yes or 'N' for no. \n");

      char input = 0;
      input = getchar();

      char choice = input;

      while (input != '\n') {
        input = getchar();
      }

      switch (choice) {
      case 'y':
      case 'Y':
        choiceLoop++;
        break;
      case 'n':
      case 'N':
        printf("Thanks for playing! \n");
        choiceLoop++;
        loop++;
        break;
      default:
        printf("Please Enter valid choice. \n");
      }
    }

  } // End gameLoop

  // Calculate win percentage
  gamesPlayed = winCount + loseCount;
  float percent = ((float)winCount / gamesPlayed) * 100;

  printf("Your Statistics are. \n");
  printf("Win Percentage: %.2f \n", percent);

  // Create histogram
  int guessArrayLength = 0;

  for (int i = 0; i < 100; i++) {
    if (guessArray[i] == 0) {
      guessArrayLength = i;
      break;
    }
  }

  printf("Histogram of amount of guesses needed per game. \n");

  for (int i = 0; i < guessArrayLength; i++) {
    printf("Game [%d] ", i + 1);
    for (int j = 0; j < guessArray[i]; j++) {
      printf("*");
    }
    printf("\n");
  }
}