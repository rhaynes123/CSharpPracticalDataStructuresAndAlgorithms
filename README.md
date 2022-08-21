# CSharpPracticalDataStructuresAndAlgorithms
The repo contains practical examples of use cases for C# data structures and algorithms 

# Why?
So you might be thinking to yourself if you are reading this "Why would someone make a github repo about data structures and algorithims when there are just so many?". That would be an excellent question. The reason I began this repo was because after years of being a C# developer I've found that the internet is very lacking(at least at the time I wrote this anyway) with examples of data structures and algorithims that I as a developer can apply in the real world. Also after years of programming I also would rarely see code in C# that even matched with any of the examples I remembered or found in books especially in regards to C#. After some time I came up with 4 major factors for why that is. 
### 1. They've Become Built In
Long gone are the days where a developer may need to roll their own sort Algorithim or Binary Search and not because those algorithims have no value in the real world because they absoluetly still do but at this point in programming many of those algorithims have just become a part of the languages we use. For example in C# the Array class has a built in BinarySearch function meaning needs to write my own , while maybe fun are honestly wasteful. [Array Binary Search](https://docs.microsoft.com/en-us/dotnet/api/system.array.binarysearch?view=net-6.0). 
### 2. Database Querying
Database querying by default is critical to how a developer gathers data for their application the best written algorithims in the world probably just can't compare in terms of the best written queries and thats simply due to tooling. A database engine is a tool built for the purpose of storing and retrieving data so it will be ideal. Programming applications should rarely be put into situations where they need to loop over millions of records because well most applications really just don't need to. Some do but they are few an far between.
### 3. LINQ!
As a C# developer not taking advantage of the power provided by Linq to do complex algorithm based work is very well silly honestly. Linq is a library of APIs that make writing C# code extremely easy to do an are often times no worse on perfomance than none linq base equivalent code.
Ex. Lets say we have some database that has a list of names and we want to make a class out of those names with an guid based id so we write a C# function to do that work
```C#
public class MortgageCompany
{
  public Guid Id {get;set;} = Guid.NewGuid();
  public string Name {get;set;}
}
``` 
Without Linq a C# developer may need to write some code that may look like this.
```C#
private static IEnumerable<MortgageCompany> GetCompanies(IEnumerable<string> names)
  {
    var companies = new List<MortgageCompany>();
    foreach(var name in names)
    {
      companies.Add(new MortgageCompany
      {
        Name = name,
      });
    }
    return companies;
   
  }
```
Thanks to Linq a developer can instead write code like this and get he same results.
```C#
  private static IEnumerable<MortgageCompany> GetCompanies(IEnumerable<string> names)
  {
    return names.Select( name => new MortgageCompany{ Name = name});
  }
```
### 4. System.Generics.Collection

While out the box C# does provide many of the classic data structures like Arrays, and Stacks they are just completely outclassed by their descendants in the System.Collections.Generic library. Now I use the word descendants for a reason because many of those data structures where purposefully created to cover many of the weaknesses of the basic data structures before them and usually have all of their strengths. 

# Back To the Point
 Ok now that I got that part of the project out the way and kept the attention of some of you I'll explain what this project is. This project is a collection of smaller project of different types that use different C# data structures and algorithims in situations much closer to real world use cases. Unlike a lot of other examples each project is meant to be small but can for the most part act as a full system and not just a few functions or classes. The reason for that is because I myself do not believe that most programming concepts do not make sense when they are view independtly and only add value when combined with something else. That does mean sadly that many of these projects are indeed whole systems and will indeed contain different concepts than those in simple DSA examples. Each specific example will be identified and labeled with comments and pictures and as a writer I intend to explain things to the best of my ability and more importantly link and references relevant other learning material to try and prevent any developer from being lost and or confused.

 To attempt to try and make each project as easy to follow I've seperated the projects into two main groups Data Structures and Algorithims. This does not mean that you will not find projects that do no use both in fact that defeats much of the reason this project exists however there are situations where a particular data structure is best for a problem regardless of the algorithim and there are times where an algorithim is best for a use case regardless of the data structure. Again I intend to do my best to point all of that out as we go on this journey.
 # Data Structures
 ## Array
 So we are going to start off with the most common and basic data structure in programming the Array. **Note** this is not the most common in the C# realm as that honor goes to List for reasons I'll get into in the list section but this is still the best place to start.
[Code Example](src/DataStructures/Array)
 ## Dictionary
 ## IEnumerable
 ## Lists
 Because of the power, flexibility and popularity of Lists in C# I've broken this section out into a number of sub-sections to go over some of what I believe to be very good use cases for different types of Lists. In C# please note that none of these derivatives of list are exclusive to list alone.
 * List [Code Example](src/DataStructures/Lists/List/SecretaryOfStateQue)
 * ReadOnly [Code Example](src/DataStructures/Lists/ReadOnly/CourseRegistration)
 

 # Algorithims