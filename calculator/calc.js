(function() {
    $('button').on('click', getResult);

    function getResult() {
        var data = $(this).data('operation'),
            n1 = parseInt($('#num1').val()),
            n2 = parseInt($('#num2').val());
        if (!isNaN(n1)&&!isNaN(n2)) {
            switch (data) {
                case 'minus':
                    {
                        alert('result is ' + (n1 - n2));
                        break;
                    }
                case 'plus':
                    {
                        alert('result is ' + (n1 + n2));
                        break;
                    }
                case 'multiply':
                    {
                        alert('result is ' + (n1 * n2));
                        break;
                    }
                case 'del':
                    {
                        checkDivision(n2) ? alert('result is ' + (n1 / n2)) : alert('division into 0!!!');
                        break;
                    }
            }
        } else alert("enter a number!");

    };

    function checkDivision(number) {
        if (number) return true;
        return false;
    };
})();