module TypingPractice.DataModels
open Utils.Collections
open Utils.Funtor
open System;

module internal table =
    let EnglishKeyboard : obj array array=
        [|
            [|('~','`'); ('!', '1');('@','2');('#','3');('$','4'); ('%', '5');('^','6');('&','7'); ('*','8');('(','9');(')','0');('-','_');('+','=');"Backspace"|];
            [|"Tab";'Q';'W';'E';'R';'T';'Y';'U';'I';'O';'P';('{','[');('}',']');('|','\\')|];
            [|"Caps Lock";'A';'S';'D';'F';'G';'H';'J';'K';'L';(':',';');('\'','\'');"Enter"|];
            [|"Shift";'Z';'X';'C';'V';'B';'N';'M';('<',',');('>','.');('?','/');"Shift"|];
        |]
    let itemSpan = [|3;3;4;5|]
    let (XiaoheKeyboard : (char * obj) array )= 
        [|
            ('q',"iu");
            ('w',"ei");
            ('e',"e");
            ('r',"uan");
            ('t',["ue";"ve"]);
            ('y',"un");
            ('u',"u");
            ('i',"i");
            ('o',["uo";"o"]);
            ('p',"ie");
            ('a',"a");
            ('s',["iong";"ong"]);
            ('d',"ai");
            ('f',"en");
            ('g',"eng");
            ('h',"ang");
            ('j',"an");
            ('k',["ing";"uai"]);
            ('l',["iang";"uang"]);
            ('z',"ou");
            ('x',["ia";"ua"]);
            ('c',"ao");
            ('v',["v";"ui"]);
            ('b',"in");
            ('n',"iao");
            ('m',"ian");      
        |]
module internal impl =
    open table
    
    let gridItemSpan (x:obj) span = if x :? string then span else 2
    
    let gridColumnSpans = 
        [| for pairs in Seq.zip EnglishKeyboard itemSpan do
                let items,span = pairs
                [|for item in items do yield gridItemSpan item span|] 
        |]
    let gridColumnIndexes = gridColumnSpans |> Seq.map (Seq.scan (+) 0)

    let gridRowIndexs = 
        Seq.zip (EnglishKeyboard |> Seq.map Seq.length) [|0..EnglishKeyboard |> Seq.length|]  
        |> Seq.map (fun (c,i) -> Seq.replicate c (2*i))
    let zip4_2D  a b c d = zip4 a b c d |> Seq.map (fun (a,b,c,d) -> zip4 a b c d)


    let keyboardModel = zip4_2D   EnglishKeyboard gridRowIndexs gridColumnIndexes gridColumnSpans


    let keys = EnglishKeyboard |> Seq.concat
    let keyboardMap =
        Seq.zip keys [0.. Seq.length keys]
        |> Seq.filter (fst >> (fun (x:obj) -> x :? char)) 
        |> Seq.map (fun (a,b) -> (a :?> char,b)) 
        |> Map

    let toSeq cons (x:obj) =
        match x with
        | :? list<string> as sl -> cons sl
        | :? string as s -> cons [s]
        | _ -> failwith "error type"

    let xiaoheKeyboardModel = 
        XiaoheKeyboard |> Seq.map (fun (a,b) -> (a,toSeq set b))

    let xiaoheKeyboardPromptTable =
        let trans (a,b) =
            let seqA = toSeq seq b
            let seqB = Seq.replicate (Seq.length seqA)  (Char.ToUpper a)
            Seq.zip seqA seqB
        XiaoheKeyboard
        |> Seq.map trans
        |> Seq.concat

let KeyboardModel = impl.keyboardModel |> Seq.immutableArray2D
let KeyboardMap = impl.keyboardMap

module XiaoheKeyboard =
    open impl
    let Model = xiaoheKeyboardModel |> Map
    let PromptTable = xiaoheKeyboardPromptTable |> Seq.immutableArray;