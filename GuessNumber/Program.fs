// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
 
open System
module Output = 
    let enter = "\n\nEnter your guess: "
    let correct = "\nYou guessed correctly!!"
    let replay = "\nPress q to quit or any button to replay\n"
    let reenter = "Please enter a number."

//this function is recursive (rec) and return value is an int
let rec userInput() : int = 
     // Ask the user for input
    Console.Write(Output.enter)
    let mutable parse = -1
    // Read user input
    let input = Console.ReadLine()

    //checks if user enters a number if so then parses string to int,
    //if not recursively recalls this func
    let is_numeric = fst (Int32.TryParse(input))
    if is_numeric then
        parse <- Int32.Parse input
        Console.Write("You entered: {0}\n", parse)
    else 
        Console.Write(Output.reenter)  
        userInput() |> ignore
    
    //returns users input
    parse

let main() =
    let MAX_GUESS = 100
    let mutable gameplay = true
    let randomNumberGenerator = new Random()
    
    // Generate a random number between 1 and maxValue.
    let mutable rand = randomNumberGenerator.Next(MAX_GUESS)
    printfn "Random: %d" rand

    //main game loop
    while gameplay = true do
   
    let input = userInput()
    // Used for pausing the console application
   // Console.ReadLine() |> ignore
    if rand = input then 
        Console.Write(Output.correct)

        Console.Write(Output.replay)
        // Read user input
        let option = Console.ReadLine()

        //changes the value that was in rand
        rand <- randomNumberGenerator.Next(MAX_GUESS)
        printfn "Random: %d" rand

        //checks if q was entered and if so sets gameplay to false
        if option = "q" then
            gameplay <- false

main()