namespace Utils
open System.Collections.Generic
open System.Collections.Immutable


module Collections =
    let immutableArray xs = ImmutableArray.CreateRange(xs)
    let immutableArray2D xs = xs |> Array.map immutableArray |> immutableArray
    let immutableArray3D xs = xs |> Array.map immutableArray2D |> immutableArray
    let map4 f a b c d= 
        Seq.zip (Seq.zip a b) (Seq.zip c d)
        |> Seq.map (fun ((a,b),(c,d)) -> f a b c d)
    let zip4 a b c d= 
        Seq.zip (Seq.zip a b) (Seq.zip c d)
        |> Seq.map (fun ((a,b),(c,d)) -> (a,b,c,d))

    let zip4With cons a b c d= 
        Seq.zip (Seq.zip a b) (Seq.zip c d)
        |> Seq.map (fun ((a,b),(c,d)) -> cons a b c d)

    module Seq =
        let immutableArray (xs:seq<'T>) = xs |> immutableArray
        let immutableArray2D (xs:seq<seq<'T>>) = xs |> Seq.map immutableArray |> immutableArray
        let immutableArray3D (xs:seq<seq<seq<'T>>>) = xs |> Seq.map immutableArray2D |> immutableArray
    
    let range frist last = [frist..last]
module Funtor =
    let apply f (a,b) = f a b
    let flip f a b = f b a
    

