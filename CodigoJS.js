// Funcion Formato a numeros
function FormatNumber(IdTxt, decimalPlaces, appendZeros, insertCommas) {
    var num = document.getElementById(IdTxt).value.replace(',', '');
    var powerOfTen = Math.pow(10, decimalPlaces);
    num = Math.round(num * powerOfTen) / powerOfTen;
    if (!appendZeros && !insertCommas) {
        return num;
    }
    else {
        var strNum = num.toString();
        var posDecimal = strNum.indexOf(".");
        if (appendZeros) {
            var zeroToAppendCnt = 0;
            if (posDecimal < 0) {
                strNum += ".";
                zeroToAppendCnt = decimalPlaces;
            }
            else {
                zeroToAppendCnt = decimalPlaces - (strNum.length - posDecimal - 1);
            }
            for (var x = 0; x < zeroToAppendCnt; x++) {
                strNum += "0";
            }
        }
        if (insertCommas && (Math.abs(num) >= 1000)) {
            var i = strNum.indexOf(".");
            if (i < 0) {
                i = strNum.length;
            }
            i -= 3;
            while (i >= 1) {
                strNum = strNum.substring(0, i) + ',' + strNum.substring(i, strNum.length);
                i -= 3;
            }
        }
        //                 return strNum;
        document.getElementById(IdTxt).value = strNum;
    }
}

function ValidaSoloNumeros(IdTxt) {
    var num = document.getElementById(IdTxt).value;
    var strNum = num.toString();
    var c = strNum.indexOf(".");
    if (event.keyCode == 46) {
        if (c > -1)
            event.returnValue = false;
    }
    else
            if (event.keyCode == 13) {
        event.returnValue = true;
    }
    else 
        if ((event.keyCode < 48) || (event.keyCode > 57)) {
            event.returnValue = false;
        }        
}

function QuitaComas(IdTxt) {
    var num = document.getElementById(IdTxt).value.replace(/,/g, '');
    //    document.getElementById(IdTxt).value = parseInt(num);
    document.getElementById(IdTxt).value = num.toString();
    //    document.write(parseInt(num));
}

function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
    numero = parseFloat(numero);
    if (isNaN(numero)) {
        return "";
    }

    if (decimales !== undefined) {
        // Redondeamos
        numero = numero.toFixed(decimales);
    }

    // Convertimos el punto en separador_decimal
    numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

    if (separador_miles) {
        // Añadimos los separadores de miles
        var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
        while (miles.test(numero)) {
            numero = numero.replace(miles, "$1" + separador_miles + "$2");
        }
    }

    return numero;
}

function PierdeFoco(IdTxt) {
    if ((event ? event.which : event.keyCode) == 13 || (event ? event.which : event.keyCode) == 09)  {
        event.preventDefault();
        document.getElementById(IdTxt).focus();
        __doPostBack(this, "TextChanged");            
    }
}

function PierdeFoco_1(IdTxt,IdTxt2) {
    if ((event ? event.which : event.keyCode) == 13 || (event ? event.which : event.keyCode) == 09) {
        event.preventDefault();
        document.getElementById(IdTxt).focus();
        __doPostBack(IdTxt2, "TextChanged");
    }
}