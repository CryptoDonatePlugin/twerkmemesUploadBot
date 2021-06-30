using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twerkmemes_Upload_Images_Bot_1._0._0
{
    

    public partial class Form1 : Form
    {
        int counter;
        List<String> MemesList = new List<String>();
        public Form1()
        {
            
            MemesList = GetTitles();
            counter = 0;
            InitializeComponent();
            LoginPage();
        }

        public List<String> GetTitles()
        {
            List<String> memesTitles = new List<String>();
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            int year = now.Year;
            string path = year + "." + month + "." + day;
            DirectoryInfo d = new DirectoryInfo(path);
            foreach (var dir in d.GetDirectories())
            {
                memesTitles.Add(dir.Name);
            }

            return memesTitles;
        }

        public String getTags(string fileName)
        {
            string line=String.Empty;
            using (StreamReader sr = new StreamReader(fileName))
            {
                
                line = sr.ReadToEnd();

            }
            
            return line;
        }

        private void LoginPage()
        {
            AutoBot.ScriptErrorsSuppressed = true;
            AutoBot.Navigate("https://twerkmemes.com/wp-login.php");
  
        }

        private void LoginToPage(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (counter < MemesList.Count)
            {
                if (AutoBot.Url.ToString().Contains("wp-login"))
                {
                    HtmlElement login = AutoBot.Document.GetElementById("user_login");
                    login.SetAttribute("value", "poofpoof");
                    HtmlElement pass = AutoBot.Document.GetElementById("user_pass");
                    pass.SetAttribute("value", "e9nan@6a=V<(/yvS>o{GKG4bK");
                    AutoBot.Document.GetElementById("wp-submit").InvokeMember("click");
                }
                if (AutoBot.Url.ToString().Contains("wp-admin") && !AutoBot.Url.ToString().Contains("post-new.php"))
                {
                    AutoBot.Navigate("https://twerkmemes.com/wp-admin/media-new.php");
                }
                if (AutoBot.Url.ToString().Contains("media-new.php"))
                {

                    HtmlElement uploadField = AutoBot.Document.GetElementById("async-upload");
                    timer1.Interval = 3000;
                    timer1.Start();
                    uploadField.InvokeMember("click");
                    HtmlElement uploadButton = AutoBot.Document.GetElementById("html-upload");
                    uploadButton.InvokeMember("click");
                }
                if (AutoBot.Url.ToString().Contains("upload.php"))
                {
                    AutoBot.Navigate("https://twerkmemes.com/wp-admin/post-new.php");
                }
                if (AutoBot.Url.ToString().Contains("post-new.php"))
                {
                    HtmlElement title = AutoBot.Document.GetElementById("title");
                    title.SetAttribute("value", MemesList[counter]); //title lista[counter] 7

                    HtmlElement content = AutoBot.Document.GetElementById("content");
                    content.SetAttribute("value", MemesList[counter]); //title lista[counter]

                    HtmlElement category = AutoBot.Document.GetElementById("in-category-3");
                    category.SetAttribute("checked", "checked");

                    var seotitles = AutoBot.Document.GetElementsByTagName("input");
                    foreach (HtmlElement seotitle in seotitles)
                    {
                        if (seotitle.GetAttribute("className") == " aioseop_count_chars")
                        {
                            seotitle.SetAttribute("value", MemesList[counter]); //title lista[counter]
                        }
                    }

                    var seodesc = AutoBot.Document.GetElementsByTagName("textarea");
                    foreach (HtmlElement description in seodesc)
                    {
                        if (description.GetAttribute("className") == " aioseop_count_chars")
                        {
                            description.SetAttribute("value", MemesList[counter]); //title lista[counter]
                        }
                    }

                    HtmlElement keywords = AutoBot.Document.GetElementsByTagName("input").GetElementsByName("aiosp_keywords")[0];
                    keywords.SetAttribute("value", "funny memes, funny pictures, sentenses, memes 2020, memes of the decade, memes for kids, memes about love, memes about men, funny images, memes about depression, memes about beign single, memes about lairs, memes about being sick, senteneses for kids, sentensees about love, sentenses about family");

                    HtmlElement tags = AutoBot.Document.GetElementById("new-tag-post_tag");
                    DateTime now = DateTime.Now;
                    int day = now.Day;
                    int month = now.Month;
                    int year = now.Year;
                    string path = year + "." + month + "." + day+"/"+ MemesList[counter]+"/tags.txt";
                    string tagsFromFile = getTags(path);
                    tags.SetAttribute("value", tagsFromFile); //title lista[counter] zczytane

                    var tagadds = AutoBot.Document.GetElementsByTagName("input");
                    foreach (HtmlElement tagadd in tagadds)
                    {
                        if (tagadd.GetAttribute("className") == "button tagadd")
                        {
                            tagadd.InvokeMember("click");
                        }
                    }

                    HtmlElement addThumb = AutoBot.Document.GetElementById("set-post-thumbnail");
                    timer2.Interval = 3000;
                    timer2.Start();
                    addThumb.InvokeMember("click");

                    //publish
                    HtmlElement publish = AutoBot.Document.GetElementById("publish");
                    counter++;
                    DoLater(publish);
                }
            }
            else
            {
                Application.Exit();
            }
            //if counter<size 5
            //else wyjdź
            
   
        }

       
        static async void DoLater(HtmlElement x)
        {
            await Task.Delay(5000);
            x.InvokeMember("click");
        }
        

        private void Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                SendKeys.SendWait("C:\\images\\" + MemesList[counter]+".jpg");

                SendKeys.SendWait("{TAB 2}");
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddMedia(object sender, EventArgs e)
        {
            try
            {
                timer2.Stop();
                SendKeys.SendWait("{TAB 7}");
                SendKeys.SendWait("{ENTER}");
                SendKeys.SendWait("+{TAB 8}");
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
