function isEqualDate(date1,date2)
{
  var xdate = new Date(date1);
  var ydate = new Date(date2);
  if (xdate.getDate() == ydate.getDate()
  && xdate.getMonth() == ydate.getMonth()
  && xdate.getFullYear() == ydate.getFullYear()) {
    return 1;
  } else {
    return 0;
  }
};

function getDateFromFullDate(pDate)
{
  var xdate = new Date(pDate);
  var day = xdate.getDate();
  var month = xdate.getMonth();
  var year = xdate.getFullYear();
  var newDate = Date(year,month,day);
  return newDate;
};
