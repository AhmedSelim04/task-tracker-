using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    public static class Extensions 
    {
        public static string[] CLSplit(this string? input)//Command Line Split
        {
            if (input.Length==0)
            {
                string[] x = { "" };
                return x;
            }
            string[] inputs = input.Split(' ');
            List<string> list=new List<string>();
            bool inName = false;
            for(int i = 0; i < inputs.Length; i ++)
            {
                if (inputs[i][0] == '"') inName = true;
                if (inName)
                {
                    string x="";

                    while (i < inputs.Length && inputs[i][^1] != '"') 
                    {
                        x += inputs[i++];
                    }
                    x += inputs[i];
                    inName = false;
                    list.Add(x);
                }
                else
                {
                    list.Add(inputs[i]);
                }
            }
            return list.ToArray();
        }
    }
}
