// See https://aka.ms/new-console-template for more information

using System.Text;
using OhMySandwich;
using OhMySandwich.config;
using OhMySandwich.models;
using OhMySandwich.utils;

Console.OutputEncoding = Encoding.UTF8;

var context = new Context();

var adapter = context.GetAdapter();

adapter.AcceptInteractions();