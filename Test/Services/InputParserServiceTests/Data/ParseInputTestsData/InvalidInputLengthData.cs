using Domain.Entities;
using Domain.Enums;

namespace Test.Services.InputParserServiceTests.Data.ParseInputTestsData
{
    public class InvalidInputLengthData : TheoryData<string>
    {
        public InvalidInputLengthData()
        {
            // Data 1 (too many tests)
            var input1 = "l 52 44 70 65 100 70";
           
            Add(input1);

            // Data 2 (too few tests)
            var input2 = "s 70 78 82 57";
            
            Add(input2);

            // Data 3 (too many tests, multiple data)
            var input3 = "s 70 78 82 57 70\nl 60 81 67 80 95 90";

            Add(input3);

            // Data 4 (too few tests, multiple data)
            var input4 = "s 70 78 82 57 70\nl 60 81 67 80";

            Add(input4);
        }
    };
}
