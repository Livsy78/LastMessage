// in: seconds
// out: 2m 23d 14:53:18

function FormatTime(seconds)
{
    const minute = 60;
    const hour = 60 * minute;
    const day = 24 * hour;
    const month = 30 * day;
    
    var out = "";

    if(seconds >= month)
    {
        var monthes = Math.floor(seconds / month);
        out += monthes.toString() + "m ";
        seconds -= monthes * month;
    }

    if(seconds >= day)
    {
        var days = Math.floor(seconds / day);
        out += days.toString() + "d ";
        seconds -= days * day;
    }


    if(out != "")
    {
        out = "<i>"+out+"</i><br/>";
    }


    var hours = Math.floor(seconds / hour);
    out += (hours < 10 ? "0" : "") + hours.toString() + ":";
    seconds -= hours * hour;

    var minutes = Math.floor(seconds / minute);
    out += (minutes < 10 ? "0" : "") + minutes.toString() + ":";
    seconds -= minutes * minute;

    out += (seconds < 10 ? "0" : "") + seconds.toString();

    return out;
}
