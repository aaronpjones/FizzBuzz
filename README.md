# FizzBuzz
LNDT Software Engineering Test

## Requirements:
* Develop a .NET Web API that accepts a number range, applies a set of rules to each number in the range and returns the result as json
* Code should be SOLID and test driven
* Rules must be configurable without changing code
* Produce a summary showing how many times the following were output
* * fizz
* * buzz
* *	fizzbuzz
* * an integer

## Rules:
•	If no rule matches then output the input number
•	If the input number is a multiple of 3 then output “fizz”
•	If the input number is a multiple of 5 then output “buzz”
•	If the input number is a multiple of 3 and 5 then output “fizzbuzz”

## Input:  
1,20

## Expected Json Result:
```javascript
{
  "result": "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz",
  "summary":
  {
    "fizz": "5",
    "buzz": "3",
    "fizzbuzz": "1",
    "integer": "11"
  }
}
```
