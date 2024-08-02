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
namespace ArraySeperationDefToJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> temporary_list = new List<string>();
            string[] array1 = new string[10];
            JObject Attribute_parent = new JObject();
            JObject main_parent = new JObject(); 
            JObject main_entity_parent = new JObject();
            JObject object1 = new JObject();
            JObject object2 = new JObject();
            JObject object4 = new JObject();
            JObject object3 = new JObject();
            JObject object7 = new JObject(); 
            foreach (string line in File.ReadLines(@"C:\Users\NHI468\Downloads\RegistrationDetails.txt"))
            {
                string line2 = line.Replace("-", "");
                string last = line2.Split(',').Last();
                string start = line2.Split(',').First(); 
                int HyphenCount = 0;
                // Console.WriteLine(line);
                foreach (Match m in Regex.Matches(line, "-"))
                {
                    HyphenCount++;
                }
                Console.WriteLine(HyphenCount); 
                if (start == "Attribute" & HyphenCount == 1)
                {
                    string[] values = line.TrimStart().Split(',');
                    string name = values[1];
                    //attributelevel1.Add(name);
                    array1[HyphenCount] = name;
                    Attribute_parent.Add(name, name);
                    //Console.WriteLine(name);
                }
                if (start == "Attribute" & HyphenCount > 1 & last == "Group")
                {
                    string[] values = line.TrimStart().Split(','); 
                    string name = values[1];
                    array1[HyphenCount] = name;
                    //object1.Add(name,name);
                    //JObject object2 = j1(); 
                    if (HyphenCount == 1)
                    {
                        object2.Add(name, name); 
                        Attribute_parent[array1[HyphenCount]] = object2;
                    }
                    if (HyphenCount == 2)
                    {
                        object3.Add(name, name);
                        Attribute_parent[array1[HyphenCount - 1]] = object2;
                        object2[array1[HyphenCount - 1]] = object3;
                    }
                    if (HyphenCount == 3)
                    {
                        object7.Add(name, name); 
                        object2[array1[HyphenCount - 1]] = object7;

                    }
                }
                if (start == "Attribute" & HyphenCount > 1 & last != "Group")
                {
                    // JObject  object2 = new JObject();
                    string[] values = line.TrimStart().Split(',');
                    string name = values[1];
                    object1.Add(name, name);
                    if (HyphenCount == 2)
                    {
                        Attribute_parent[array1[HyphenCount - 1]] = object1;
                    }
                    if (HyphenCount == 3)
                    {
                        Console.WriteLine(array1[HyphenCount - 1][HyphenCount - 2]); 
                        object4.Add(name, name);
                        //  Console.WriteLine(array1[HyphenCount - 1][HyphenCount - 2]);                        
                                                                                                                         
                        Attribute_parent[array1[HyphenCount - 2]][array1[HyphenCount - 1]] = object4;
                        
                                                                                                                                      
                    }
                }                
                foreach (var e in array1)
                {
                    Console.WriteLine(e);
                }
                if (last == "EndGroup")
                {
                    object1 = new JObject();
                    object4 = new JObject();
                            // object3= new JObject();
                    object2 = new JObject();
                }
                if (last == "EndGroup" & HyphenCount == 1)
                {
                    object3 = new JObject();
                }
                        //if(HyphenCount > 0 )
                        // {
                        //     temporary_list.Add(line); 
                        // }                 //if (last == "EndGroup" & HyphenCount == 1)
                        //{
                        //    j1(temporary_list);
                        //    Console.ReadKey();
                        //}            
                        }
            Console.WriteLine("File reading finished");
            main_parent["Attributes"] = Attribute_parent; 
            main_entity_parent["Entities"] = main_parent;
            var jsonToOutput = JsonConvert.SerializeObject(main_entity_parent, Newtonsoft.Json.Formatting.Indented);
            Console.ReadKey(); 
            File.WriteAllText(@"C:\Users\NHI468\Downloads\RegistrationDetails.json", jsonToOutput); Console.ReadKey();
        }
        public static JObject j1()
        {
            JObject object2 = new JObject(); return object2;
        }
    }
}