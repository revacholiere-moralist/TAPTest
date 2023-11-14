using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Features.TestResultFeatures.Data.GetTotalPassingApplicantsData
{
    public class SucceedData : TheoryData<List<ApplicantTestResult>, int>
    {
        public SucceedData()
        {
            // Data 1 
            // Passed both total score and division score criteria
            var data1 = new List<ApplicantTestResult>();
            data1.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100,
                }
            });

            // Failed both score criteria
            data1.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 0,
                    Math = 0,
                    Science = 0,
                    Japanese = 0,
                    Geography = 0
                }
            });

            Add(data1, 1);

            // Data 2
            // Passed only total score criteria
            var data2 = new List<ApplicantTestResult>();
            data2.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 95
                }
            });

            // Passed both total score and division score criteria
            data2.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100
                }
            });

            Add(data2, 1);

            // Data 3
            // Passed only division score criteria
            var data3 = new List<ApplicantTestResult>();
            data3.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 90
                }
            });

            // Passed both total score and division score criteria
            data3.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100
                }
            });

            Add(data3, 1);

            // Data 4
            // Passed both score criteria
            var data4 = new List<ApplicantTestResult>();
            data4.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100
                }
            });

            // Passed both score criteria
            data4.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100
                }
            });

            // Passed only division criteria
            data4.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 90
                }
            });

            Add(data4, 2);

            // Data 5
            // Passed both score criteria
            var data5 = new List<ApplicantTestResult>();
            data5.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100
                }
            });

            // Passed both score criteria
            data5.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100
                }
            });

            // Passed both score criteria
            data5.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 100
                }
            });

            Add(data5, 3);
        }
    }
}
