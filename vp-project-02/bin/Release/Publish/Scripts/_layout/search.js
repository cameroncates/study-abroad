const ELEMENTS = new _ELEMS();

function _SEARCH()
{
    let SEARCH_CONT = ELEMENTS.GET_CLASS('RESULT-CONT', 0);
    let SEARCH_URL = [0, 0, 0];
    let SEARCH_BY = null;

    this.FIELD_FOCUS = function (e)
    {
        SEARCH_CONT.innerHTML = "";
        let CLASS_NAME = e.target.classList[0];

        let KEYWORDS = e.target.value;
        SEARCH_BY = ELEMENTS.GET_CLASS(CLASS_NAME, 0).placeholder;
        let TR = ELEMENTS.CREATE_ELEM('TR');
        let TH = ELEMENTS.CREATE_ELEM('TH');

        TH.innerHTML = "Popular Search  &nbsp; " + SEARCH_BY;
        TR.appendChild(TH);
        SEARCH_CONT.appendChild(TR);

        if (SEARCH_BY.includes('Field'))
            this.SEARCH(SEARCH_BY, KEYWORDS, '_GET_BY_FIELD', CLASS_NAME);
        else if (SEARCH_BY.includes('Country'))
            this.SEARCH(SEARCH_BY, KEYWORDS, '_GET_BY_COUNTRY', CLASS_NAME);
        else if (SEARCH_BY.includes('Graduation'))
            this.SEARCH(SEARCH_BY, KEYWORDS, '_GET_BY_GRADUATION', CLASS_NAME);
        else if (SEARCH_BY.includes('Course'))
            this.SEARCH(SEARCH_BY, KEYWORDS, '_GET_BY_COURSE', CLASS_NAME);

    }
    this.SEARCH = function (CATEGORY, KEYWORDS, TARGET, TEXT_FIELD)
    {
        $.ajax(
            {
                url: "/Search/"+TARGET,
                type: "POST",
                data:
                {
                    SEARCH_BY: CATEGORY,
                    KEYWORDS : KEYWORDS
                },
                traditional: true,
                success: function (data)
                {
                    data = JSON.parse(data);
                    PRINT_SEARCH_RESULT(data, TEXT_FIELD, KEYWORDS);
                },
                error: function (err)
                {
                    console.error(err);
                }
            });
    }
    function PRINT_SEARCH_RESULT(DATA, TEXT_FIELD, KEYWORDS)
    {
        let NO_RECORD = false;
        if (DATA.length == 0)
        {
            DATA.length = 1;
            NO_RECORD = true;
        }
        for (let i = 0; i < DATA.length; i++)
        {
            let TR = ELEMENTS.CREATE_ELEM('TR');
            let TD = ELEMENTS.CREATE_ELEM('TD');
            if (!NO_RECORD)
            {
                DATA[i].title = DATA[i].title.replace(new RegExp(KEYWORDS, 'gi'), '<b><u>' + KEYWORDS + '</u></b>');
                TD.innerHTML = '&#9656; ' + DATA[i].title;
                TD.setAttribute('class', 'click-01');
                TD.setAttribute('onmousedown',
                `SEARCH.SET_DATA_IN_FIELD('${TEXT_FIELD}','${DATA[i].title}','${DATA[i].id}')`);
            }
            else
                TD.innerHTML = 'No Record Found, Try different keywords' ;

            TR.appendChild(TD);
            SEARCH_CONT.appendChild(TR);
        }
    }
    this.REMOVE_RESULT = function ()
    {
        SEARCH_CONT.innerHTML = "";
    }
    this.SET_DATA_IN_FIELD = function (TEXT_FIELD_CLASS, DATA, ID)
    {
        let REMOVE_HTML = DATA.replace(/<(?:.|\n)*?>/gm, '');
        ELEMENTS.GET_CLASS(TEXT_FIELD_CLASS, 0).value = REMOVE_HTML;

        if (ELEMENTS.GET_CLASS(TEXT_FIELD_CLASS, 0).placeholder.includes('Graduation'))
            ID = DATA.replace(/<(?:.|\n)*?>/gm, '');

        SEARCH_URL[TEXT_FIELD_CLASS.slice(-1) - 1] = ID;
        console.log(SEARCH_URL);
    }
    this._CHANGE_PLACEHOLDER = function (TEXT_FIELD, NEW_PLACEHOLDER)
    {
        TEXT_FIELD.placeholder =  NEW_PLACEHOLDER;
    }
    this.SEARCH_RESULT = function ()
    {
        let FIELD1 = "FIELD_ID="+SEARCH_URL[0];
        let FIELD2 = "COUNTRY_ID=" + SEARCH_URL[1];
        let FIELD3 = null;
        if (SEARCH_FIELD3.placeholder.includes('Course'))
            FIELD3 = "COURSE_ID=" + SEARCH_URL[2];
        else
            FIELD3 = "GRADUATION_ID=" + SEARCH_URL[2];

        window.open(`/DEGREE?${FIELD1}&${FIELD2}&${FIELD3}`, '_self');
    }
}

let SEARCH_FIELD1 = ELEMENTS.GET_CLASS('field1', 0);
let SEARCH_FIELD2 = ELEMENTS.GET_CLASS('field2', 0);
let SEARCH_FIELD3 = ELEMENTS.GET_CLASS('field3', 0);
const SEARCH = new _SEARCH();
let BY_COURSES = ELEMENTS.GET_CLASS('BY-COURSES', 0);
let SEARCH_BTN = ELEMENTS.GET_CLASS('search-btn', 0);

BY_COURSES.addEventListener('click', () => SEARCH._CHANGE_PLACEHOLDER(SEARCH_FIELD3, 'Course Title'));


SEARCH_FIELD1.addEventListener('focus', e => SEARCH.FIELD_FOCUS(e));
SEARCH_FIELD1.addEventListener('keyup', e => SEARCH.FIELD_FOCUS(e));

SEARCH_FIELD2.addEventListener('focus', e => SEARCH.FIELD_FOCUS(e));
SEARCH_FIELD2.addEventListener('keyup', e => SEARCH.FIELD_FOCUS(e));

SEARCH_FIELD3.addEventListener('focus', e => SEARCH.FIELD_FOCUS(e));
SEARCH_FIELD3.addEventListener('keyup', e => SEARCH.FIELD_FOCUS(e));


SEARCH_FIELD1.addEventListener('blur', SEARCH.REMOVE_RESULT);
SEARCH_FIELD2.addEventListener('blur', SEARCH.REMOVE_RESULT);
SEARCH_FIELD3.addEventListener('blur', SEARCH.REMOVE_RESULT);

SEARCH_BTN.addEventListener('click', SEARCH.SEARCH_RESULT);