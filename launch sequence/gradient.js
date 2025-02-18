function createGradient(nid, width, height, darkness) {
  const grad = nid.createLinearGradient(0, height, 0, 0);

  // Light blue (sky) base colors
  const skyRedBottom = 173; // rgb(173, 216, 230)
  const skyGreenBottom = 216;
  const skyBlueBottom = 230;

  const skyRedTop = 135;
  const skyGreenTop = 206;
  const skyBlueTop = 250;

  // Purple (space) colors
  const spaceRedBottom = 0;
  const spaceGreenBottom = 0;
  const spaceBlueBottom = 100;

  const spaceRedTop = 0;
  const spaceGreenTop = 0;
  const spaceBlueTop = 50;

  // Interpolate colors based on darkness
  const blend = Math.min(darkness / 700, 1); // Normalize darkness to range [0, 1]

  // Bottom colors interpolation
  const redBottom = Math.round(skyRedBottom * (1 - blend) + spaceRedBottom * blend);
  const greenBottom = Math.round(skyGreenBottom * (1 - blend) + spaceGreenBottom * blend);
  const blueBottom = Math.round(skyBlueBottom * (1 - blend) + spaceBlueBottom * blend);

  // Top colors interpolation
  const redTop = Math.round(skyRedTop * (1 - blend) + spaceRedTop * blend);
  const greenTop = Math.round(skyGreenTop * (1 - blend) + spaceGreenTop * blend);
  const blueTop = Math.round(skyBlueTop * (1 - blend) + spaceBlueTop * blend);

  // Apply interpolated colors to the gradient
  grad.addColorStop(0, `rgb(${redBottom},${greenBottom},${blueBottom})`);
  grad.addColorStop(1, `rgb(${redTop},${greenTop},${blueTop})`);

  nid.fillStyle = grad;
  nid.fillRect(0, 0, width, height);
}
