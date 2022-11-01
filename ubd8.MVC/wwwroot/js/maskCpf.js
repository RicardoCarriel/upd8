function maskCpfCnpj(o, f) {
    valueObject = o;
    valueFunction = f;
    setTimeout('execMask()', 1);
}

function execMask() {
    valueObject.value = valueFunction(valueObject.value);
}

function cpfCnpj(value) {

    //Remove tudo o que não é dígito
    value = value.replace(/\D/g, "");

    if (value.length <= 14) { //CPF

        //Coloca um ponto entre o terceiro e o quarto dígitos
        value = value.replace(/(\d{3})(\d)/, "$1.$2");

        //Coloca um ponto entre o terceiro e o quarto dígitos
        //de novo (para o segundo bloco de números)
        value = value.replace(/(\d{3})(\d)/, "$1.$2");

        //Coloca um hífen entre o terceiro e o quarto dígitos
        value = value.replace(/(\d{3})(\d{1,2})$/, "$1-$2");

    } else { //CNPJ

        //Coloca ponto entre o segundo e o terceiro dígitos
        value = value.replace(/^(\d{2})(\d)/, "$1.$2");

        //Coloca ponto entre o quinto e o sexto dígitos
        value = value.replace(/^(\d{2}).(\d{3})(\d)/, "$1.$2.$3");

        //Coloca uma barra entre o oitavo e o nono dígitos
        value = value.replace(/.(\d{3})(\d)/, ".$1/$2");

        //Coloca um hífen depois do bloco de quatro dígitos
        value = value.replace(/(\d{4})(\d)/, "$1-$2");

    }

    return value;

}