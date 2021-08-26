using System;
namespace Quest
{
public class Prize {
private string _text { get; set;}
public Prize(string text)
{
    this._text = text;
}
public ShowPrize(Adventurer adventurer)
{
    if(adventurer.Awesomeness <= 0){
        Console.WriteLine("Sorry, no prize for you...");
    }
    if(adventurer.Awesomeness > 0){
        for(int i = 0; i <= adventurer.Awesomeness; i++){
            Console.WriteLine(this._text);
        }
    }
}



}
}