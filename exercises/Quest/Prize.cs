using System;
namespace Quest
{
public class Prize {
private string _text { get; set;}
public Prize(string text)
{
    _text = text;
}
public void ShowPrize(Adventurer adventurer)
{
    if(adventurer.Awesomeness <= 0){
        Console.WriteLine("Sorry, no prize for you...");
    }
    if(adventurer.Awesomeness > 0){
        Console.WriteLine("You get...");
        for(int i = 0; i <= adventurer.Awesomeness; i++){
            Console.Write($" {this._text}");
        }
    }
}

}
}