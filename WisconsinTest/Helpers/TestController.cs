using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.IO;
using WisconsinTest.Models;

namespace WisconsinTest.Controllers
{
    public class TestController : Controller
    {

        public ActionResult StartTest()
        {
            // Session start parameters
            Session["Cards"] = WiscounsinTest.Models.CardList.GetCards();
            Session["Rule"] = 1;
            Session["CorrectAnswers"] = 0;
            Session["ResultedRulesList"] = new List<int>();
            Session["NumberOfChanges"] = 0;
            Session["NumberofTrials"] = 0;
            Session["TotalCorrect"] = 0;
            Session["PerseverativeErrors"] = 0;
            Session["NonPerseverativeErrors"] = 0;

            return View();
        }

            //UTWORZENIE SESJI:
        public ActionResult Test(string button)
        {
            if ((int)Session["NumberOfChanges"] <= 1)//6 ma byc
            {
                if (button != null)
                {
                    TestCount(button);
                }

                string directoryPath = @"~/Content/Images/cards";
                Session["ImageFileName"] = PickImageFromDirectory(directoryPath);
                //ViewBag.ImagePath = Path.Combine(directoryPath, (string)Session["ImageFileName"]);
                ViewBag.ImagePath = directoryPath + "/" + (string)Session["ImageFileName"];


                return View();
            }
            else
                //return View("TestResult");
                return RedirectToAction("TestResult");

        }

        public void TestCount(string button)
        {
                switch (button)
                {

                    case "btnCircle":
                        var NumberofTrials = (int)Session["NumberofTrials"];
                        NumberofTrials++;
                        Session["NumberofTrials"] = NumberofTrials;
                        CreateResultList((string)Session["ImageFileName"], "red", 1, "circle");
                        ImageAction();
                        break;
                    case "btnRectangle":
                        NumberofTrials = (int)Session["NumberofTrials"];
                        NumberofTrials++;
                        Session["NumberofTrials"] = NumberofTrials;
                        CreateResultList((string)Session["ImageFileName"], "blue", 3, "rectangle");
                        ImageAction();
                        break;
                    case "btnCross":
                        NumberofTrials = (int)Session["NumberofTrials"];
                        NumberofTrials++;
                        Session["NumberofTrials"] = NumberofTrials;
                        CreateResultList((string)Session["ImageFileName"], "yellow", 4, "cross");
                        ImageAction();
                        break;
                    case "btnStar":
                        NumberofTrials = (int)Session["NumberofTrials"];
                        NumberofTrials++;
                        Session["NumberofTrials"] = NumberofTrials;
                        CreateResultList((string)Session["ImageFileName"], "green", 2, "star");
                        ImageAction();
                        break;
                    default:
                        break;

            }
        }
       

        /*public ActionResult TestResult()
        {
            return View();
        }*/

        public ActionResult TestResult()
        {
            Session["NumberofTrials"] = (int)Session["NumberofTrials"];
            ViewBag.NumberofTrials = Session["NumberofTrials"].ToString();
            ViewBag.TotalCorrect = Session["TotalCorrect"].ToString();
            ViewBag.PerseverativeErrors= Session["PerseverativeErrors"].ToString();
            ViewBag.NonPerseverativeErrors = Session["NonPerseverativeErrors"].ToString();
            string test = String.Join<int>(",", (List<int>)Session["ResultedRulesList"]);

            string idPatientString = Session["PatientId"].ToString();
            int idPatient = int.Parse(idPatientString);

            using (WiscounsinTestDatabaseEntities db = new WiscounsinTestDatabaseEntities())
            {
                Surveys survey = new Surveys();
                Results result = new Results();

                survey.PatientId = idPatient;
                survey.Date = DateTime.Today;

                result.CorrectAnswers = Int32.Parse(ViewBag.TotalCorrect);
                result.NonPerseveranceErrors = Int32.Parse(ViewBag.NonPerseverativeErrors);
                result.NumberOfTries = Int32.Parse(ViewBag.NumberofTrials);
                result.PerseverationErrors = Int32.Parse(ViewBag.PerseverativeErrors);
                result.Rules = test;
                

                //if(db.Surveys.Any)
                //result.SurveyId = if()
            }

            
            ViewBag.TestSequence = test;
            Session["NumberofTrials"] = 0;
            Session["TotalCorrect"] = 0;
            Session["PerseverativeErrors"] = 0;
            Session["NonPerseverativeErrors"] = 0;
            Session["NumberOfChanges"] = 0;
            Session["CorrectAnswers"] = 0;
            var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
            ResultedRulesList.Clear();
            Session["ResultedRulesList"] = ResultedRulesList;

            return View();
        }

        private string PickImageFromDirectory(string DirectoryPath)
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath(DirectoryPath));
            FileInfo[] fileList = di.GetFiles();
            int numberOfFiles = fileList.Length;

            Random rnd = new Random();
            int randomFileIndex = rnd.Next(numberOfFiles);
            string imageFileName = fileList[randomFileIndex].Name;

            return imageFileName;

        }

        private void ImageAction()
        {
                if ((int)Session["CorrectAnswers"] == 5)
                {

                    int newRule = 0;
                    do
                    {
                        Random rnd = new Random();
                        newRule = rnd.Next(1, 4);
                    }
                    while (newRule == (int)Session["Rule"]);
                    Session["Rule"] = newRule;
                    var NumberOfChanges = (int)Session["NumberOfChanges"];
                    NumberOfChanges++;
                    Session["NumberOfChanges"] = NumberOfChanges;
                    Session["CorrectAnswers"] = 0;
                    var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                    ResultedRulesList[ResultedRulesList.Count - 1] = ResultedRulesList[ResultedRulesList.Count - 1] * 10;
                    Session["ResultedRulesList"] = ResultedRulesList;
                }


                string directoryPath = @"~/Content/Images/cards";
                Session["ImageFileName"] = PickImageFromDirectory(directoryPath);
                //ViewBag.ImagePath = Path.Combine(directoryPath, (string)Session["ImageFileName"]);
                ViewBag.ImagePath = directoryPath + "/" + (string)Session["ImageFileName"];

        }

        private void CreateResultList(string fileName, string color, int number, string shape)
        {
            foreach (WiscounsinTest.Models.Card  c in (List<WiscounsinTest.Models.Card>)Session["Cards"])
                //foreach (Card c in (List<Card>)Session["Cards"])
            {
                if (c.CardID == fileName)
                {
                    switch ((int)Session["Rule"])
                    {
                        case 1:
                            if (c.CardColor == color)
                            {
                                var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                ResultedRulesList.Add(1);
                                Session["ResultedRulesList"] = ResultedRulesList;
                                Check(1);
                            }
                            else
                            {
                                if (c.CardNumber == number)
                                {
                                    var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                    ResultedRulesList.Add(2);
                                    Session["ResultedRulesList"] = ResultedRulesList;
                                    Check(2);
                                }
                                else
                                {
                                    if (c.CardShape == shape)
                                    {
                                        var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                        ResultedRulesList.Add(3);
                                        Session["ResultedRulesList"] = ResultedRulesList;
                                        Check(3);
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (c.CardNumber == number)
                            {
                                var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                ResultedRulesList.Add(2);
                                Session["ResultedRulesList"] = ResultedRulesList;
                                Check(2);
                            }
                            else
                            {
                                if (c.CardShape == shape)
                                {
                                    var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                    ResultedRulesList.Add(3);
                                    Session["ResultedRulesList"] = ResultedRulesList;
                                    Check(3);
                                }
                                else
                                {
                                    if (c.CardColor == color)
                                    {
                                        var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                        ResultedRulesList.Add(1);
                                        Session["ResultedRulesList"] = ResultedRulesList;
                                        Check(1);
                                    }
                                }
                            }
                            break;

                        case 3:
                            if (c.CardShape == shape)
                            {
                                var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                ResultedRulesList.Add(3);
                                Session["ResultedRulesList"] = ResultedRulesList;
                                Check(3);
                            }
                            else
                            {
                                if (c.CardColor == color)
                                {
                                    var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                    ResultedRulesList.Add(1);
                                    Session["ResultedRulesList"] = ResultedRulesList;
                                    Check(1);
                                }
                                else
                                {
                                    if (c.CardNumber == number)
                                    {
                                        var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
                                        ResultedRulesList.Add(2);
                                        Session["ResultedRulesList"] = ResultedRulesList;
                                        Check(2);
                                    }
                                }
                            }
                            break;
                        default:
                            ViewBag.LastChoiceResult = "Źle!";
                            var NonPerseverativeErrors = (int)Session["NonPerseverativeErrors"];
                            NonPerseverativeErrors++;
                            Session["NonPerseverativeErrors"] = NonPerseverativeErrors;
                            break;
                    }
                }
            }
        }
        private void Check(int resultedRule)
        {
            if ((int)Session["Rule"] == resultedRule)
            {
                ViewBag.LastChoiceResult = "Dobrze!";
                var CorrectAnswers = (int)Session["CorrectAnswers"];
                CorrectAnswers++;
                Session["CorrectAnswers"] = CorrectAnswers;
                var TotalCorrect = (int)Session["TotalCorrect"];
                TotalCorrect++;
                Session["TotalCorrect"] = TotalCorrect;
            }
            else
            {
                ViewBag.LastChoiceResult = "Źle!";
                CheckError(resultedRule);
            }
        }

        private void CheckError(int resultedRule)
        {
            var ResultedRulesList = (List<int>)Session["ResultedRulesList"];
            if (ResultedRulesList.Count >= 2)
            {
                if (ResultedRulesList[ResultedRulesList.Count - 2] == resultedRule)
                {
                    var PerseverativeErrors = (int)Session["PerseverativeErrors"];
                    PerseverativeErrors++;
                    Session["PerseverativeErrors"] = PerseverativeErrors;
                }
                else
                {
                    var NonPerseverativeErrors = (int)Session["NonPerseverativeErrors"];
                    NonPerseverativeErrors++;
                    Session["NonPerseverativeErrors"] = NonPerseverativeErrors;
                }
            }
            else
            {
                var NonPerseverativeErrors = (int)Session["NonPerseverativeErrors"];
                NonPerseverativeErrors++;
                Session["NonPerseverativeErrors"] = NonPerseverativeErrors;
            }
        }

    }
}