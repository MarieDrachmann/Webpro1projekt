// Some standard variables
let block_size = 18;
let rows = 20;
let columns = 20;
let board;
let context; // Canvas drawing
let factor = Math.random * 5;

//Snake size
let snake_x = block_size * factor;
let snake_y = block_size * factor;

// Direction of Snake
let speed_x = 1;
let speed_y = 0;

let snek_body = [];

// Food location variables. Values in function
let food_x;
let food_y;

let game_over = false;



// JavaScript equivalent of Unitys Start() method apparently.
window.onload = function () {
    // Board setup
    board = document.getElementById("board");
    board.height = rows * block_size;
    board.width = columns * block_size;
    context = board.getContext("2d");

    place_food();
    // Check if a button has been pressed.
    document.addEventListener("keyup", change_direction); //Movement checks
    // Framerate
    setInterval(update, 100);
}

function update() {
    if (game_over) {
        document.getElementById("board").innerHTML = "<h1>Game Over</h1> <h2>You will never have privacy. We will share all your info</h2>"
        return;
    }

    // Game background
    context.fillStyle = "pink";
    context.fillRect(0, 0, board.width, board.height);

    // Food sprite
    context.fillStyle = "blue";
    context.fillRect(food_x, food_y, block_size, block_size);

    // Eat the food
    if (snake_x == food_x && snake_y == food_y) {
        snek_body.push([food_x, food_y]); // Make one food longer
        place_food(); // Next food
    }

    // Don't make body a bunch of foods
    for (let snek_block = snek_body.length - 1; snek_block > 0; snek_block--) {
        // Make sure we're following the head basically
        snek_body[snek_block] = snek_body[snek_block - 1];
    }
    // Is snek only one block?
    if (snek_body.length) {
        snek_body[0] = [snake_x, snake_y]; // Add headblock
    }

    context.fillStyle = "green" // Snake colour
    // Snake positions
    snake_x += speed_x * block_size; 
    snake_y += speed_y * block_size;
    context.fillRect(snake_x, snake_y, block_size, block_size);
    //Fill the entire Snake
    for (let snek_block = 0; snek_block < snek_body.length; snek_block++) {
        // 0 is x coordinates, 1 is y coordinates
        context.fillRect(snek_body[snek_block][0], snek_body[snek_block][1], block_size, block_size);
    }

    // Hit wall
    if (snake_x < 0
        || snake_x > columns * block_size
        || snake_y < 0
        || snake_y > rows * block_size) {
        
        game_over = true;
        Stopper();
        document.getElementById("board").innerHTML = "<h1>Game Over</h1> <h2>You will never have privacy. We will share all your info</h2>"
    }
}

//Movement system
function change_direction(event) {
    if ((event.code == "ArrowUp" || event.code == "W") && speed_y != 1) {
        // Make sure you're in the right direction
        speed_x = 0;
        speed_y = -1;
    } else if ((event.code == "ArrowDown" || event.code == "S") && speed_y != -1) {
        speed_x = 0;
        speed_y = 1;
    } else if ((event.code == "ArrowLeft" || event.code == "A") && speed_x != 1) {
        speed_x = -1;
        speed_y = 0;
    } else if ((event.code == "ArrowRight" || event.code == "D") && speed_x != -1) {
        speed_x = 1;
        speed_y = 0;
    }
}

function place_food() {
    // Food coordinates
    food_x = Math.floor(Math.random() * rows) * block_size;
    food_y = Math.floor(Math.random() * columns) * block_size;
}

function Stopper() {
    speed_x = 0;
    speed_y = 0;
}