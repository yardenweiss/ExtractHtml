using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractContent
{
    class Program
    {

        static void Main()
        {
            HtmlParse parse = new HtmlParse();
            parse.Run();
        }

    }
}
