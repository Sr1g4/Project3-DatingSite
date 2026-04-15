using Microsoft.AspNetCore.Mvc;
using DatingSiteLibrary;
using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;
using System.Text;
using System.Text.Json;

namespace Project3_DatingSite.Controllers
{


    namespace MVCWebApp.Controllers
    {
        public class AccountController : Controller
        {
          

            [HttpPost]
            public IActionResult Login(LoginViewModel login)
            {
                if (login == null)
                {
                    ViewData["Message"] = "Error occurred. Try again later...";
                    return View(new LoginViewModel());
                }

                if (login.Username == null || login.Username.Trim() == "")
                {
                    ViewData["Message"] = "Username is required.";
                    return View(login);
                }

                if (login.Password == null || login.Password.Trim() == "")
                {
                    ViewData["Message"] = "Password is required.";
                    return View(login);
                }

                Account acctToSend = new Account();
                acctToSend.Username = login.Username;
                acctToSend.Password = SecurityHelper.HashPassword(login.Password);

                string apiUrl = "http://localhost:5192/api/MembersService/Login";

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(
                    JsonSerializer.Serialize(acctToSend),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Login service failed.";
                    return View(login);
                }

                string json = response.Content.ReadAsStringAsync().Result;

                Account acctFound = JsonSerializer.Deserialize<Account>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (acctFound == null || acctFound.MemberID <= 0)
                {
                    ViewData["Message"] = "Invalid username or password.";
                    return View(login);
                }

                HttpContext.Session.SetInt32("MemberID", acctFound.MemberID);
                HttpContext.Session.SetString("Username", acctFound.Username);
                HttpContext.Session.SetString("FirstName", acctFound.FirstName);
                HttpContext.Session.SetString("LastName", acctFound.LastName);

                if (acctFound.Email != null)
                {
                    HttpContext.Session.SetString("AccountEmail", acctFound.Email);
                }

                if (login.RememberMe == true)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("SavedUsername", login.Username, options);
                }
                else
                {
                    Response.Cookies.Delete("SavedUsername");
                }

                return RedirectToAction("Index", "Home");
            }

            [HttpPost]
            public IActionResult Register(RegisterViewModel reg)
            {
                if (reg == null)
                {
                    ViewData["Message"] = "Error occurred. Try again later...";
                    return View(new RegisterViewModel());
                }

                if (reg.Username == null || reg.Username.Trim() == "")
                {
                    ViewData["Message"] = "Username is required.";
                    return View(reg);
                }

                if (reg.Password == null || reg.Password.Trim() == "")
                {
                    ViewData["Message"] = "Password is required.";
                    return View(reg);
                }

                if (reg.FirstName == null || reg.FirstName.Trim() == "")
                {
                    ViewData["Message"] = "First name is required.";
                    return View(reg);
                }

                if (reg.LastName == null || reg.LastName.Trim() == "")
                {
                    ViewData["Message"] = "Last name is required.";
                    return View(reg);
                }

                if (reg.Email == null || reg.Email.Trim() == "")
                {
                    ViewData["Message"] = "Email is required.";
                    return View(reg);
                }

                Account acctToSend = new Account();
                acctToSend.Username = reg.Username;
                acctToSend.Password = SecurityHelper.HashPassword(reg.Password);
                acctToSend.FirstName = reg.FirstName;
                acctToSend.LastName = reg.LastName;
                acctToSend.Email = reg.Email;

                string apiUrl = "http://localhost:7295/api/MembersService/Register";

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(acctToSend),
                    System.Text.Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Registration service failed.";
                    return View(reg);
                }

                string json = response.Content.ReadAsStringAsync().Result;

                Account acctCreated = System.Text.Json.JsonSerializer.Deserialize<Account>(json, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (acctCreated == null || acctCreated.MemberID <= 0)
                {
                    ViewData["Message"] = "Registration failed.";
                    return View(reg);
                }

                HttpContext.Session.SetInt32("MemberID", acctCreated.MemberID);
                HttpContext.Session.SetString("Username", acctCreated.Username);
                HttpContext.Session.SetString("FirstName", acctCreated.FirstName);
                HttpContext.Session.SetString("LastName", acctCreated.LastName);

                if (acctCreated.Email != null)
                {
                    HttpContext.Session.SetString("AccountEmail", acctCreated.Email);
                }

                return RedirectToAction("Index", "Home");
            }

            [HttpPost]
            public IActionResult ForgotUsername(ForgotUsernameViewModel model)
            {
                if (model == null)
                {
                    ViewData["Message"] = "Error occurred. Try again later...";
                    return View(new ForgotUsernameViewModel());
                }

                if (model.Email == null || model.Email.Trim() == "")
                {
                    ViewData["Message"] = "Email is required.";
                    return View(model);
                }

                string apiUrl = "http://localhost:7295/api/MembersService/GetUsernameByEmail/" + model.Email;

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Username lookup failed.";
                    return View(model);
                }

                string json = response.Content.ReadAsStringAsync().Result;

                string username = System.Text.Json.JsonSerializer.Deserialize<string>(json, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (username == null || username.Trim() == "")
                {
                    ViewData["Message"] = "No username was found for that email.";
                    return View(model);
                }

                model.RecoveredUsername = username;
                ViewData["Message"] = "Username found.";

                return View(model);
            }

            [HttpPost]
            public IActionResult ForgotPassword(ForgotPasswordViewModel model)
            {
                if (model == null)
                {
                    ViewData["Message"] = "Error occurred. Try again later...";
                    return View(new ForgotPasswordViewModel());
                }

                if (model.Username == null || model.Username.Trim() == "")
                {
                    ViewData["Message"] = "Username is required.";
                    return View(model);
                }

                HttpClient client = new HttpClient();

                string memberUrl = "http://localhost:7295/api/MembersService/GetMemberByUsername/" + model.Username;
                HttpResponseMessage memberResponse = client.GetAsync(memberUrl).Result;

                if (memberResponse.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Could not find account.";
                    return View(model);
                }

                string memberJson = memberResponse.Content.ReadAsStringAsync().Result;

                Account acct = System.Text.Json.JsonSerializer.Deserialize<Account>(memberJson, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (acct == null || acct.MemberID <= 0)
                {
                    ViewData["Message"] = "Could not find account.";
                    return View(model);
                }

                string questionsUrl = "http://localhost:7295/api/MembersService/GetSecurityQuestionsByMemberID/" + acct.MemberID;
                HttpResponseMessage questionResponse = client.GetAsync(questionsUrl).Result;

                if (questionResponse.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Could not retrieve security question.";
                    return View(model);
                }

                string questionJson = questionResponse.Content.ReadAsStringAsync().Result;

                List<SecurityQuestion> questions = System.Text.Json.JsonSerializer.Deserialize<List<SecurityQuestion>>(questionJson, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (questions == null || questions.Count == 0)
                {
                    ViewData["Message"] = "No security questions found for this account.";
                    return View(model);
                }

                Random rnd = new Random();
                int index = rnd.Next(questions.Count);
                SecurityQuestion selectedQuestion = questions[index];

                ForgotPasswordViewModel nextModel = new ForgotPasswordViewModel();
                nextModel.MemberID = acct.MemberID;
                nextModel.Username = acct.Username;
                nextModel.QuestionID = selectedQuestion.QuestionID;
                nextModel.QuestionText = selectedQuestion.QuestionText;

                return View("ResetPassword", nextModel);
            }
            [HttpPost]
            public IActionResult ResetPassword(ForgotPasswordViewModel model)
            {
                if (model == null)
                {
                    ViewData["Message"] = "Error occurred. Try again later...";
                    return View("ResetPassword", new ForgotPasswordViewModel());
                }

                if (model.Answer == null || model.Answer.Trim() == "")
                {
                    ViewData["Message"] = "Answer is required.";
                    return View("ResetPassword", model);
                }

                if (model.NewPassword == null || model.NewPassword.Trim() == "")
                {
                    ViewData["Message"] = "New password is required.";
                    return View("ResetPassword", model);
                }

                HttpClient client = new HttpClient();

                SecurityAnswer answerObj = new SecurityAnswer();
                answerObj.MemberID = model.MemberID;
                answerObj.QuestionID = model.QuestionID;
                answerObj.Answer = model.Answer;

                StringContent verifyContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(answerObj),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage verifyResponse = client.PostAsync("http://localhost:7295/api/MembersService/VerifySecurityAnswer", verifyContent).Result;

                if (verifyResponse.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Security verification failed.";
                    return View("ResetPassword", model);
                }

                string verifyJson = verifyResponse.Content.ReadAsStringAsync().Result;
                bool verified = System.Text.Json.JsonSerializer.Deserialize<bool>(verifyJson, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (verified == false)
                {
                    ViewData["Message"] = "Security answer was incorrect.";
                    return View("ResetPassword", model);
                }

                Account acct = new Account();
                acct.MemberID = model.MemberID;
                acct.ResetCode = "RESET123";
                acct.ResetCodeExpiresOn = DateTime.Now.AddMinutes(15);

                StringContent startContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(acct),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage startResponse = client.PostAsync("http://localhost:7295/api/MembersService/StartPasswordReset", startContent).Result;

                if (startResponse.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Password reset could not be started.";
                    return View("ResetPassword", model);
                }

                Account acctReset = new Account();
                acctReset.MemberID = model.MemberID;
                acctReset.ResetCode = "RESET123";
                acctReset.Password = SecurityHelper.HashPassword(model.NewPassword);

                StringContent resetContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(acctReset),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage resetResponse = client.PostAsync("http://localhost:7295/api/MembersService/ResetPassword", resetContent).Result;

                if (resetResponse.IsSuccessStatusCode == false)
                {
                    ViewData["Message"] = "Password reset failed.";
                    return View("ResetPassword", model);
                }

                string resetJson = resetResponse.Content.ReadAsStringAsync().Result;
                bool resetSuccess = System.Text.Json.JsonSerializer.Deserialize<bool>(resetJson, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (resetSuccess == false)
                {
                    ViewData["Message"] = "Password reset failed.";
                    return View("ResetPassword", model);
                }

                ViewData["Message"] = "Password reset successfully. Please log in.";
                return View("Login", new LoginViewModel());
            }
            public IActionResult Login()
            {
                LoginViewModel model = new LoginViewModel();

                if (Request.Cookies["SavedUsername"] != null)
                {
                    model.Username = Request.Cookies["SavedUsername"].ToString();
                    model.RememberMe = true;
                }

                return View(model);
            }
            public IActionResult ForgotUsername()
            {
                return View(new ForgotUsernameViewModel());
            }
            public IActionResult ForgotPassword()
            {
                return View(new ForgotPasswordViewModel());
            }

            public IActionResult Register()
            {
                return View(new RegisterViewModel());
            }
            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account");
            }
        }
    }
}