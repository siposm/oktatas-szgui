class Word {
    hun;
    eng;

    constructor(hun, eng) {
        this.hun = hun;
        this.eng = eng;
    }

    toRow() {
        return "<tr>" +
            `<td>${this.hun}</td>` +
            `<td>${this.eng}</td>` +
            "</tr>";
    }
}

let words = [];

let currentRandomWordIndex = 0
let correctCounter = 0
let totalCounter = 0

function create() {
    words.push(new Word(
        document.getElementById('i_hun').value,
        document.getElementById('i_eng').value,
    ));
    document.getElementById('i_hun').value = "";
    document.getElementById('i_eng').value= "";
    display();
}

function startGame() {
    // SHOW
    document.getElementById("gamediv").style.display = "flex";

    // HIDE
    document.getElementById("wordtable").style.display = "none";
    document.getElementById("formdiv").style.display = "none";

    nextWord();
}

function endGame() {
    // SHOW
    document.getElementById("wordtable").style.display = "";
    document.getElementById("formdiv").style.display = "flex";

    // HIDE
    document.getElementById("gamediv").style.display = "none";

    // RESET
    currentRandomWordIndex = 0;
    correctCounter = 0;
    totalCounter = 0;
    document.getElementById("score_label").innerHTML = "";
    document.getElementById("i_eng_game").value = "";
    document.getElementById("btn_next").disabled = false;
}

function gameNextClick() {
    if (words[currentRandomWordIndex].eng === document.getElementById("i_eng_game").value) {
        correctCounter++;
    }
    totalCounter++
    document.getElementById("i_eng_game").value = "";
    if (totalCounter > 9) {
        document.getElementById("btn_next").disabled = true;
    } else {
        nextWord();
    }
    document.getElementById("score_label").innerHTML = correctCounter + "/" + totalCounter;
}

function nextWord() {
    currentRandomWordIndex = Math.floor(Math.random() * (words.length));
    if (currentRandomWordIndex > words.length) {
        currentRandomWordIndex--;
    }
    document.getElementById("hun_game_word").innerHTML = words[currentRandomWordIndex].hun;
}

function display() {
    document.getElementById('tablerows').innerHTML = "";
    words.forEach(t => {
        document.getElementById('tablerows').innerHTML +=
            t.toRow();
    });
}