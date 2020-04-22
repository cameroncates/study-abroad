class _VALIDATION
{
    constructor() { }

    _VALIDATE_STRING(STRING)
    {
        var PATTERN = /^[a-zA-Z0-9_ ]*$/;

        let VALUE = STRING.value;
        let LABEL = STRING.nextElementSibling;
        let FORM = STRING.parentElement;
        let LENGTH = FORM.getElementsByTagName('input').length;
        let BUTTON = FORM.getElementsByTagName('input')[LENGTH - 1];

        if (!VALUE.match(PATTERN))
        {
            LABEL.innerHTML = '<b>Invalid String</b>';
        }
        else
        {
            LABEL.innerHTML = '<b>Valid</b>';
        }

        let IS_VALID = true;

        for (let i = 0; i < LENGTH; i++)
        {
            let ELEM = FORM.getElementsByTagName('input')[i];
            if (ELEM.type == "text")
            {
                if (!ELEM.value.match(PATTERN) || ELEM.value == "")
                {
                    IS_VALID = false;
                    break;
                }
            }
        }
        if (IS_VALID)
        {
            BUTTON.classList.remove('DISABLED');
            BUTTON.classList.add('dark-btn');
            BUTTON.disabled = false;
        }
        else
        {
            BUTTON.classList.remove('dark-btn');
            BUTTON.classList.add('DISABLED');
            BUTTON.disabled = true;
        }


    }
}
const V = new _VALIDATION();