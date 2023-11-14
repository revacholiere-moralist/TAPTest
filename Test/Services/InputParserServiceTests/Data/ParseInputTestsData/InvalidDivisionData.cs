using Domain.Entities;
using Domain.Enums;

namespace Test.Services.InputParserServiceTests.Data.ParseInputTestsData
{
    public class InvalidDivisionData : TheoryData<string>
    {
        public InvalidDivisionData()
        {
            var input1 = "m 52 44 70 65 100";
            var input2 = "t 65 54 82 67 99";

            Add(input1);
            Add(input2);

        }
    };
}
