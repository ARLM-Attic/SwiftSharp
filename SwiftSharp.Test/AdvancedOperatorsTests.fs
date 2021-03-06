namespace SwiftSharp.Test
open NUnit.Framework

[<TestFixture>]
type AdvancedOperatorsTests () =
    inherit BookTests ()

    [<Test>]
    member this.AdvancedOperators01() =
        let code = """let initialBits: UInt8 = 0b00001111
let invertedBits = ~initialBits  // equals 11110000 """
        this.Test ("AdvancedOperators01", code)

    [<Test>]
    member this.AdvancedOperators02() =
        let code = """let firstSixBits: UInt8 = 0b11111100
let lastSixBits: UInt8  = 0b00111111
let middleFourBits = firstSixBits & lastSixBits  // equals 00111100 """
        this.Test ("AdvancedOperators02", code)

    [<Test>]
    member this.AdvancedOperators03() =
        let code = """let someBits: UInt8 = 0b10110010
let moreBits: UInt8 = 0b01011110
let combinedbits = someBits | moreBits  // equals 11111110 """
        this.Test ("AdvancedOperators03", code)

    [<Test>]
    member this.AdvancedOperators04() =
        let code = """let firstBits: UInt8 = 0b00010100
let otherBits: UInt8 = 0b00000101
let outputBits = firstBits ^ otherBits  // equals 00010001 """
        this.Test ("AdvancedOperators04", code)

    [<Test>]
    member this.AdvancedOperators05() =
        let code = """let shiftBits: UInt8 = 4   // 00000100 in binary
shiftBits << 1             // 00001000
shiftBits << 2             // 00010000
shiftBits << 5             // 10000000
shiftBits << 6             // 00000000
shiftBits >> 2             // 00000001 """
        this.Test ("AdvancedOperators05", code)

    [<Test>]
    member this.AdvancedOperators06() =
        let code = """let pink: UInt32 = 0xCC6699
let redComponent = (pink & 0xFF0000) >> 16    // redComponent is 0xCC, or 204
let greenComponent = (pink & 0x00FF00) >> 8   // greenComponent is 0x66, or 102
let blueComponent = pink & 0x0000FF           // blueComponent is 0x99, or 153 """
        this.Test ("AdvancedOperators06", code)

    [<Test>]
    member this.AdvancedOperators07() =
        let code = """var potentialOverflow = Int16.max
// potentialOverflow equals 32767, which is the largest value an Int16 can hold
potentialOverflow += 1
// this causes an error """
        this.Test ("AdvancedOperators07", code)

    [<Test>]
    member this.AdvancedOperators08() =
        let code = """var willOverflow = UInt8.max
// willOverflow equals 255, which is the largest value a UInt8 can hold
willOverflow = willOverflow &+ 1
// willOverflow is now equal to 0 """
        this.Test ("AdvancedOperators08", code)

    [<Test>]
    member this.AdvancedOperators09() =
        let code = """var willUnderflow = UInt8.min
// willUnderflow equals 0, which is the smallest value a UInt8 can hold
willUnderflow = willUnderflow &- 1
// willUnderflow is now equal to 255 """
        this.Test ("AdvancedOperators09", code)

    [<Test>]
    member this.AdvancedOperators10() =
        let code = """var signedUnderflow = Int8.min
// signedUnderflow equals -128, which is the smallest value an Int8 can hold
signedUnderflow = signedUnderflow &- 1
// signedUnderflow is now equal to 127 """
        this.Test ("AdvancedOperators10", code)

    [<Test>]
    member this.AdvancedOperators11() =
        let code = """let x = 1
let y = x / 0 """
        this.Test ("AdvancedOperators11", code)

    [<Test>]
    member this.AdvancedOperators12() =
        let code = """let x = 1
let y = x &/ 0
// y is equal to 0 """
        this.Test ("AdvancedOperators12", code)

    [<Test>]
    member this.AdvancedOperators13() =
        let code = """2 + 3 * 4 % 5
// this equals 4 """
        this.Test ("AdvancedOperators13", code)

    [<Test>]
    member this.AdvancedOperators14() =
        let code = """2 + ((3 * 4) % 5) """
        this.Test ("AdvancedOperators14", code)

    [<Test>]
    member this.AdvancedOperators15() =
        let code = """2 + (12 % 5) """
        this.Test ("AdvancedOperators15", code)

    [<Test>]
    member this.AdvancedOperators16() =
        let code = """2 + 2 """
        this.Test ("AdvancedOperators16", code)

    [<Test>]
    member this.AdvancedOperators17() =
        let code = """struct Vector2D {
    var x = 0.0, y = 0.0
}
func + (left: Vector2D, right: Vector2D) -> Vector2D {
    return Vector2D(x: left.x + right.x, y: left.y + right.y)
} """
        this.Test ("AdvancedOperators17", code)

    [<Test>]
    member this.AdvancedOperators18() =
        let code = """let vector = Vector2D(x: 3.0, y: 1.0)
let anotherVector = Vector2D(x: 2.0, y: 4.0)
let combinedVector = vector + anotherVector
// combinedVector is a Vector2D instance with values of (5.0, 5.0) """
        this.Test ("AdvancedOperators18", code)

    [<Test>]
    member this.AdvancedOperators19() =
        let code = """prefix func - (vector: Vector2D) -> Vector2D {
    return Vector2D(x: -vector.x, y: -vector.y)
} """
        this.Test ("AdvancedOperators19", code)

    [<Test>]
    member this.AdvancedOperators20() =
        let code = """let positive = Vector2D(x: 3.0, y: 4.0)
let negative = -positive
// negative is a Vector2D instance with values of (-3.0, -4.0)
let alsoPositive = -negative
// alsoPositive is a Vector2D instance with values of (3.0, 4.0) """
        this.Test ("AdvancedOperators20", code)

    [<Test>]
    member this.AdvancedOperators21() =
        let code = """func += (inout left: Vector2D, right: Vector2D) {
    left = left + right
} """
        this.Test ("AdvancedOperators21", code)

    [<Test>]
    member this.AdvancedOperators22() =
        let code = """var original = Vector2D(x: 1.0, y: 2.0)
let vectorToAdd = Vector2D(x: 3.0, y: 4.0)
original += vectorToAdd
// original now has values of (4.0, 6.0) """
        this.Test ("AdvancedOperators22", code)

    [<Test>]
    member this.AdvancedOperators23() =
        let code = """prefix func ++ (inout vector: Vector2D) -> Vector2D {
    vector += Vector2D(x: 1.0, y: 1.0)
    return vector
} """
        this.Test ("AdvancedOperators23", code)

    [<Test>]
    member this.AdvancedOperators24() =
        let code = """var toIncrement = Vector2D(x: 3.0, y: 4.0)
let afterIncrement = ++toIncrement
// toIncrement now has values of (4.0, 5.0)
// afterIncrement also has values of (4.0, 5.0) """
        this.Test ("AdvancedOperators24", code)

    [<Test>]
    member this.AdvancedOperators25() =
        let code = """func == (left: Vector2D, right: Vector2D) -> Bool {
    return (left.x == right.x) && (left.y == right.y)
}
func != (left: Vector2D, right: Vector2D) -> Bool {
    return !(left == right)
} """
        this.Test ("AdvancedOperators25", code)

    [<Test>]
    member this.AdvancedOperators26() =
        let code = """let twoThree = Vector2D(x: 2.0, y: 3.0)
let anotherTwoThree = Vector2D(x: 2.0, y: 3.0)
if twoThree == anotherTwoThree {
    println("These two vectors are equivalent.")
}
// prints "These two vectors are equivalent." """
        this.Test ("AdvancedOperators26", code)

    [<Test>]
    member this.AdvancedOperators27() =
        let code = """prefix operator +++ {} """
        this.Test ("AdvancedOperators27", code)

    [<Test>]
    member this.AdvancedOperators28() =
        let code = """prefix func +++ (inout vector: Vector2D) -> Vector2D {
    vector += vector
    return vector
} """
        this.Test ("AdvancedOperators28", code)

    [<Test>]
    member this.AdvancedOperators29() =
        let code = """var toBeDoubled = Vector2D(x: 1.0, y: 4.0)
let afterDoubling = +++toBeDoubled
// toBeDoubled now has values of (2.0, 8.0)
// afterDoubling also has values of (2.0, 8.0) """
        this.Test ("AdvancedOperators29", code)

    [<Test>]
    member this.AdvancedOperators30() =
        let code = """infix operator +- { associativity left precedence 140 }
func +- (left: Vector2D, right: Vector2D) -> Vector2D {
    return Vector2D(x: left.x + right.x, y: left.y - right.y)
}
let firstVector = Vector2D(x: 1.0, y: 2.0)
let secondVector = Vector2D(x: 3.0, y: 4.0)
let plusMinusVector = firstVector +- secondVector
// plusMinusVector is a Vector2D instance with values of (4.0, -2.0) """
        this.Test ("AdvancedOperators30", code)

