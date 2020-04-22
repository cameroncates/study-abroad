function Field()
{
    let SHOW = false;
    let ELEMENT = new _ELEMS();
    this.TOGGLE_COURSES = function (ID, BTN)
    {
        if (!SHOW)
        {
            ELEMENT.GET_ID(ID).style.maxHeight = '500px';
            BTN.innerHTML = 'HIDE COURSES  &#x21e1;';
            SHOW = true;
        }
        else
        {
            ELEMENT.GET_ID(ID).style.maxHeight = '0px';
            BTN.innerHTML = 'SHOW COURSES  &#x21e3;';
            SHOW = false;
        }
    }
    this.SCROLL_TO = function ()
    {
        let ID = window.location.hash.substr(1);
        if (ID != "")
        {
            let BTN = ELEMENT.GET_ID("_" + ID);
            BTN.click();
        }
    }
}
let field = new Field();
field.SCROLL_TO();