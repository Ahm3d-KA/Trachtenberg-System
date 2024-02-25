// // Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// // for details on configuring this project to bundle and minify static web assets.
//
// // Write your JavaScript code.
//
// // a function that generates a random integer between maximumValue and minimumValue inclusive
//
// const consolePrompt = require('prompt-sync')();
// function getRandomInteger(minimumValue, maximumValue) {
//     return Math.floor(Math.random() * (maximumValue - minimumValue + 1) ) + minimumValue;
// }
//
// // make sure to add a javascript comment to explain what the class does in proper formatting and look into unit testing
// // need to allow customisation of the test 
// class Test {
//     constructor(testLength, difficulty, operation) {
//         this.testLength = testLength; // stores number of questions
//         this.difficulty = difficulty; // stores difficulty enum
//         this.operation = operation; // tells you which operation is used in the questions
//         this.testScore = 0; // stores the score of the test when user completes it
//         this.operands = []; // stores all the operands that will appear in the test
//         this.secondaryOperands = []; // stores all the secondary operands if the calculation needs it 
//         // e.g. multiplication, division, addition, subtraction
//         this.answers = []; // stores all the answers to the questions
//     }
//    
//     generateTest() {
//         switch(this.operation) {
//             // different operations require different methods
//             // switch statement easier to read then if else
//             case "addition":
//                 this.generateAdditionTest();
//                 break;
//             case "subtraction":
//                 this.generateSubtractionTest();
//                 break;
//             case "multiplication":
//                 this.generateMultiplicationTest();
//                 break;
//             case "division":
//                 this.generateDivisionTest();
//                 break;
//             case "squaring":
//                 this.generateSquaringTest();
//                 break;
//             case "squareRoot":
//                 this.generateSquareRootTest();
//                 break;
//             // no other cases match? this is outputted to the console
//             default:
//                 console.log("Invalid operation");
//         }
//        
//     }
//     runMultiplicationTest() {
//         let userAnswer = 0;
//         // loops through the number of questions specified by testLength and prints out the questions
//         for (let i = 0; i < this.testLength; i++) {
//             // prints out question
//             console.log(this.operands[i] + " x " + this.secondaryOperands[i] + ":");
//             // user inputs their answer
//             userAnswer = consolePrompt("");
//             // checks if answer is correct
//             if (Number(userAnswer) === Number(this.answers[i])) {
//                 console.log("Correct!");
//                 this.testScore++;
//             }
//             else {
//                 console.log("Incorrect, answer is " + this.answers[i]);
//
//             }
//         }
//         console.log("Test complete! Your score is: " + this.testScore + "/" + this.testLength);
//     }
//
//     generateMultiplicationTest() {
//         switch(this.difficulty) {
//             // operands are generated differently based on the difficulty
//             case "easy":
//                 // creates the number of questions specified by testLength
//                 for (let i = 0; i < this.testLength; i++) {
//                     // generates a random operand between 2 and 12 inclusive for all the questions and appends it to operands list
//                     this.operands.push(getRandomInteger(2, 12));
//                     // generates a random operand between 2 and 99 inclusive for all the questions and appends it to secondaryOperands list
//                     this.secondaryOperands.push(getRandomInteger(2, 99));
//                     // calculates the answer from the operands and appends it to the answers list
//                     this.answers.push(this.operands[i] * this.secondaryOperands[i]);
//                 }
//                 this.runMultiplicationTest();
//                 break;
//             case "medium":
//                 break;
//             case "hard":
//                 break;
//             case "expert":
//                 break;
//         }
//     }
//
//     generateAdditionTest() {
//        
//     }
//
//     generateSquareRootTest() {
//        
//     }
//
//     generateSquaringTest() {
//        
//     }
//
//     generateSubtractionTest() {
//        
//     }
//
//     generateDivisionTest() {
//        
//     }
//    
// }
//
//
//
// let firstTest = new Test(5, "easy", "multiplication");
// firstTest.generateTest();
// objPractise