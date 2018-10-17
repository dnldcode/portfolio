var buttons = document.getElementsByClassName('btn');
var decimal = false;
var zero = true;
var operators = ['+', '-', '*', '/'];
for (var i = 0; i < buttons.length; i++) {
    buttons[i].onclick = function (e) {
        var input = document.getElementById('input');
        if (input.innerHTML.includes('Infinity'))
            input.innerHTML = '';
        var inputValue = input.innerHTML;
        var value = this.innerHTML;

        if (value == "C") {
            input.innerHTML = "";
            decimal = false;
        }
        else if (value == '0') {
            if (zero) {
                input.innerHTML += value;
                if (!decimal)
                    zero = false;
            }
        }
        else if (value.includes('remove')) {
            if (inputValue.length != 0)
                input.innerHTML = inputValue.slice(0, -1);
        }
        else if (value == '.') {
            if (!decimal && inputValue.length != 0) {
                input.innerHTML += value;
                decimal = true;
                zero = true;
            }
        }
        else if (value == '=') {
            if (operators.includes(inputValue[inputValue.length - 1]))
                inputValue = inputValue.slice(0, -1);
            if (inputValue.length != 0)
                input.innerHTML = eval(inputValue);
        }
        else if (operators.includes(value)) {
            var lastChar = inputValue[inputValue.length - 1];
            if (!operators.includes(lastChar) && inputValue.length != 0) {
                if (inputValue[inputValue.length - 1] == '.')
                    input.innerHTML = inputValue.slice(0, -1);
                input.innerHTML += value;
                zero = true;
                decimal = false;
            }
        }
        else {
            input.innerHTML += value;
        }
    }
}