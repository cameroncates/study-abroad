function _ELEMS()
{
    this.GET_ID = function (ID)
    {
        return document.getElementById(ID);
    }
    this.GET_CLASS = function (NAME, INDEX) {
        return document.getElementsByClassName(NAME)[INDEX];
    }
    this.CREATE_ELEM = function (NAME) {
        return document.createElement(NAME);
    }
}