# Task
## It is necessary to implement a DTO generator (objects for data transfer) with random test data.

````C#
var faker = new Faker();
Foo foo = faker.Create<Foo>();
Bar bar = faker.Create<Bar>();
````

*When creating an object, you should use the **constructor**, as well as **public fields and properties with public setters**. Consideration should be given to scenarios when a class has only a private constructor, several constructors, a constructor with parameters, and public fields / properties.*

*Filling must be recursive (if the DTO field is another DTO, then it must also be created using `Faker`). The logic of determining what is a DTO is at the discretion of the author.*

*Implement random value generators for basic value types (`int`, `long`, `double`, `float`, etc), strings, one of any system class that can be found in the DTO, a choice of (date / time, url, etc), collections of objects all of these types (support of varieties `IEnumerable <T>`, `List <T>`, `IList <T>`, `ICollection <T>`, `T []` at the discretion of the author, at least one of the above);*

*Select at least 2 base generators in **separate plug-ins** that will be loaded at the start of the application.*

*Consider **cyclic dependencies**:*

````C#
class A
{
    public B { get; set; }
}

class B
{
    public C { get; set; }
}

class C
{
    public A { get; set; }
}
````

*Provide processing for types that are not DTOs and for which there is no generator. Their presence should not lead to exceptions at runtime.*
