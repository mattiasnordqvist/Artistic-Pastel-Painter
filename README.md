# Artistic-Pastel-Painter
credits to the excellent https://github.com/silkfire/Pastel

![Examples](https://raw.githubusercontent.com/mattiasnordqvist/Artistic-Pastel-Painter/master/example.png)

```csharp
    var bareBones = new ArtisticString("Hello World!", Color.IndianRed);
    bareBones.PaintYourself(Color.GreenYellow, 6, 10);
    bareBones.PaintYourself(Color.White, 0, 0);
    bareBones.PaintYourself(Color.White, 6, 6);
    Console.WriteLine(bareBones);

    var withArtisticBrushes = new ArtisticString("Hello World!", Color.IndianRed);
    withArtisticBrushes.PaintYourself(new ArtisticRegexBrush("World", Color.GreenYellow));
    withArtisticBrushes.PaintYourself(new ArtisticRegexBrush("[A-Z]", Color.White));
    Console.WriteLine(withArtisticBrushes);

    var withReusablePainter = new ArtisticPainter()
        .BeCreativeWith(new ArtisticRegexBrush("World", Color.GreenYellow))
        .BeCreativeWith(new ArtisticRegexBrush("[A-Z]", Color.White));

    Console.WriteLine(withReusablePainter.Unleash(new ArtisticString("Hello World!", Color.IndianRed)));

    Console.WriteLine(withReusablePainter.Unleash("Hello World as default white string!"));

    Console.WriteLine(new ArtisticPainter()
        .BeCreativeWith(new ArtisticRegexBrush("World", Color.GreenYellow))
        .BeCreativeWith(new ArtisticRegexBrush("[A-Z]", Color.White))
        .Unleash(new ArtisticString("Hello World using implicit casts and return string of Unleash!", Color.IndianRed)));

    Console.ReadLine();
```

// more examples on how to do the same thing here...
