const sleep = (delay) => new Promise((resolve) => setTimeout(resolve, delay));
let dado = document.querySelector('.dice');
let acumuladoImpreso = document.getElementById('acumulado')
let acumulado = 0;
let scorePlayer1 = document.getElementById('totalPlayer1')
let scorePlayer2 = document.getElementById('totalPlayer2')
let player1Turn = true;
let totalPlayer1 = 0;
let totalPlayer2 = 0;
let player1Class = document.getElementById("player1");
let player2Class = document.getElementById("player2");
let canPlay = true;
let winner = '';


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
    winner = '';
    canPlay = true;
    player1Turn = true;
    totalPlayer1 = 0;
    totalPlayer2 = 0;
    acumulado = 0;
    scorePlayer1.innerHTML = 0;
    scorePlayer2.innerHTML = 0;
    acumuladoImpreso.innerHTML = 0;
    dado.innerHTML = `<img src="./img/dice6.png" alt=""> <img src="./img/dice6.png" alt=""> `;
    player1Class.classList.add('playerOn');
    player2Class.classList.remove('playerOn');
}

async function rollDice() {
    if (canPlay && winner === '') {
        canPlay = false;
        for (let index = 0; index < 10; index++) {
            let random1 = Math.floor((Math.random() * 6) + 1);
            let random2 = Math.floor((Math.random() * 6) + 1);
            await sleep(100);
            dado.innerHTML = `<img src="./img/dice${random1}.png" alt=""><img src="./img/dice${random2}.png" alt="">`;
        }
        let value = diceValue();
        if (value !== 0) {
            acumulado += value;
            acumuladoImpreso.innerHTML = acumulado;
            console.log(value);
        }
        else {
            acumulado = 0;
            acumuladoImpreso.innerHTML = acumulado;
        }
    }
    canPlay = true;
}

function diceValue() {
    let value1 = Math.floor((Math.random() * 6) + 1);
    let value2 = Math.floor((Math.random() * 6) + 1);
    dado.innerHTML = `<img src="./img/dice${value1}.png" alt=""> <img src="./img/dice${value2}.png" alt="">`;
    if (value1 === value2) {
        changeTurn();
        return 0;
    }
    return value1 + value2;
}

function guardar() {
    debugger;
    if (canPlay && winner === '') {
        if (player1Turn) {
            totalPlayer1 += acumulado;
            scorePlayer1.innerHTML = totalPlayer1;
            checkForWinner();

            changeTurn();
        }
        else {

            totalPlayer2 += acumulado;
            scorePlayer2.innerHTML = totalPlayer2;
            checkForWinner();

            changeTurn();
        }
    }
}

function checkForWinner() {
    if (totalPlayer1 >= 100) {
        const modal = document.getElementById("modal-result");
        const winnerResultText = document.querySelector(`#winner-result-text`);
        winnerResultText.innerHTML = `Jugador 1 Ganador!!!`;
        modal.style.display = "block";
        winner = "Jugador1";
    }
    else if (totalPlayer1 >= 100) {
        const modal = document.getElementById("modal-result");
        const winnerResultText = document.querySelector(`#winner-result-text`);
        winnerResultText.innerHTML = `Jugador 2 Ganador!!!`;
        modal.style.display = "block";
        winner = "Jugador2";
    }
}

function changeTurn() {
    acumuladoImpreso.innerHTML = 0;
    acumulado = 0;
    player1Turn = !player1Turn;
    if (player1Turn === true) {
        player1Class.classList.add('playerOn');
        player2Class.classList.remove('playerOn');
    }
    else {
        player2Class.classList.add('playerOn');
        player1Class.classList.remove('playerOn');
    }
}

