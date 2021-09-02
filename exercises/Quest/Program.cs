using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            int multiplier1 = new Random().Next()% 10;
            int multiplier2 = new Random().Next()% 10;
            Challenge timesTable = new Challenge($"What's {multiplier1} times {multiplier2}?", multiplier1 * multiplier2, 30);
            Challenge science = new Challenge("What is the boiling point of water in Kelvin rounded to nearest int?", 373, 30);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.WriteLine("Greetings, worthy adventurer...Err, what was your name, again?");
            var adventurerName = Console.ReadLine();

            Robe starterRobe = new Robe{Colors = new List<string>{"Blue","Purple"},Length = 50};
            Hat starterHat = new Hat{ ShininessLevel = 1 };
            Adventurer theAdventurer = new Adventurer(adventurerName, starterRobe, starterHat);
            Prize rubyPrize = new Prize("ruby");

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                timesTable,
                science
            };

            // Loop through all the challenges and subject the Adventurer to them

            List<Challenge> pickChallenges(){
            List<Challenge> currentChallenges = new List<Challenge>(){};
                for (int i = 0; i < 5;){
                    int currentIndex = new Random().Next(0, challenges.Count-1);
                    if (currentChallenges.Contains(challenges[currentIndex])){
                        continue;
                    }
                    else {
                    currentChallenges.Add(challenges[currentIndex]);
                    i++; };
                };
                return currentChallenges;
            }
            List<Challenge> starterChallenge = pickChallenges();
            Console.WriteLine(theAdventurer.GetAdventurerStatus());
            Console.WriteLine();
            foreach (Challenge challenge in starterChallenge)
            {
                challenge.RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            void score(Adventurer adventurer){
            if (adventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }
            rubyPrize.ShowPrize(theAdventurer);
            }
            score(theAdventurer);
            //Prompt user to see if they would like to play again after game finishes
            var repeat = "";
            void repeatChallenge(){
            do{
            Console.WriteLine("\n Try Again? y/n");
            repeat = Console.ReadLine();
            }
            while(repeat != "y" && repeat != "n");
            if (repeat == "y"){
                repeat = "";
                List<Challenge> nextChallenge = pickChallenges();
                int runOverScore = theAdventurer.Combo * 10;
                Console.WriteLine(theAdventurer.GetAdventurerStatus());
                Console.WriteLine();
                theAdventurer.Awesomeness += runOverScore;
                 foreach (Challenge challenge in nextChallenge)
                {
                challenge.RunChallenge(theAdventurer);
                }
                score(theAdventurer);
                repeatChallenge();
            }
            if (repeat == "n"){
               return;
            }
            score(theAdventurer);
            }
            repeatChallenge();
        }
    }
}