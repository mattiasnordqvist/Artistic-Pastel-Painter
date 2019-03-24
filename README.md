# Artistic-Pastel-Painter
credits to the excellent https://github.com/silkfire/Pastel

![Examples](https://raw.githubusercontent.com/mattiasnordqvist/Artistic-Pastel-Painter/master/example.png)

```csharp
var bareBones = new ArtisticString("Hello World!", Color.IndianRed);
bareBones.PaintYourself(6, 5, Color.GreenYellow);
bareBones.PaintYourself(0, 1, background: Color.White);
bareBones.PaintYourself(6, 1, (background: Color.White, foreground: Color.OrangeRed));
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

```

// more examples on how to do the same thing here...
