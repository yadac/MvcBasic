$.validator.addMethod('blackword',
    function (value, element, param) {
        // 入力値が空の場合は検証をスキップ
        value = $.trim(value);
        if (value === '') return true;

        var list = param.split(',');
        for (var i = 0, len = list.length; i < len; i++) {
            if (value.indexOf(list[i] !== -1)) return false;
        }
        return true;
    });

// blackword検証とパラメータoptions(rule)を登録
$.validator.unobtrusive.adapters.addSingleVal('blackword', 'options');