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

            Challenge cupsOfSugar = new Challenge("How many cups of sugar does it take to get to the moon?", 3947, 50);
            Challenge favoriteColor = new Challenge(@"What is your quest?
    1) To seek the Holy Grail
    2) To aimlessly wander the space-time continuum
    3) To win
", 
            1, 25);

            Challenge swallowVelocity = new Challenge(@"What is the airspeed velocity of an unladen swallow?
    1) 24 miles per hour
    2) African or European?
", 
            2, 25);
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

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            Robe AdventurerRobe = new Robe();
            AdventurerRobe.Colors = new List<string>();
            AdventurerRobe.Length = 60;
            AdventurerRobe.Colors.Add("red, white and blue");

            Hat OldDirtyHat = new Hat();
            OldDirtyHat.ShininessLevel = 1;

            Prize goldCoin = new Prize("You earned a gold coin!");


            Console.WriteLine("What is your name, adventurer?");
            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(Console.ReadLine(), AdventurerRobe, OldDirtyHat);

            Console.WriteLine(theAdventurer.GetDescription());

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                cupsOfSugar,
                favoriteColor,
                swallowVelocity
            };

            adventure();

            void adventure() {
                //reset adventurer awesomeness level each time the quest is played
                theAdventurer.Awesomeness = 50 + (theAdventurer.Xp * 10);
                if(theAdventurer.Xp > 0)
                {
                    Console.WriteLine($"{theAdventurer.Name} has gained {theAdventurer.Xp} XP, and their current awesomeness level is {theAdventurer.Awesomeness}.");
                }
                //create a new list of random challenges each time the quest is played
                List<Challenge> questChallenges = new List<Challenge>(){};
                while (questChallenges.Count < 5)
                {
                    int index = new Random().Next(0, challenges.Count-1);
                    if (!questChallenges.Contains(challenges[index]))
                    {
                        questChallenges.Add(challenges[index]);
                    }
                }

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in questChallenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
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

                goldCoin.ShowPrize(theAdventurer);

                Console.WriteLine("Would you like to attempt this quest once more?");

                string replay = Console.ReadLine().ToLower();

                if(replay == "yes" || replay == "y") 
                {
                    adventure();
                }
                else if (replay == "no" || replay == "n")
                {
                    Console.WriteLine("Your appetite for adventure is puny.");
                }
                else
                {
                    Console.WriteLine("This is a yes or no question. Quest again?");
                    replay = Console.ReadLine().ToLower();
                    if(replay == "yes" || replay == "y") 
                    {
                        adventure();
                    }
                    else if (replay == "no" || replay == "n")
                    {
                        Console.WriteLine("Your appetite for adventure is puny.");
                    }
                    else
                    {
                        Console.WriteLine("Ok, we're done here...");
                    }
                }
            }    
        }
    }
}
