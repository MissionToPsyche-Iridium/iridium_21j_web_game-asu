// Bird properties
let birds = [];
const birdCount = 3; // Number of birds
const birdSpeed = 2; // Speed of bird movement

// Initialize birds
function initBirds(window_w, window_h) {
  for (let i = 0; i < birdCount; i++) {
    birds.push({
      x: Math.random() * window_w, // Random horizontal position
      y: Math.random() * (window_h / 2), // Random vertical position (upper half)
      size: Math.random() * 30 + 20, // Random size between 20 and 80
    });
  }
}

// Draw bird
function drawBirds(graphics, birdImage, window_w, window_h) {
    birds.forEach((bird, index) => {
      // Draw each bird
      graphics.drawImage(birdImage, bird.x, bird.y, bird.size, bird.size);
  
      // Move bird leftward
      bird.x -= birdSpeed;
  
      // Reset bird if it moves off-screen
      if (bird.x + bird.size < 0) {
        birds[index].x = window_w + Math.random() * 50; // Reset to right side
        birds[index].y = Math.random() * (window_h / 2); // Randomize vertical position
      }
    });
}
