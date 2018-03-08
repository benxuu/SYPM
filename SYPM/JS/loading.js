/**
 *  页面加载等待页面
 *
 * @author gxjiang
 * @date 2010/7/24
 *
 */
 var height = window.screen.height-250;
 var width = window.screen.width;
 var leftW = 300;
 if(width>1200){
 	leftW = 500;
 }else if(width>1000){
 	leftW = 350;
 }else {
 	leftW = 100;
 }
 
 var _html = "<div id='loading' style='position:absolute; left:0; width:100%; height:100%; top:0; background:#E0ECFF'></div>";
 
 //window.onload = function(){
 //	var _mask = document.getElementById('loading');
 //	_mask.parentNode.removeChild(_mask);
 //}
 //document.write("<div id='cover'  style='width: 100%; height:100%;  position: absolute; top: 0;  left: 0;  background:#15428B'> </div>");
 //document.write(_html);
 // <div id='loading1' split="false" style='position:absolute; left:0; width:100%; height:100%; top:0; background:#10ECFF' z-index=10></div> 