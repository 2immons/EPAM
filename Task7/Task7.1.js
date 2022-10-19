//Написать функцию, на вход которой приходит строка, состоящая из нескольких слов. 
//Слова разделены пробельными символами (пробел, табуляция) и знаками препинания (?!:;,.). 
//Нужно вернуть строку, в которой будут удалены все символы, повторяющиеся хоть в одном из слов более одного раза.

let inputStr = "У попа была собака";
let punctuation = [" ", "\t", "?", "!", ":", ";", ",", "."];
let lettersForRemoving = {};
let separatedWords = inputStr.split(' ');

for (let i = 0; i < separatedWords.length; i++) {
    let currentWord = separatedWords[i];
    let currentWordLetters = separatedWords[i].split('');
    for (let k = 0; k < currentWordLetters.length; k++) {
        let currentLetter = currentWordLetters[k];
        if (lettersForRemoving[currentLetter] != 1 && currentWord.indexOf(currentLetter, k + 1) != -1 && punctuation.indexOf(currentLetter) == -1)
            lettersForRemoving[currentLetter] = 1;
    }
}

// "сборка" по буквам, проверяя каждую:
let resultArray = [];
let separatedLetters = inputStr.split('');
for (let i = 0; i < separatedLetters.length; i++) {
    if (!lettersForRemoving[separatedLetters[i]])
        resultArray.push(separatedLetters[i]);
}

let result = resultArray.join('');

console.log(result);