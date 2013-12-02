
function confirmDelete()
{
  var x = window.confirm('Bạn có chắc chắn xóa không ?');
  if(x==true){
      return true;
  }else{
      return false;
  }
}
function confirmDelete(title)
{      
  var x = window.confirm(title);
  if(x==true){
      return true;
  }else{
      return false;
  }
}
    
