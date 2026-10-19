using TicTacToe.GamePlay;
using TicTacToe.GamePlay.Players;

var player1 = new ConsolePlayer();
var player2 = new ConsolePlayer();

// var player1 = new NächstesFreiesFeldPlayer();
// var player2 = new RandomPlayer();

var game = new Game(player1, player2);
game.Start();