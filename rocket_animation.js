let f1=new Image();
let f2=new Image();
let f3=new Image();
let f4=new Image();
let f5=new Image();
let f6=new Image();

f1.src="jets_animation/1.png";
f2.src="jets_animation/2.png";
f3.src="jets_animation/3.png";
f4.src="jets_animation/4.png";
f5.src="jets_animation/5.png";
f6.src="jets_animation/6.png";

let listed=[f1,f2,f3,f4,f5,f6];


  
var counter=0;
var gcounter=0;
function draw_jets(graphics,x,y,scale){


  var rocket_width=278*scale;
  var jets_height=962*scale;

  var draw_cur=listed[counter];


  graphics.drawImage(draw_cur,x,y,rocket_width,jets_height);


  if(gcounter%1==0){
    counter++;
    if(counter > 5)
      counter=0;
  }
  gcounter++;

}
