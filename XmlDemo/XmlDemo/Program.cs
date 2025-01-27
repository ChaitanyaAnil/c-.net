﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace XmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // XmlFileAcces();
            // CreateusingNode();

            // CreateXml();
            //CreatexmlDisplyData();
            // CreateXmlUsinLinq();
            ReflectionAssembly();

            Console.ReadKey();

        }

        private static void ReflectionAssembly()
        {
            Assembly inf = typeof(int).Assembly;
            Console.WriteLine(inf);
            int x = 10;
            Type t = x.GetType();
            Console.WriteLine(t);
            Console.WriteLine(x.GetHashCode());
            Console.WriteLine(t.GetHashCode());
            StringBuilder sb = new StringBuilder("Hello");
            Console.WriteLine(sb.GetType());
            inf = typeof(String).Assembly;
            Console.WriteLine(inf);
        }

        private static void CreateXmlUsinLinq()
        {
            XDocument doc = new XDocument(new XElement("Items",
                new XElement("Item",
                new XElement("ItemName", "cake"),
                new XElement("price", "250")),
                new XElement("Item",
                new XElement("ItemName", "cake"),
                new XElement("price", "250"))));


            doc.Save(Directory.GetCurrentDirectory() + "\\Items.xml");
            Console.WriteLine(doc);
        }

        private static void CreatexmlDisplyData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\c#.net\XmlDemo\XmlDemo\bin\Debug\Product.xml");
            XmlNodeList ProductNodes = doc.SelectNodes("//Products/product");
            foreach (XmlNode productNode in ProductNodes)
            {
                //int id = int.Parse(productNode.Attributes["id"].Value);
                // productNode.Attributes["id"].Value = (id).ToString();
                //  Console.WriteLine(id);

                Console.WriteLine(productNode.OuterXml);
            }
        }

        private static void CreateXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Products");
            xmlDoc.AppendChild(rootNode);

            XmlNode ProductNode = xmlDoc.CreateElement("product");
            XmlAttribute attribute = xmlDoc.CreateAttribute("id");
            attribute.Value = "1234";
            ProductNode.Attributes.Append(attribute);
            ProductNode.InnerText = "mobile";
            rootNode.AppendChild(ProductNode);

            ProductNode = xmlDoc.CreateElement("product");
            attribute = xmlDoc.CreateAttribute("id");
            attribute.Value = "12345";
            ProductNode.Attributes.Append(attribute);
            ProductNode.InnerText = "laptop";
            rootNode.AppendChild(ProductNode);

            xmlDoc.Save("Product.xml");
        }

        private static void CreateusingNode()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\c#.net\XmlDemo\XmlDemo\XMLFile1.xml");
            XmlNode CurrentNode = doc.DocumentElement.FirstChild;
            Console.WriteLine(CurrentNode.OuterXml);
            XmlNode NexttNode = doc.DocumentElement.FirstChild;
            Console.WriteLine(NexttNode.NextSibling);
            XmlNode ThirdNode = doc.DocumentElement.FirstChild;
            Console.WriteLine(ThirdNode.NextSibling);
        }

        private static void XmlFileAcces()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream(@"D:\c#.net\XmlDemo\XmlDemo\XMLFile1.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("book");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                Console.WriteLine(str);
                Console.ReadKey();
            }
        }
    }
}
