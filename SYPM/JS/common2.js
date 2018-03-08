function jsondateconvert(value) {
    //使用正则表达式将日期属性中的非数字（\D）删除
    //并把得到的毫秒数转换成数字类型
    var dateMilliseconds = parseInt(value.replace(/\D/igm, "")); 
    //实例化一个新的日期格式，使用1970 年 1 月 1 日至今的毫秒数为参数
    var objdate = new Date(dateMilliseconds);    
    return objdate.toLocaleString();
}

function formatDate(value) {
    // alert(value.FBillNo);
    return value + "out"; //parseInt(strJson.replace(/\D/igm, ""));
}

///无时分秒
function jsonDateFormat(value) {//json日期格式转换为正常格式
 try {
     var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
  var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
  var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
  return date.getFullYear() + "-" + month + "-" + day;
 } catch (ex) {
  return "";
 }
}

///有时分秒
function jsonDateFormat2(value) {//json日期格式转换为正常格式
 try {
     var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
  var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
  var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
  var hours = date.getHours();
  var minutes = date.getMinutes();
  var seconds = date.getSeconds();
  var milliseconds = date.getMilliseconds();
  return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds + "." + milliseconds;
 } catch (ex) {
  return "";
 }
}