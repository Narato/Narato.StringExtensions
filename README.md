# Narato.StringExtensions
This library contains some string extensions to make your life a little bit easier.

Getting started
==========
*Serialize to Json*
```C#
var obj = new { Name = "test" };
var objAsString = obj.ToJson();
```

*Deserialize from Json*
```C#
var kvp = "{'key': 'test', 'value': 5}".FromJson<KeyValuePair<string, int>>();
```

*Encode Json*
```C#
Console.WriteLine("{\"test\": 5}".EncodeJson());
// outputs "{\"test\": 5}" as opposed to {"test": 5}
```

# Helping out

If you want to help out, please read [this wiki page](https://github.com/Narato/Narato.StringExtensions/wiki/Helping-out)