# sample note


**without Newtonsoft.Json dll**  
https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data  


```csharp
            using System;
            using System.IO;
            using System.Runtime.Serialization.Json;
            using System.Text;

            namespace ConsoleApp1
            {
                class Program
                {
                    static void Main(string[] args)
                    {

                        byte[] array = {1,2,3 };
                        var stream = new MemoryStream();
                        var Serializer = new DataContractJsonSerializer(typeof(byte[]));
                        Serializer.WriteObject(stream, array);
                        stream.Position = 0;
                        StreamReader sr = new StreamReader(stream);
                        var ss = sr.ReadToEnd();
                        Console.WriteLine(ss);

                        byte[] byteArray = Encoding.UTF8.GetBytes(ss);
                        //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                        MemoryStream stream1 = new MemoryStream(byteArray);
                        stream1.Position = 0;
                        var p2 = (byte[])Serializer.ReadObject(stream1);

                    }
                }
            }
```
