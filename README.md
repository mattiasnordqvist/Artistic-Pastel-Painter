# Artistic-Pastel-Painter
credits to the excellent https://github.com/silkfire/Pastel

```
var example1 = new ArtisticString("Hello World!", Color.IndianRed);
example1.PaintYourself(Color.GreenYellow, 6, 10);
example1.PaintYourself(Color.White, 1, 1);
example1.PaintYourself(Color.White, 6, 6);
Console.WriteLine(example1);

var example2 = new ArtisticString("Hello World!", Color.IndianRed);
new ArtisticPainter()
    .BeCreativeWith(new ArtisticRegexBrush("World", Color.GreenYellow))
    .BeCreativeWith(new ArtisticRegexBrush("[A-Z]", Color.White))
    .Unleash(example2);

Console.WriteLine(example2);
Console.ReadLine();
```

// more examples on how to do the same thing here...
