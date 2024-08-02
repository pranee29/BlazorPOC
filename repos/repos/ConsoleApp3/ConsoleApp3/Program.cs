using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace ConsoleApp_forJson_using_stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JObject main_parent = new JObject();
            Stack<JObject> stack = new Stack<JObject>();
            Stack<string> stack2 = new Stack<string>();
            Queue<string> myQueue = new Queue<string>();
            foreach (string line in File.ReadLines(@"C:\Users\NHI468\Downloads\Employeee.txt"))
            {
                string line2 = line.Replace("-", "");
                string last = line2.Split(',').Last();
                string start = line2.Split(',').First();

                string[] values = line.TrimStart().Split(',');
                string name = "";
                if (values.Length > 1)
                {
                    name = values[1];
                }


                int HyphenCount = 0;
                if (stack.Count == 0)
                {

                    JObject present = new JObject();
                    // present.Add(cnt + " ", name);
                    present.Add(name, name);
                    stack.Push(present);
                    continue;
                }
                foreach (Match m in Regex.Matches(line, "-"))
                {
                    HyphenCount++;
                }


                if (start == "Attribute" & last == "Group")
                {

                    if (HyphenCount == 1 & stack.Count > 1)
                    {
                        JObject top_ele = stack.Pop();
                        JObject top_parent = stack.Pop();

                        while (myQueue.Count > 0)
                        {
                            string temp_name = myQueue.Dequeue();
                            top_parent.Add(temp_name, temp_name);
                        }
                        stack.Push(top_parent);
                        stack.Push(top_ele);
                    }

                    else if (HyphenCount > 1 & myQueue.Count != 0)
                    {
                        JObject top_parent = stack.Pop();
                        //JObject top_parent = stack.Peek();
                        //stack.Push(top_parent
                        //);
                        while (myQueue.Count > 0)
                        {
                            string temp_name = myQueue.Dequeue();
                            top_parent.Add(temp_name, temp_name);
                        }
                        stack.Push(top_parent);
                    }

                    if (stack.Count - 1 < HyphenCount)
                    {
                        JObject present = new JObject();
                        // present.Add(name, name);
                        stack.Push(present);
                        stack2.Push(name);
                    }

                    else if (stack.Count - 1 == HyphenCount)
                    {
                        string childname = stack2.Pop();
                        JObject child = stack.Pop();
                        JObject parent = stack.Peek();
                        // Console.WriteLine("c :"+child + " p:" + parent+"\n");
                        parent.Add(childname, child);
                        //Console.WriteLine("check :"+child.ToString());    
                        stack.Pop();
                        stack.Push(parent);
                        JObject present = new JObject();
                        // present.Add(name, name);
                        stack.Push(present);
                        stack2.Push(name);
                    }

                    else if (stack.Count - 1 > HyphenCount)
                    {

                        string childname = stack2.Pop();
                        JObject child = stack.Pop();
                        JObject parent = stack.Peek();
                        // Console.WriteLine("c :"+child + " p:" + parent+"\n");
                        parent.Add(childname, child);
                        //Console.WriteLine("check :"+child.ToString());    
                        stack.Pop();
                        stack.Push(parent);


                        string childname1 = stack2.Pop();
                        JObject child1 = stack.Pop();
                        JObject parent1 = stack.Peek();
                        // Console.WriteLine("c :"+child + " p:" + parent+"\n");
                        parent1.Add(childname1, child1);
                        //Console.WriteLine("check :"+child.ToString());    
                        stack.Pop();
                        stack.Push(parent1);
                        JObject present1 = new JObject();
                        //  present1.Add(name, name);
                        stack.Push(present1);
                        stack2.Push(name);
                    }
                }
                if (start == "Attribute" & last != "Group")
                {
                    myQueue.Enqueue(name);

                }

                if (last == "EndGroup")
                {
                    JObject child = stack.Pop();

                    while (myQueue.Count > 0)
                    {
                        string n = myQueue.Dequeue();
                        child.Add(n, n);
                    }
                    myQueue.Clear();
                    stack.Push(child);

                }

            }

            while (stack.Count != 1)
            {
                string childname = stack2.Pop();
                JObject child = stack.Pop();
                JObject parent = stack.Peek();
                parent.Add(childname, child);
                stack.Pop();
                stack.Push(parent);
            }

            Console.WriteLine(stack.Peek());
            JObject result = stack.Pop();
            Console.WriteLine(result);
            var jsonToOutput = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.ReadKey();
            File.WriteAllText(@"C:\Users\NHI468\Downloads\test1.json", jsonToOutput);
            Console.ReadKey();


        }
    }
}
