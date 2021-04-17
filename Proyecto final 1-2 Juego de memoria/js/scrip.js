let movements = 0;
let pairs = 0;
let randomNumbers = [];
let images = [];
let firstTurno = true;
let numberOne = 0;
let numberTwo = 0;
let play = true;
let boxesUp = [];

let moves = [];
let movementsMade = document.querySelector(`.player-two-text`);

init();


document.addEventListener('DOMContentLoaded', (e) => {
    const modal = document.getElementById("modal-result");

    const spanClose = document.querySelector(`.close`);
    spanClose.onclick = function () {
        modal.style.display = "none";
    }

    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
});

function init() {
    turn = 0;
    moves = [];
    movements = 0;
    movementsMade.innerHTML = 0;
    boxesUp = [];
    pairs = 0;
    firstTurno = true;
    numberOne = 0;
    numberTwo = 0;
    

    defRandomNumbers();
    shuffleNumbers();

    const playerOneText = document.querySelector(`.player-one-text`);
    const playerTwoText = document.querySelector(`.player-two-text`);

    document.querySelectorAll('.square').forEach((square) => {
        square.innerHTML = '';
    });//Borra las fichas dentro de los box.

    const resultsContainer = document.querySelector(`.results-container`);
    resultsContainer.innerHTML = ``;//Borra el resultado.


}

function defRandomNumbers() {
    randomNumbers = [];
    while (randomNumbers.length < 16) {
        let temp = Math.floor(Math.random() * 100);
        if (!(randomNumbers.includes(temp))) {
            randomNumbers.push(temp);
            randomNumbers.push(temp);
        }
    }
    console.log(randomNumbers);
}

function shuffleNumbers() {
    for (let i = randomNumbers.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [randomNumbers[i], randomNumbers[j]] = [randomNumbers[j], randomNumbers[i]];
    }
}

function move(number) {
    if (play && number !== numberOne && !boxesUp.includes(number)) {
        play = false;
        if (firstTurno) {
            numberOne = number;
            firstTurno = false;
            const square = document.querySelector(`div[data-key="${number}"]`);
            fetch("https://rickandmortyapi.com/api/character/" + randomNumbers[number - 1]).then(response => response.json()).then(data => {
                square.innerHTML = `<img src="${data.image}" class="square" width="100%">`;
                play = true;
            });
        }
        else {            
            firstPlayer = false;
            numberTwo = number
            firstTurno = true;
            let img = '';
            movements++;
            movementsMade.innerHTML = movements;


            fetch("https://rickandmortyapi.com/api/character/" + randomNumbers[number - 1]).then(response => response.json()).then(data => {
                const square = document.querySelector(`div[data-key="${numberTwo}"]`);
                square.innerHTML = `<img src="${data.image}" class="square" width="100%">`;
                if (randomNumbers[numberOne - 1] === randomNumbers[numberTwo - 1]) {
                    pairs++;
                    boxesUp.push(numberOne);
                    boxesUp.push(numberTwo);
                    checkForWinner();
                    play = true;
                }
                else {
                    setTimeout(() => {
                        const square1 = document.querySelector(`div[data-key="${numberOne}"]`);
                        const square2 = document.querySelector(`div[data-key="${numberTwo}"]`);

                        square1.innerHTML = ``;
                        square2.innerHTML = ``;
                        play = true;
                        numberOne = '';
                    }, 1500);
                };                
            });

        }
    }
    
}

function printImage() {
    const square = document.querySelector(`div[data-key="${number}"]`);

    fetch("https://rickandmortyapi.com/api/character/" + randomNumbers[number - 1]).then(response => response.json()).then(data => {
        //square.innerHTML=`<img src="${data.image}" class="square" width="100%">`;               
        square.innerHTML = `<img src="${data.image}" class="square" width="100%">`;
    })
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function checkForWinner() {
    if(pairs === 8){  
        const modal = document.getElementById("modal-result");
        const winnerResultText = document.querySelector(`#winner-result-text`);
        winnerResultText.innerHTML = `Juego terminado en ${movements} turnos!`;
        modal.style.display = "block"; 
    }
}
