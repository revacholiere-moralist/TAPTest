using Domain.Entities;
using Domain.Enums;

namespace Test.Services.InputParserServiceTests.Data.ParseInputTestsData
{
    public class InvalidScoresData : TheoryData<string, string>
    {
        public InvalidScoresData()
        {
            var invalidScoreTypeMessage = "Please input a valid integer for each test score.";
            var invalidScoreValueMessage = "Please input a value between 0 and 100 for each test score.";

            // Data 1 (score not an integer)
            var input1 = "l 52 m 70 65 100";
            
            Add(input1, invalidScoreTypeMessage);

            // Data 2 (score not an integer)
            var input2 = "s 70 78 82 57 s";
            
            Add(input2, invalidScoreTypeMessage);

            // Data 3 (score less than 0)
            var input3 = "s 70 78 82 -20 70";

            Add(input3, invalidScoreValueMessage);

            // Data 4 (score more than 100)
            var input4 = "s 70 78 120 57 70";

            Add(input4, invalidScoreValueMessage);

            // Data 5 (score less than 0, multiple data)
            var input5 = "s 70 78 82 -20 70\n l 82 27 -25 67 98";

            Add(input5, invalidScoreValueMessage);

            // Data 6 (score more than 100, multiple data)
            var input6 = "s 70 78 82 57 70\n l 60 87 130 55 82";

            Add(input6, invalidScoreValueMessage);
        }
    };
}
