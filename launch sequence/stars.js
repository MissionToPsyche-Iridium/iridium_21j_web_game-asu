
let stararray_x = [];
let stararray_y = [];

var size = 7 + Math.random()*14;


var radius = 5;

var i;
var width = window.innerWidth-radius;
var height = window.innerHeight-radius;
for(i=0;i<size;i++){
  stararray_y[i] = Math.random()*height;
  stararray_x[i] = Math.random()*width;
}

let circle= 2*Math.PI;


function draw_stars(graphics,down,opacity){

  graphics.fillStyle = "rgba(255,255,255,"+opacity+")";

  for(i=0;i<size;i++){
    
    var y = stararray_y[i] + down;

    if(y > height+radius){
      y=y-height;
    }

    graphics.beginPath();
    graphics.arc(stararray_x[i],y,radius,0,circle);
    graphics.fill();
  }


}
