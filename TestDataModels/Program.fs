open TypingPractice.DataModels
open Utils.Collections
open Utils.Funtor

let printArr2D xs = 
    for items in xs do
        for item in items do
            printf "%A " item
        printf "\n"

let printArr xs = 
    for x in xs do
        printfn "%A " x
    printfn "\n"


printArr XiaoheKeyboard.Model
printArr XiaoheKeyboard.PromptTable

