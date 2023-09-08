let numberToGuess = Math.floor(Math.random() * 20) + 1;
let attempts = 3;
let score = 3;
let highScore = 0;
let currentRound = 1;

const attemptsShow = document.getElementById("attempts");
const currentRoundShow = document.getElementById("currentRound");
const nextRoundButton = document.getElementById("nextRound");
const scoreShow = document.getElementById("score");
const highScoreShow = document.getElementById("highScore");
const guessInput = document.getElementById("guess");
const guessButton = document.getElementById("check");
const message = document.getElementById("message");
const resetButton = document.getElementById("reset");
const highScoreList = document.getElementById("highScoreList");
const gessedNumberShow = document.getElementById("gessedNumber");

attemptsShow.textContent = attempts;
scoreShow.textContent = score;
highScoreShow.textContent = highScore;
currentRoundShow.textContent = currentRound;
function guess() {
  const userGuess = Number(guessInput.value);
  if (userGuess > 20){
    message.textContent = "El numero debe ser menor o igual a 20";
    return;
  }
  if (userGuess === numberToGuess) {
    if (attempts === 3) {
      score += 3;
    } else if (attempts === 2) {
      score += 2;
    } else if (attempts === 1) {
      score += 1;
    }
    message.textContent = "Adivinaste!";
    gessedNumberShow.textContent = `El numero correcto es: ${numberToGuess}`;
    scoreShow.textContent = score;
    guessButton.disabled = true;
    if (score > highScore) {
      highScore = score;
      highScoreShow.textContent = highScore;
    }
  } else if (numberToGuess - userGuess < 5 && numberToGuess >= userGuess) {
    message.textContent = "Muy cerca!";
    attempts--;
    score--;
    attemptsShow.textContent = attempts;
  } else if (userGuess > numberToGuess) {
    message.textContent = "Muy alto!";
    attempts--;
    score--;
    attemptsShow.textContent = attempts;
  } else {
    message.textContent = "Muy bajo!";
    attempts--;
    score--;
    attemptsShow.textContent = attempts;
  }
  if (attempts === 0) {
    message.textContent = "Perdiste!";
    guessButton.disabled = true;
    nextRoundButton.disabled = true;
  }
}

function nextRound() {
  attempts = 3;
  attemptsShow.textContent = attempts;
  guessButton.disabled = false;
  message.textContent = "";
  gessedNumberShow.textContent = `¿Puedes adivinarlo?`;
  numberToGuess = Math.floor(Math.random() * 20) + 1;
  currentRound++;

  currentRoundShow.textContent = currentRound;
}

function resetGame() {
  attempts = 3;
  attemptsShow.textContent = attempts;
  score = 3;
  scoreShow.textContent = score;
  guessButton.disabled = false;
  nextRoundButton.disabled = false;
  gessedNumberShow.textContent = `¿Puedes adivinarlo?`;
  message.textContent = "";
  numberToGuess = Math.floor(Math.random() * 20) + 1;

  currentRound = 1;
  currentRoundShow.textContent = currentRound;
}
guessButton.addEventListener("click", guess);
resetButton.addEventListener("click", resetGame);
nextRoundButton.addEventListener("click", nextRound);
