using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MathExpression.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.TellMe = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string expression)
        {
            ViewBag.TellMe = this.Answer(expression);
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Answer(string expression)
        {
            string reply = "";

            // extract numbers only
            string[] numbers = expression.Split(new char[] { '*', '/', '+', '-' });

            // sanitize numbers
            int[] n = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; ++i)
            {
                reply = int.TryParse(numbers[i], out n[i]) ? "" : "Invalid Expression";
                if (reply == "Invalid Expression")
                {
                    return reply;
                }
            }


            // *  /  +  - 
            // extract operators only
            List<string> opr=new List<string>();  
            string[] oprs = Regex.Split(expression, @"\d+");
//            string[] operators = Regex.Split(expression, @"\d+");
            opr.Add(oprs[0]);
            foreach (string cr in oprs)
            {
                if(cr!="")
                    opr.Add(cr);
            }
            string[] operators = new string[opr.Count];
            operators = opr.ToArray();

            // sanitize operators
            /*
//            Regex regex = new Regex(@"[*///+-]");
//            for(int c=1;c<operators.Length;++c)
//            {
//                reply= (!(regex.IsMatch(operators[c]))) ? "" : "Invalid Expression";
//                if (reply == "Invalid Expression")
//                {
//                    ViewBag.Response = reply;
//                    return View("About");
//                }
//            }
            

            // calc
            int[] importance = new int[n.Length];
            int curr = 0;
            for(int k= 1; k < operators.Length; ++k)
            {
                if ("*"==operators[k])
                {
                    n[k] *= n[k - 1] ;
                    n[k - 1] = n[k];
                    operators[k] = "x";
                    curr = n[k];
                }
            }
            for (int k = 1; k < operators.Length; ++k)
            {
                if ("/" == operators[k])
                {
                    n[k-1] /= n[k];
                    n[k] = n[k-1];
                    operators[k] = "x";
                    curr = n[k];
                }
            }
            for (int k = 1; k < operators.Length; ++k)
            {
                if ("+" == operators[k])
                {
                    n[k] += n[k - 1];
                    n[k - 1] = n[k];
                    operators[k] = "x";
                    curr = n[k];
                }
            }
            for (int k = 1; k < operators.Length; ++k)
            {
                if ("-" == operators[k])
                {
                    n[k-1] -= n[k];
                    n[k] = n[k-1];
                    operators[k] = "x";
                    curr = n[k];
                }
            }

            return curr.ToString();

            //            ViewBag.Response = operators[0]; // replies with answer

        }
    }
}