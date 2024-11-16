function createGradient(nid,width,height,darkness){

 
  const grad=nid.createLinearGradient(0,height,0,0);

  var rb=208;//255
  var gb=217;//222
  var bb=218;//69

  var blue_bottom=bb+darkness;
  if(darkness>128){
    blue_bottom=255-(darkness-128);
  }
  var green_bottom=gb-darkness;
  var red_bottom=rb-darkness;

  var red_top=50-darkness/4;
  var green_top=37-darkness/4;
  var blue_top=100-darkness/4;
  
  if(red_top<0)
    red_top=0;
  if(green_top<0)
    green_top=0;
  if(blue_top<0)
    blue_top=0;

  if(red_bottom<0)
    red_bottom=0;
if(green_bottom<0)
    green_bottom=0;
if(blue_bottom<0)
    blue_bottom=0;




  grad.addColorStop(0,"rgb("+red_bottom+","+green_bottom+","+blue_bottom+")");
  grad.addColorStop(1, "rgb("+red_top+","+green_top+","+blue_top+")"); 

  nid.fillStyle=grad;

  nid.fillRect(0,0,width,height);

}
